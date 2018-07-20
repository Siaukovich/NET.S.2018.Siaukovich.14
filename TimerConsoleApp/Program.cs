using System;
using Timer;

namespace TimerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input time delay in second: ");
            var delay = int.Parse(Console.ReadLine());
            
            var publisher = new TimerEventPublisher(delay);
            const int PUBLISHERS_AMOUNT = 5;
            var subscribers = new Subscriber[PUBLISHERS_AMOUNT];
            for (int i = 0; i < subscribers.Length; i++)
            {
                subscribers[i] = new Subscriber(i);
                subscribers[i].Register(publisher);
                
                Console.WriteLine(subscribers[i].GetEventStatus());
            }
            
            Console.WriteLine($"Start time: {DateTime.Now}");
            publisher.StartTimer();

            const int MILLISECOND_PER_SECOND = 1000;
            System.Threading.Thread.Sleep(MILLISECOND_PER_SECOND * (delay + 1));

            foreach (var subscriber in subscribers)
            {
                Console.WriteLine(subscriber.GetEventStatus());
            }

            Console.ReadKey();
        }
    }
}