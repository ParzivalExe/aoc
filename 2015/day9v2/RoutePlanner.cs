using System.Collections.Generic;
using System.Linq;
using System;
using aoc.api;

namespace aoc.y2015.day9v2 {

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
            //Get general shortest route (maybe there aren't all locations used)
            List<Route> routes = new List<Route>();
            routes = allRoutes.AggregatingRemoveNotNeededItems(currentRoute => {
                int useCountLocation1 = locationUses[currentRoute.Location1];
                int useCountLocation2 = locationUses[currentRoute.Location2];
                if(useCountLocation1 < 2 && useCountLocation2 < 2) {
                    locationUses[currentRoute.Location1] = useCountLocation1+1;
                    locationUses[currentRoute.Location2] = useCountLocation2+1;
                    return true;
                }
                return false;
            });
            //Change route so that all locations are used
            Dictionary<string, int> locationsNotUsedEnough = new Dictionary<string, int>();
            foreach(string location in locationUses.Keys) {
                locationsNotUsedEnough[location] = 2 - locationUses[location];
            }
            foreach(string location in locationsNotUsedEnough.Keys) {
                switch(locationsNotUsedEnough[location]) {
                    case 2: {
                        IEnumerable<Route> routesOfLocation = GetRoutesWithLocation(allRoutes, location);
                        /*#TODO */
                        break;
                    }
                    case 1: {
                        /*#TODO */
                        break;
                    }
                }
            }
            return null; /*#TODO */
        }


        private bool RouteConnectsLocation(Route route, string location) =>
            route.Location1.Equals(location) || route.Location2.Equals(location);

        public List<Route> GetRoutesSortedMinToMax() =>
            routes.OrderBy(route => route.distance).ToList();
        public List<Route> GetRoutesSortedMaxToMin() =>
            routes.OrderByDescending(route => route.distance).ToList();


        private Route[] CreateRoutes(string[] routeStrings) =>
            routeStrings.Select(routeString => new Route(routeString)).ToArray();

        private List<string> GetAllLocationsUsedInRoutes(Route[] routes) =>
            routes.AggregatingAddListsFromInsideListArguments(current => current.Locations).AggregatingRemoveAllDoublings();

        private IEnumerable<Route> GetRoutesWithLocation(List<Route> routes, string location) {
            return routes.AggregatingRemoveNotNeededItems(route => RouteConnectsLocation(route, location));
        }

        private (Route detour1, Route detour2) GetShortestTwoRouteDetour(List<Route> detourOptions, Route oldRoute) {
            return detourOptions
                .Aggregate(
                    (detour1: detourOptions.ElementAt(0), detour2: detourOptions.ElementAt(1)), 
                    (accu, current) => /*WORK MUST BE CONTIUED #TODO */(null, null));
        }

        private Route GetMinRoute(Route route1, Route route2) =>
            (route1.distance <= route2.distance) ? route1 : route2;

        private string GetOtherLocationFromRoute(Route route, string locationToIgnore) =>
            (route.Location1.Equals(locationToIgnore)) ? route.Location2 : route.Location1;

    }

}