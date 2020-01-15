using MVCExam.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code Field is required..")]
        [RegularExpression(@"^\d+$(\.\d+)?", ErrorMessage = "Only Positive numaric values are allow")]
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Member Member { get; set; }
        public int MemberId { get; set; }

        public Food Food { get; set; }
        public int FoodId { get; set; }


        public List<Order> Orders { get; set; }
        public List<SelectListItem> MemberCodeSelectListItems { get; set; }
        public List<SelectListItem> FoodItemSelectListItems { get; set; }
    }
}