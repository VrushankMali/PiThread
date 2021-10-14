using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PIThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            int cDarts = 0;

            Console.WriteLine("How many threads you want to throw: ");
            string thread = Console.ReadLine();
            int nThread = Convert.ToInt32(thread);

            Console.WriteLine("How many darts in each thread: ");
            string dart = Console.ReadLine();
            int nDart = Convert.ToInt32(dart);

            List<FindPiThread> pi = new List<FindPiThread>();
            List<Thread> thrd = new List<Thread>();

            for (int i = 0; i < nThread; i++)
            {
                FindPiThread FPI = new FindPiThread(nDart);
                pi.Add(FPI);

                Thread th = new Thread(new ThreadStart(FPI.throwDarts));
                thrd.Add(th);

                th.Start();
                Thread.Sleep(16);
            }

            foreach (Thread items in thrd)
            {
                items.Join();
            }

            foreach (FindPiThread piThread in pi)
            {
                cDarts += piThread.getDarts();
            }

            Console.WriteLine(4.0 * (Convert.ToDouble(cDarts) / Convert.ToDouble(nThread * nDart)));
            Console.ReadLine();
        }
    }
}
