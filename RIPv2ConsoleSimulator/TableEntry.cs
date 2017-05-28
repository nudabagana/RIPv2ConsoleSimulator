using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIPv2ConsoleSimulator
{
    class TableEntry
    {
        public Router DestinationRouter { get; set; }
        public int Metric { get; set; }
        public Router nextRouter { get; set; }
    }
}
