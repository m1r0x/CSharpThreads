using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpThreads
{
    class Program
    {
        static object Locker = new object();
        static void Main(string[] args)
        {
            Thread t = new Thread(MyThread1);
            Thread t2 = new Thread(MyThread2);

            t.Start();
            t2.Start();

            Counter = 0;

            Console.ReadKey();

        }
       

        static void MyThread1()
        {
            for (int i = 0; i < 500; i++)

                lock (Locker)
                {
                Console.WriteLine("Thread 1A counts: " + Counter);
                Counter++;
                Console.WriteLine("Thread 1B counts: " + Counter);
            }
        }

        static void MyThread2()
        {
            for (int i = 0; i < 500; i++)

                lock (Locker)
                {
                Console.WriteLine("Thread 2A counts: " + Counter);
                Counter++;
                Console.WriteLine("Thread 2B counts: " + Counter);
            }
        }

        public static int Counter { get; set; }
    }
}
