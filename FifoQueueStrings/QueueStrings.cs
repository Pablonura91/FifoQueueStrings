using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifoQueueStrings
{
    public class QueueStrings
    {
        private static readonly object _locker = new object();
        private static List<string> _queueStrings = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };

        //Delegado y evento
        public delegate void ItemEnqueued();
        public static event ItemEnqueued itemEnqueue;

        //Threads
        protected static Task t1;
        protected static Task t2;

        public QueueStrings() { }

        public static void start()
        {
            t1 = new Task(Consume);
            t2 = new Task(Consume);

            t1.Start();
            t2.Start();
            t1.Wait();
            t2.Wait();
        }

        public static void Enqueue(string item)
        {
            _queueStrings.Add(item);

            itemEnqueue?.Invoke();
        }

        public static string Dequeue()
        {
            string currentString = _queueStrings.Last();
            _queueStrings.Remove(currentString);

            return currentString;
        }

        public static int Count()
        {
            return _queueStrings.Count() - 1;
        }

        public static void OnItemEnqueued()
        {
            start();
        }

        public static void Consume()
        {
            lock (_locker)
            {
                string currentString = "";

                do
                {
                    if (Count() >= 0)
                    {
                        currentString = Dequeue();

                        Console.WriteLine($"El elemento {currentString} ha sido retirado en el hilo {Task.CurrentId}");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
            }
        }
    }
}
