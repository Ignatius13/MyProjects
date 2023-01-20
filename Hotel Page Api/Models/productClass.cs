using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Curdoperations.Models
{
    public class productClass
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> MobileNo { get; set; }
        public string EmailId { get; set; }

        
    }
}