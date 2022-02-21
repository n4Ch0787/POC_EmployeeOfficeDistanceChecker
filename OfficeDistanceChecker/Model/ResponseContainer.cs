using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeDistanceChecker.Model
{
    public class ResponseContainer
    {
        [JsonProperty("destination_addresses")]
        public List<string> Destination { get; set; }

        [JsonProperty("origin_addresses")]
        public List<string> Origin { get; set; }

        [JsonProperty("rows")]
        public List<Elements> Rows { get; set; }
    }

    public class Elements
    {
        [JsonProperty("elements")]
        public List<Element> Element {get;set;}
    }

    public class Element
    {
        [JsonProperty("distance")]
        public TextValueString Distance { get; set; }
        [JsonProperty("duration")]
        public TextValueString Duration { get; set; }
    }


    public class TextValueString
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
