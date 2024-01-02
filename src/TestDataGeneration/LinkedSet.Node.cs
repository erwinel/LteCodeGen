namespace TestDataGeneration;

public partial class LinkedSet<T>
{
    public abstract class Node
    {
        private readonly object _syncRoot = new();

        public LinkedSet<T>? Container { get; set; }

        public T? Previous { get; private set; }

        public T? Next { get; private set; }

        protected virtual bool OnBeforeInsert(LinkedSet<T> container, T? refNode, bool refNodeIsPrevious) => (refNode is null) ? container.RaiseBeforeInsert((T)this) : container.RaiseBeforeInsert((T)this, refNode, refNodeIsPrevious);
        
        private static void OnAfterRemove(LinkedSet<T> container, IEnumerator<(T item, LinkedSet<T>.Node? RefNode, bool RefNodeIsPrevious)> enumerator)
        {
            (T item, LinkedSet<T>.Node? refNode, bool refNodeIsPrevious) = enumerator.Current;
            try { item.OnAfterRemove(container, (T?)refNode, refNodeIsPrevious); }
            finally { if (enumerator.MoveNext()) OnAfterRemove(container, enumerator); }
        }

        protected virtual void OnAfterRemove(LinkedSet<T> container, T? refNode, bool refNodeIsPrevious)
        {
            if (refNode is null)
                container.RaiseAfterRemove((T)this);
            else
                container.RaiseAfterRemove((T)this, refNode, refNodeIsPrevious);
        }

        protected virtual void OnAfterInsert() => Container!.RaiseAfterInsert((T)this);

        protected virtual bool OnBeforeRemove() => Container!.RaiseBeforeRemove((T)this);

        #region Private Methods

        private static bool AddLast(T item, LinkedSet<T> container)
        {
            var changeToken = container._changeToken;
            if (!item.OnBeforeInsert(container, null, false)) return false;
            if (item.Container is not null || !ReferenceEquals(changeToken, container._changeToken)) throw new InvalidOperationException();
            container._changeToken = new();
            if ((item.Previous = container.Last) is null)
                container.Last = item;
            else
                item.Previous.Next = item;
            item.Container = container;
            container.Count++;
            item.OnAfterInsert();
            return true;
        }

        private static bool InsertAfter(T item, T refNode)
        {
            var container = refNode.Container!;
            var changeToken = container._changeToken;
            if (!item.OnBeforeInsert(container, refNode, true)) return false;
            if (item.Container is not null || !ReferenceEquals(changeToken, container._changeToken)) throw new InvalidOperationException();
            container._changeToken = new();
            if ((item.Next = refNode.Next) is null)
                container.Last = item;
            else
                item.Next.Previous = item;
            (refNode.Next = item).Previous = refNode;
            item.Container = container;
            container.Count++;
            item.OnAfterInsert();
            return true;
        }

        private static bool InsertBefore(T item, T refNode)
        {
            var container = refNode.Container!;
            var changeToken = container._changeToken;
            if (!item.OnBeforeInsert(container, refNode, false)) return false;
            if (item.Container is not null || !ReferenceEquals(changeToken, container._changeToken)) throw new InvalidOperationException();
            container._changeToken = new();
            if ((item.Previous = refNode.Previous) is null)
                container.First = item;
            else
                item.Previous.Next = item;
            (refNode.Previous = item).Next = refNode;
            item.Container = container;
            container.Count++;
            item.OnAfterInsert();
            return true;
        }

        private bool IsUnlinkable()
        {
            var container = Container;
            if (container is null) return false;
            var changeToken = container._changeToken;
            if (!OnBeforeRemove()) return false;
            if (Container is null || !ReferenceEquals(changeToken, container._changeToken)) throw new InvalidOperationException();
            return true;
        }

