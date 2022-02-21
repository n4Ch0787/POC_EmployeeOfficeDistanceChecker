using OfficeDistanceChecker.Const;
using OfficeDistanceChecker.GoogleRequest;
using OfficeDistanceChecker.Helpers;
using OfficeDistanceChecker.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDistanceChecker.Services
{
    public class RouteService
    {
        public static void Process()
        {
            //Read employee addresses from file
            List<string> employeeList = FileHelper.EmployeeAddressToStringList(FileHelper.ReadCSVFile());

            //Get employee routes from Google API
            List<EmployeeRoute> employeeRoutes = GetEmployeeRoutes(employeeList);

            //Generate results file
            FileHelper.PrintResults(employeeRoutes);

        }

        static List<EmployeeRoute> GetEmployeeRoutes(List<string> employeeList)
        {
            List<EmployeeRoute> employeeRoutes = new List<EmployeeRoute>();
            ResponseContainer route;

            foreach (var eAdress in employeeList)
            {

                //Create new employee adress
                EmployeeRoute eRoute = new EmployeeRoute();
                //Set original  address
                eRoute.Origin = eAdress;


                //From employee home to old work an new work adress

                route = DistanceRequest.GetDistance(eAdress, String.Format("{0}|{1}", ConfigConst.OldAddress, ConfigConst.NewAddress), ConfigConst.TimeToDestination);
                //
                eRoute.OldRoute.OriginDestination.Distance = route.Rows[0].Element[0].Distance != null ? int.Parse(route.Rows[0].Element[0].Distance.Value) : (int?)null;
                eRoute.OldRoute.OriginDestination.Duration = route.Rows[0].Element[0].Duration != null ? int.Parse(route.Rows[0].Element[0].Duration.Value) : (int?)null;

                eRoute.NewRoute.OriginDestination.Distance = route.Rows[0].Element[1].Distance != null ? int.Parse(route.Rows[0].Element[1].Distance.Value) : (int?)null;
                eRoute.NewRoute.OriginDestination.Duration = route.Rows[0].Element[1].Duration != null ? int.Parse(route.Rows[0].Element[1].Duration.Value) : (int?)null;

                //Set returned employee address
                eRoute.ProcessedOrigin = route.Origin[0];

                //From old work adress to employee home
                route = DistanceRequest.GetDistance(String.Format("{0}|{1}",ConfigConst.OldAddress,ConfigConst.NewAddress), eAdress, ConfigConst.TimeFromDestination);

                eRoute.OldRoute.DestinationOrigin.Distance = route.Rows[0].Element[0].Distance != null ? int.Parse(route.Rows[0].Element[0].Distance.Value) : (int?)null;
                eRoute.OldRoute.DestinationOrigin.Duration = route.Rows[0].Element[0].Duration != null ? int.Parse(route.Rows[0].Element[0].Duration.Value) : (int?)null;

                eRoute.NewRoute.DestinationOrigin.Distance = route.Rows[1].Element[0].Distance != null ? int.Parse(route.Rows[1].Element[0].Distance.Value) : (int?)null;
                eRoute.NewRoute.DestinationOrigin.Duration = route.Rows[1].Element[0].Duration != null ? int.Parse(route.Rows[1].Element[0].Duration.Value) : (int?)null;

                //Evaluate distance & duration
                eRoute.EvaluateRoutes();

                employeeRoutes.Add(eRoute);
            }

            return employeeRoutes;
        }




    }
}

//var a = FileHelper.ReadFile();
//DistanceRequest.GetDistance("", "", "");
//FileHelper.CreateFile();
//FileHelper.UpdateFile("");