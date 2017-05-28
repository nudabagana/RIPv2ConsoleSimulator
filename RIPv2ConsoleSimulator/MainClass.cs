using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIPv2ConsoleSimulator
{
    class MainClass
    {
        static List<Router> routerList;
        static void Main(string[] args)
        {
            String routerName;
            Router router;
            routerList = new List<Router>();
            int control = 0;
            while (control != 7)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Router List");
                Console.WriteLine("2. Router Paths");
                Console.WriteLine("3. Add Router");
                Console.WriteLine("4. Add Link");
                Console.WriteLine("5. Update");
                Console.WriteLine("6. Delete Router");
                Console.WriteLine("7. Exit");
                Console.WriteLine("8.(TEST FUNCTION) Test data");
                String str = Console.ReadLine();
                if (str.Length > 0 && str[0] > 48 && str[0] < 57)
                {
                    control = str[0] - '0';
                    switch (control)
                    {
                        case 1:
                            // Router list
                            Console.WriteLine("Routers:");
                            foreach (Router r in routerList)
                            {
                                Console.WriteLine(r.Name);
                            }
                            break;
                        case 2:
                            // Router Paths
                            Console.WriteLine("Please enter router name: ");
                            routerName = Console.ReadLine();
                            router = routerList.FirstOrDefault(x => x.Name == routerName);
                            if (router != null)
                            {
                                Console.WriteLine(routerName + " has paths to:");
                                foreach (TableEntry entry in router.RoutingTable)
                                {
                                    Console.WriteLine("Dest: " + entry.DestinationRouter.Name +
                                                     " | Through: " + entry.nextRouter.Name +
                                                     " | Metric: " + entry.Metric);
                                }
                            }
                            else
                            {
                                Console.WriteLine(routerName + " was not found.");
                            }
                            break;
                        case 3:
                            // Add Router
                            routerList.Add(new Router());
                            Console.WriteLine(routerList.Last().Name + " was successfully added!");
                            break;
                        case 4:
                            // Add link
                            Console.WriteLine("Please enter first router name: ");
                            String routerToLinkName1 = Console.ReadLine();
                            Console.WriteLine("Please enter second router name: ");
                            String routerToLinkName2 = Console.ReadLine();
                            Router routerToLink1 = routerList.FirstOrDefault(x => x.Name == routerToLinkName1);
                            Router routerToLink2 = routerList.FirstOrDefault(x => x.Name == routerToLinkName2);

                            if (routerToLink1 != null && routerToLink2 != null && routerToLink1 != routerToLink2)
                            {
                                // Link routers
                                Functions.AddLink(routerToLink1, routerToLink2, 1);
                                Console.WriteLine(routerToLinkName1 + " and " + routerToLinkName2
                                                + " were successfully linked!");
                            }
                            else
                            {
                                if (routerToLink1 == routerToLink2)
                                {
                                    Console.WriteLine("Can't link with self.");
                                }
                                else
                                {
                                    Console.WriteLine(routerToLinkName1 + " or " +
                                                      routerToLinkName2 + " was not found.");
                                }
                            }
                            break;
                        case 5:
                            // Update
                            Functions.Update(routerList);
                            Console.WriteLine("Router's have successfully updated their entries!");
                            break;
                        case 6:
                            // Delete Router
                            Console.WriteLine("Please enter router name: ");
                            routerName = Console.ReadLine();
                            router = routerList.FirstOrDefault(x => x.Name == routerName);
                            if (router != null)
                            {
                                Functions.RemoveRouter(router, routerList);
                                Console.WriteLine(router.Name + " was successfully deleted!");
                            }
                            else
                            {
                                Console.WriteLine(routerName + " was not found.");
                            }
                            break;

                        case 8:
                            routerList.Add(new Router("A"));
                            routerList.Add(new Router("B"));
                            routerList.Add(new Router("C"));
                            routerList.Add(new Router("D"));
                            routerList.Add(new Router("E"));
                            routerList.Add(new Router("F"));
                            routerList.Add(new Router("G"));
                            Functions.AddLink(routerList.First(x => x.Name == "A"), routerList.First(x => x.Name == "B"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "B"), routerList.First(x => x.Name == "G"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "B"), routerList.First(x => x.Name == "C"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "C"), routerList.First(x => x.Name == "E"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "E"), routerList.First(x => x.Name == "F"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "F"), routerList.First(x => x.Name == "D"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "D"), routerList.First(x => x.Name == "G"), 1);
                            routerList.Add(new Router("1"));
                            routerList.Add(new Router("2"));
                            routerList.Add(new Router("3"));
                            routerList.Add(new Router("4"));
                            routerList.Add(new Router("5"));
                            routerList.Add(new Router("6"));
                            routerList.Add(new Router("7"));
                            routerList.Add(new Router("8"));
                            routerList.Add(new Router("9"));
                            routerList.Add(new Router("10"));
                            routerList.Add(new Router("11"));
                            routerList.Add(new Router("12"));
                            Functions.AddLink(routerList.First(x => x.Name == "A"), routerList.First(x => x.Name == "1"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "1"), routerList.First(x => x.Name == "2"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "2"), routerList.First(x => x.Name == "3"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "3"), routerList.First(x => x.Name == "4"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "4"), routerList.First(x => x.Name == "5"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "5"), routerList.First(x => x.Name == "6"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "6"), routerList.First(x => x.Name == "7"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "7"), routerList.First(x => x.Name == "8"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "8"), routerList.First(x => x.Name == "9"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "9"), routerList.First(x => x.Name == "10"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "10"), routerList.First(x => x.Name == "11"), 1);
                            Functions.AddLink(routerList.First(x => x.Name == "11"), routerList.First(x => x.Name == "12"), 1);
                            break;

                            // Exit
                    }
                    if (control != 7)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
