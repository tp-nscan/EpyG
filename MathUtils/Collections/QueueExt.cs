using System;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Linq;

namespace MathUtils.Collections
{
    public static class QueueExt
    {
        public static IEnumerable<T> DequeAChunk<T>(this Queue<T> queue, int chunkSize)
        {
            for (var i = 0; i < chunkSize; i++)
            {
                if (queue.Any())
                {
                    yield return queue.Dequeue();
                }
                else
                {
                    yield break;
                }
            }
        }

        public static Tuple<IList<T>, ImmutableStack<T>> PopAChunk<T>(this ImmutableStack<T> stack, int chunkSize)
        {
            var listRet = new List<T>();

            for (var i = 0; i < chunkSize; i++)
            {
                if (! stack.Any())
                {
                    break;
                }

                listRet.Add(stack.Peek());
                stack = stack.Pop();
            }

            return new Tuple<IList<T>, ImmutableStack<T>>(listRet, stack);
        }

        public static ImmutableStack<T> PushMany<T>(this ImmutableStack<T> stack, IEnumerable<T> items)
        {
            return items.Aggregate(stack, (current, item) => current.Push(item));
        }
    }
}
