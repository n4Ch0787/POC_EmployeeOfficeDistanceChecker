using Newtonsoft.Json;
using OfficeDistanceChecker.GoogleRequest;
using OfficeDistanceChecker.Helpers;
using OfficeDistanceChecker.Model;
using OfficeDistanceChecker.Services;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace OfficeDistanceChecker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            RouteService.Process();

        }
    }
}
