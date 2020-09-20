using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace clock
{
    public delegate void happen(int second);
    class Clock
    {
        public bool isRunning;
        public long startTick;
        public event happen Tick;
        public event happen Alarm;
        public Clock()
        {
            isRunning = false;
        }
        public void Start()
        {
            startTick = DateTime.Now.ToUniversalTime().Ticks;
            int secondTick = 1;
            isRunning = true;
            Tick(secondTick);
            while (isRunning)
            {
                Thread.Sleep(1000);
                startTick = DateTime.Now.ToUniversalTime().Ticks;
                secondTick += 1;
                Tick(secondTick);
                if (secondTick % 3 == 0)
                {
                    Alarm(secondTick);
                }

            }
        }
    }
    class Program
    {
        static void tick(int second)
        {
            Console.Write($"Tick{second} ");
        }
        static void alarm(int second)
        {
            Console.WriteLine($"Alarm{second}");
        }
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.Tick += tick;
            clock.Alarm += alarm;
            clock.Start();
        }

    }
}
