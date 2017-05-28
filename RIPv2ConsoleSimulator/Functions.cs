using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIPv2ConsoleSimulator
{
    class Functions
    {
        public static void AddLink(Router routerToLink1, Router routerToLink2, int Metric)
        {
            // Adding link to 1st rooter
            TableEntry alreadyUsedEntry = routerToLink1.RoutingTable.FirstOrDefault(x =>
                                                    x.DestinationRouter == routerToLink2);
            if (alreadyUsedEntry == null)
            {
                routerToLink1.RoutingTable.Add(new TableEntry()
                {
                    DestinationRouter = routerToLink2,
                    Metric = 1,
                    nextRouter = routerToLink2,
                });
            }
            else
            {
                alreadyUsedEntry.Metric = 1;
                alreadyUsedEntry.nextRouter = routerToLink2;
            }

            // Adding link to 2st rooter
            alreadyUsedEntry = routerToLink2.RoutingTable.FirstOrDefault(x =>
                                                    x.DestinationRouter == routerToLink1);
            if (alreadyUsedEntry == null)
            {
                routerToLink2.RoutingTable.Add(new TableEntry()
                {
                    DestinationRouter = routerToLink1,
                    Metric = 1,
                    nextRouter = routerToLink1,
                });
            }
            else
            {
                alreadyUsedEntry.Metric = 1;
                alreadyUsedEntry.nextRouter = routerToLink1;
            }
        }
        public static void RemoveRouter(Router router, List<Router> routerList)
        {
            foreach (Router r in routerList)
            {
                r.RoutingTable.RemoveAll(x => x.nextRouter == router);
            }
            routerList.Remove(router);
        }


        public static void Update(List<Router> routerList)
        {
            // Do Upadate
            foreach (Router router in routerList) // Every router
            {
                foreach (TableEntry entryRouter in router.RoutingTable) 
                {
                    if (entryRouter.Metric == 1) // Every Routers neighbour
                    {
                        foreach (TableEntry entry in router.RoutingTable)  // Every neighbour's entry
                        {
                            TableEntry tableEntry = entryRouter.DestinationRouter.RoutingTable
                                .FirstOrDefault(x => x.DestinationRouter == entry.DestinationRouter);


                            if (tableEntry != null )
                            {
                                if (tableEntry.Metric > (entry.Metric + 1) && tableEntry.nextRouter != router)
                                {
                                    tableEntry.Metric = entry.Metric + 1;
                                    tableEntry.nextRouter = router;
                                }
                            }
                            else if (entryRouter.DestinationRouter != entry.DestinationRouter &&
                                        entry.Metric < 15)
                            {
                                entryRouter.DestinationRouter.RoutingTable.Add(new TableEntry()
                                {
                                    DestinationRouter = entry.DestinationRouter,
                                    Metric = entry.Metric + 1,
                                    nextRouter = router,
                                });
                            }
                        }
                    }
                }
            }
            List<TableEntry> toRemoveEntries= new List<TableEntry>();

            foreach (Router router in routerList)
            {
                foreach(TableEntry entry in router.RoutingTable)
                {
                    if (entry.Metric > 1 && (entry.nextRouter.RoutingTable
                        .FirstOrDefault(x => x.DestinationRouter == entry.DestinationRouter) == null
                        || entry.nextRouter.RoutingTable
                        .FirstOrDefault(x => x.DestinationRouter == entry.DestinationRouter).Metric >= entry.Metric))
                    {
                        toRemoveEntries.Add(entry);
                    }
                }
                router.RoutingTable = router.RoutingTable.Except(toRemoveEntries).ToList();
            }
        }
    }
}
