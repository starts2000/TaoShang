namespace Starts2000.Collections.Generic
{
    public class NodeManager<T>
    {
        static readonly NodeManager<T> _default = new NodeManager<T>();

        public static NodeManager<T> Default
        {
            get { return _default; }
        }

        public LockFreeNode<T> Allocate()
        {
            return Allocate(default(T));
        }

        public virtual LockFreeNode<T> Allocate(T item)
        {
            return new LockFreeNode<T>(item);
        }

        public virtual void Free(LockFreeNode<T> node)
        {
            node.Item = default(T);
        }
    }
}
