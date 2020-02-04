using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Helpers
{
    public class BlinkingLights
    {
        public int FirstRow { get; set; }
        public int SecondRow { get; set; }

        public BlinkingLights(int firstRow, int secondRow)
        {
            FirstRow = firstRow;
            SecondRow = secondRow;
        }
    }
}
