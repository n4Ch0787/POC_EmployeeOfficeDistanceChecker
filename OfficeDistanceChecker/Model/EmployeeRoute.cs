using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDistanceChecker.Model
{
    public class EmployeeRoute
    {
        public string Origin { get; set; }
        public string ProcessedOrigin { get; set; }
        public Route OldRoute { get; set; }
        public Route NewRoute { get; set; }
        public bool IsOldRouteShorter { get; set; }
        public bool IsOldRouteFaster { get; set; }

        public EmployeeRoute()
        {
            OldRoute = new Route();
            NewRoute = new Route();
        }

        public class Route
        {
            public DistanceDuration OriginDestination { get; set; }
            public DistanceDuration DestinationOrigin { get; set; }

            public Route()
            {
                OriginDestination = new DistanceDuration();
                DestinationOrigin = new DistanceDuration();
            }
        }

        public class DistanceDuration
        {
            public int? Distance { get; set; }
            public int? Duration { get; set; }
        }

        public void EvaluateRoutes()
        {

            if (OldRoute.OriginDestination.Duration != (int?)null)
            {
                OldRoute.OriginDestination.Duration = OldRoute.OriginDestination.Duration / 60;
                OldRoute.DestinationOrigin.Duration = OldRoute.DestinationOrigin.Duration / 60;
                NewRoute.OriginDestination.Duration = NewRoute.OriginDestination.Duration / 60;
                NewRoute.DestinationOrigin.Duration = NewRoute.DestinationOrigin.Duration / 60;
            }
            if (OldRoute.OriginDestination.Distance < NewRoute.OriginDestination.Distance)
            {
                IsOldRouteShorter = true;
            }
            else
            {
                IsOldRouteShorter = false;
            }

            if (OldRoute.OriginDestination.Duration < NewRoute.OriginDestination.Duration)
            {
                IsOldRouteFaster = true;
            }
            else
            {
                IsOldRouteFaster = false;
            }
        }
    }
}
