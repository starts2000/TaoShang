namespace Starts2000.Collections.Generic
{
    public sealed class LockFreeNode<T>
    {
        /// <summary>
        /// Refers to next node or null.
        /// </summary>
        public LockFreeNode<T> Next;

        /// <summary>
        /// Item in this Node.
        /// </summary>
        public T Item;

        public LockFreeNode()
        { 
        }

        public LockFreeNode(T item)
        {
            Item = item;
        }
    }
}
