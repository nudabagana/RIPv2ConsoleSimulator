using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIPv2ConsoleSimulator
{
    class Router
    {
        static int autoNaming = 0;
        public Router()
        {
            autoNaming++;
            this.Name = "Router " + autoNaming.ToString();
            RoutingTable = new List<TableEntry>();
        }
        public Router(String name)
        {
            this.Name = name;
            RoutingTable = new List<TableEntry>();
        }

        public List<TableEntry> RoutingTable { get; set; }
        public String Name { get; set; }
    }
}
