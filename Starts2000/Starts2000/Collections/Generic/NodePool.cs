using Starts2000.Threading;

namespace Starts2000.Collections.Generic
{
    public class NodePool<T> : NodeManager<T>
    {
        // The head of the stack (always refers to a node; never null)
        LockFreeNode<T> _head = new LockFreeNode<T>();

        public NodePool()
        {
        }

        public override LockFreeNode<T> Allocate(T item)
        {
            LockFreeNode<T> node;

            do
            {
                // Get head
                node = _head.Next;

                // If no head, stack is empty, return new node
                if (node == null)
                {
                    return new LockFreeNode<T>(item);
                }

                // If previous head == what we think is head, change head to next node
                // else try again
            }
            while (!InterlockedEx.IfThen(ref _head.Next, node, node.Next));

            node.Item = item;
            return node;
        }

        public override void Free(LockFreeNode<T> node)
        {
            node.Item = default(T); // Allow early GC

            // Try to make the new node be the head of the stack
            do
            {
                // Make the new node refer to the old head
                node.Next = _head.Next;

                // If previous head's next == what we thought was next, change head's Next to the new node
                // else, try again if another thread changed the head
            }
            while (!InterlockedEx.IfThen(ref _head.Next, node.Next, node));
        }
    }
}
