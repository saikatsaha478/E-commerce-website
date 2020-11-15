using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bidly.Models
{
    public class shippingdetail
    {
        public int Shipping_details_id { get; set; }
        [Required]
        public Nullable<int> Member_id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Zip_code { get; set; }
        public Nullable<int> Order_id { get; set; }
        public Nullable<decimal> Amount_paid { get; set; }
        [Required]
        public string Payment_type { get; set; }
    }
}