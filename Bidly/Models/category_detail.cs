using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bidly.Models
{
    public class category_detail
    {
        public int Category_Id { get; set; }
        [Required(ErrorMessage ="category name require")]
        [StringLength(100, ErrorMessage ="Minimum 5 and Maximum 5 charahter are allow", MinimumLength = 3)]
        public string Category_Name { get; set; }
        public Nullable<bool> Is_active { get; set; }
        public Nullable<bool> Is_Delete { get; set; }
    }
    public class product_detail
    {
        public int Product_Id { get; set; }
        [Required(ErrorMessage = "product Name is required")]
        [StringLength(100, ErrorMessage = "Minimum 5 and Maximum 5 charahter are allow", MinimumLength = 3)]
        public string Product_Name { get; set; }
        [Required]
        [Range(1,50)]
        public Nullable<int> Category_Id { get; set; }
        public Nullable<bool> Is_active { get; set; }
        public Nullable<bool> Is_delete { get; set; }
        public Nullable<System.DateTime> Create_date { get; set; }
        public Nullable<System.DateTime> Modified_date { get; set; }
        [Required(ErrorMessage ="Description is required")]
        public Nullable<System.DateTime> Description { get; set; }
        public string Product_image { get; set; }
        public Nullable<bool> Is_featured { get; set; }
        [Required]
        [Range(typeof(int),"1","500",ErrorMessage ="Invalid quantity")]
        public Nullable<int> Quantity { get; set; }
        [Required]
        [Range(typeof(decimal),"1","200000",ErrorMessage ="Invakid price")]
        public Nullable<decimal> Price { get; set; }
        public SelectList Categories { get; set; }
    }
}