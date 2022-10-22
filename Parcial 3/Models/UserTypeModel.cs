using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_3.Models
{
    public class UserTypeModel
    {
        public int id_type { get; set; }
        public string name_type { get; set; }
        public string description { get; set; }
        public int active { get; set; }
    }
}