using System.Collections.Generic;
using System.Linq;
using aoc.api;

namespace aoc.y2015.day9 {

    public class RoutePlanner {

        private IEnumerable<Route> routes;


        public RoutePlanner(string[] routeStrings) {
            routes = CreateRoutes(routeStrings);
        }

        public int GetShortestRouteLength() {
            List<Route> sortedRoutes = GetRoutesSortedMinToMax();
            List<string> locations = GetAllLocationsUsedInRoutes(sortedRoutes.ToArray());
            
            List<Route> neededRoutes = GetAllNeededRoutes(sortedRoutes, locations);

            neededRoutes.RemoveAt(neededRoutes.Count-1);

            return neededRoutes.Aggregate(0, (accu, current) => accu + current.distance);
        }

        public int GetLongestRouteLength() {
            List<Route> sortedRoutes = GetRoutesSortedMaxToMin();
            List<string> lcoations = GetAllLocationsUsedInRoutes(sortedRoutes.ToArray());

            List<Route> neededRoutes = GetAllNeededRoutes(sortedRoutes, lcoations);

            // neededRoutes.RemoveAt(neededRoutes.Count-1);

            return neededRoutes.Aggregate(0, (accu, current) => accu + current.distance);
        }


        private List<Route> GetAllNeededRoutes(List<Route> allRoutes, List<string> allLocations) {
            Dictionary<string, int> locationUses = new Dictionary<string, int>();
            foreach(string location in allLocations) {
                locationUses[location] = 0;
            }
            return allRoutes.AggregatingRemoveNotNeededItems(currentRoute => {
                int useCountLocation1 = locationUses[currentRoute.Location1];
                int useCountLocation2 = locationUses[currentRoute.Location2];
                if(useCountLocation1 < 2 && useCountLocation2 < 2) {
                    locationUses[currentRoute.Location1] = useCountLocation1+1;
                    locationUses[currentRoute.Location2] = useCountLocation2+1;
                    return true;
                }
                return false;
            });
        }

        public List<Route> GetRoutesSortedMinToMax() =>
            routes.OrderBy(route => route.distance).ToList();
        public List<Route> GetRoutesSortedMaxToMin() =>
            routes.OrderByDescending(route => route.distance).ToList();


        private Route[] CreateRoutes(string[] routeStrings) =>
            routeStrings.Select(routeString => new Route(routeString)).ToArray();

        private List<string> GetAllLocationsUsedInRoutes(Route[] routes) =>
            routes.AggregatingAddListsFromInsideListArguments(current => current.Locations).AggregatingRemoveAllDoublings();

    }

}