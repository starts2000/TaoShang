using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Starts2000.Net.Session.Dispatcher
{
    public class DirectDispatcher : IDispatcher
    {
        static readonly ThreadLocal<Queue<Action>> _threadLocal =
            new ThreadLocal<Queue<Action>>(() =>
            {
                return new Queue<Action>();
            });

        public DirectDispatcher()
        {
        }

        public void Dispatch(Action sessionAction)
        {
            Queue<Action> queue = _threadLocal.Value;
            queue.Enqueue(sessionAction);

            while(queue.Count > 0)
            {
                Action dispatcher = queue.Dequeue();
                if(dispatcher != null)
                {
                    dispatcher();
                }
            }
        }
    }
}
