using System;

namespace FifoQueueStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueStrings.itemEnqueue += QueueStrings.OnItemEnqueued;

            QueueStrings.start();

            QueueStrings.Enqueue("Z");
            QueueStrings.Enqueue("A");
            QueueStrings.Enqueue("F");
            QueueStrings.Enqueue("R");
            QueueStrings.Enqueue("P");

            Console.ReadLine();
        }        
    }
}
