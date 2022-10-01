using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_3.Models.player
{
    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string abbr { get; set; }
        public Logos logos { get; set; }
    }

    public class Logos
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class Root
    {
        public bool status { get; set; }
        public List<Datum> data { get; set; }
    }

}