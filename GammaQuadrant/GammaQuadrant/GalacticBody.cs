using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M33Universe
{ 
    class GalacticBody
    {
        private long xCord;
        private long yCord;
        private long zCord;

        public void setXCord(long val)
        {
            xCord = val;
        }

        public void setYCord(long val)
        {
            yCord = val;
        }

        public void setZCord(long val)
        {
            zCord = val;
        }

        public long getXCord()
        {
            return xCord;
        }

        public long getYCord()
        {
            return yCord;
        }

        public long getZCord()
        {
            return zCord;
        }

        public long[] splitNumber(long value)
        {
            Stack<long> q = new Stack<long>();
            do
            {
                q.Push(value % 1000);
                value /= 1000;
            } while (value > 0);
            return q.ToArray();
        }
    }
}
