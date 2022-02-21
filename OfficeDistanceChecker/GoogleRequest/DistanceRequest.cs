using Newtonsoft.Json;
using OfficeDistanceChecker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace OfficeDistanceChecker.GoogleRequest
{
    public class DistanceRequest
    {
        public static ResponseContainer GetDistance(string origin, string destination, string departureTime)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            ResponseContainer responseContainer = null;
            WebResponse response = null;

            const string apiKey = "";//Google API Key

            //Control caracter
            if (origin.Contains("\u0095"))
            {
                origin = origin.Replace("\u0095", "");
            }
            if (destination.Contains("\u0095"))
            {
                destination = destination.Replace("\u0095", "");
            }


            string url = String.Format("https://maps.googleapis.com/maps/api/distancematrix/json?departure_time={0}&destinations={1}&origins={2}&units=metric&language=es&mode=transit&region=es&transit_mode=train|tram|subway|bus&transit_routing_preference=less_walking&key={3}",departureTime,destination,origin,apiKey);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";


            try
            {
                response = request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var readerToEnd = reader.ReadToEnd().ToString();
                //Console.WriteLine(readerToEnd);
                try
                {
                    responseContainer = JsonConvert.DeserializeObject<ResponseContainer>(readerToEnd);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }

            return responseContainer;
        }
    }
}