        private void Unlink(out Node? refNode, out bool refNodeIsPrevious)
        {
            var container = Container!;
            Container = null;
            if ((refNode = Previous) is null)
            {
                refNodeIsPrevious = false;
                if ((refNode = container.First = (T?)refNode) is null)
                    container.Last = null;
                else
                    refNode.Previous = null;
            }
            else
            {
                refNodeIsPrevious = true;
                if ((refNode.Next = Next) is null)
                    container.Last = (T)refNode;
                else
                    refNode.Next.Previous = (T)refNode;
            }
            container.Count--;
        }

        #endregion

        internal static bool Add(T item, LinkedSet<T> set)
        {
            ArgumentNullException.ThrowIfNull(set);
            if (item is null) return false;
            Monitor.Enter(set.SyncRoot);
            try
            {
                Monitor.Enter(item._syncRoot);
                try
                {
                    if (item.Container is not null) return false;
                    for (var node = set.First; node is not null; node = node.Next)
                    {
                        int d = item.CompareTo(node);
                        if (d == 0) return false;
                        if (item.CompareTo(node) < 0) return InsertBefore(item, node);
                    }
                    if (set.Last is null) return AddLast(item, set);
                    return InsertAfter(item, set.Last);
                }
                finally { Monitor.Exit(item._syncRoot); }
            }
            finally { Monitor.Exit(set.SyncRoot); }
        }

        internal static bool Clear(LinkedSet<T> set)
        {
            LinkedList<(T item, Node? RefNode, bool RefNodeIsPrevious)> eventData = new();
            Monitor.Enter(set.SyncRoot);
            try
            {
                if (set.First is null) return true;
                for (var item = set.First; item is not null; item = item.Next)
                    if (!item.IsUnlinkable()) return false;
                for (var item = set.First; item is not null; item = item.Next)
                {
                    item.Unlink(out Node? refNode, out bool refNodeIsPrevious);
                    eventData.AddLast((item, refNode, refNodeIsPrevious));
                }
            }
            finally { Monitor.Exit(set.SyncRoot); }
            using var enumerator = eventData.GetEnumerator();
            if (enumerator.MoveNext())
                OnAfterRemove(set, enumerator);
            return true;
        }

        public abstract T Clone();

        internal static void ExceptWith(IEnumerable<T> other, LinkedSet<T> set)
        {
            Monitor.Enter(set.SyncRoot);
            try
            {
                throw new NotImplementedException();
            }
            finally { Monitor.Exit(set.SyncRoot); }
        }

        internal static IEnumerable<T> GetAllItems(LinkedSet<T> set)
        {
            for (T? item = set.First; item is not null; item = item.Next)
                yield return item;
        }

        internal static void IntersectWith(IEnumerable<T> other, LinkedSet<T> set)
        {
            Monitor.Enter(set.SyncRoot);
            try
            {
                throw new NotImplementedException();
            }
            finally { Monitor.Exit(set.SyncRoot); }
        }

        internal bool Remove()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                var container = Container;
                if (container is null) return false;
                Monitor.Enter(container.SyncRoot);
                try
                {
                    if (!IsUnlinkable()) return false;
                    container._changeToken = new();
                    Unlink(out Node? refNode, out bool refNodeIsPrevious);
                    OnAfterRemove(container, (T?)refNode, refNodeIsPrevious);
                }
                finally { Monitor.Exit(container.SyncRoot); }
            }
            finally { Monitor.Exit(_syncRoot); }
            return true;
        }

        internal static void SymmetricExceptWith(IEnumerable<T> other, LinkedSet<T> set)
        {
            Monitor.Enter(set.SyncRoot);
            try
            {
                throw new NotImplementedException();
            }
            finally { Monitor.Exit(set.SyncRoot); }
        }

        internal static void UnionWith(IEnumerable<T> other, LinkedSet<T> set)
        {
            Monitor.Enter(set.SyncRoot);
            try
            {
                throw new NotImplementedException();
            }
            finally { Monitor.Exit(set.SyncRoot); }
        }
    }
}