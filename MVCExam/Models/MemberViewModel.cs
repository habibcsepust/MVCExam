using MVCExam.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExam.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Code Field is required..")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code Must be 4 digit length..")]
        public string Code { get; set; }
        [Required(ErrorMessage = "The Name Field is required..")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Field Must be Required")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contact Field Must be Required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact Field Required Exact 11 Digit Length.")]
        public string ContactNo { get; set; }
        public MemberType MemberType { get; set; }
        public int MemberTypeId { get; set; }

        
        public List<Member> Members { get; set; }
        public List<SelectListItem> MemberSelectListItems { get; set; }
        public List<SelectListItem> MemberTypeSelectListItems { get; set; }
    }
}