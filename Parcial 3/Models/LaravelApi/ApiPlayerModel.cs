using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_3.Models.LaravelApi
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Playerapi
        {
            public int id { get; set; }
            public object created_at { get; set; }
            public object updated_at { get; set; }
            public string name { get; set; }
            public string position { get; set; }
            public int age { get; set; }
        }

}