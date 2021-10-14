using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIThreading
{
    class FindPiThread
    {
        int totalDarts, circleDarts;
        Random ran;

        public FindPiThread(int nDarts)
        {
            ran = new Random();
            totalDarts = nDarts;
            circleDarts = 0;
        }

        public int getDarts()
        {
            return circleDarts;
        }

        public void throwDarts()
        {
            double x, y;

            for(int i=0; i<totalDarts; i++)
            {
                x = ran.NextDouble();
                y = ran.NextDouble();

                if(Math.Sqrt((x*x) + (y*y)) < 0.5)
                {
                    circleDarts++;
                }
            }
        }
    }
}
