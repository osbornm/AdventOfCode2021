using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class Fish
    {
        public int CycleTime { get; set; }
        public Fish(int cycleTimeStart = 8)
        {
            CycleTime = cycleTimeStart;
        }

        public Fish RunCycle()
        {
            if(CycleTime > 0)
            {
                CycleTime--;
            } else if(CycleTime == 0)
            {
                CycleTime = 6;
                return new Fish();
            }
            return null;
        }
    }
}
