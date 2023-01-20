using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Curdoperations.Models
{
    public class resModel
    {
        public int ReservationId { get; set; }
        public string Hotel { get; set; }
        public string Arrival { get; set; }
        public Nullable<System.DateTime> Departure { get; set; }
        public string Type { get; set; }
        public Nullable<int> Guest { get; set; }
        public Nullable<int> Price { get; set; }
    }
}