using System.Collections.Generic;
using System.Linq;
using aoc.api;

namespace aoc.y2015.day9v2 {

    public class RoutePlanner {

        
        public Route[] routes {get; private set;}

        public RoutePlanner(string[] routes) {
            this.routes = CreateRoutes(routes);
        }

        public int GetShortestRouteLength() {
            List<string> locations = GetAllLocationsUsedInRoutes(routes);
            List<Route> sortedRoutes = SortRoutesFromMinToMax(this.routes);

            string currentLocation = GetLocationWithSmallerRoute(sortedRoutes[0]);
            List<Route> usedRoutes = new List<Route>();
            List<string> usedLocations = new List<string>();
            while(usedLocations.Count <= locations.Count) {
                Route shortestRoute = SortRoutesFromMinToMax(GetRoutesOfLocation(sortedRoutes, currentLocation).ToArray())[0];
                usedLocations.Add(currentLocation);
                string newLocation = GetOtherLocationFromRoute(shortestRoute, currentLocation);
                if(!usedLocations.Contains(newLocation)) {
                    //This way is possible and must be saved
                    usedRoutes.Add(shortestRoute);
                    currentLocation = newLocation;
                    continue;
                }else{
                    //This way is not possible, because the position we are landing on is already used!
                    sortedRoutes.Remove(shortestRoute);
                    continue;
                }
            }
            return usedRoutes.Aggregate(0, (accu, current) => accu + current.distance);
        }

        private List<Route> GetRoutesOfLocation(List<Route> routes, string location) =>
            routes.AggregatingRemoveNotNeededItems(route => RouteConnectsLocation(route, location));

        private bool RouteConnectsLocation(Route route, string location) =>
            route.Location1.Equals(location) || route.Location2.Equals(location);

        private List<Route> SortRoutesFromMinToMax(Route[] routes) =>
            routes.OrderBy(route => route.distance).ToList();

        private List<string> GetAllLocationsUsedInRoutes(Route[] routes) =>
            routes.AggregatingAddListsFromInsideListArguments(current => current.Locations).AggregatingRemoveAllDoublings();

        private string GetLocationWithSmallerRoute(Route routeOfLocations) {
            List<Route> routesLoc1 = SortRoutesFromMinToMax(GetRoutesOfLocation(routes.ToList(), routeOfLocations.Location1).ToArray());
            List<Route> routesLoc2 = SortRoutesFromMinToMax(GetRoutesOfLocation(routes.ToList(), routeOfLocations.Location2).ToArray());
            routesLoc1.Remove(routeOfLocations);
            routesLoc2.Remove(routeOfLocations);
            return (routesLoc1[0].distance > routesLoc2[0].distance) ? routeOfLocations.Location1 : routeOfLocations.Location2;
        }

        private string GetOtherLocationFromRoute(Route route, string locationToIgnore) =>
            (route.Location1.Equals(locationToIgnore)) ? route.Location2 : route.Location1;

        private Route[] CreateRoutes(string[] routesString) =>
            routesString.Select(routeString => new Route(routeString)).ToArray();


    }

}