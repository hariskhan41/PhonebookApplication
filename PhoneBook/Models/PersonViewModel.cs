using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PersonViewModel
    {
        [Display(Name = "Person ID")]
        public int PersonId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Display(Name ="Added On")]
        public System.DateTime AddedOn { get; set; }

        [Display(Name = "Added By")]
        public string AddedBy { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Home City")]
        public string HomeCity { get; set; }

        [Display(Name = "Facebook ID")]
        public string FaceBookAccountId { get; set; }

        [Display(Name = "LinkedIn ID")]
        public string LinkedInId { get; set; }

        [Display(Name = "Updated On")]
        public Nullable<System.DateTime> UpdateOn { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [Display(Name = "Twitter ID")]
        public string TwitterId { get; set; }

        [Display(Name = "Email ID")]
        public string EmailId { get; set; }
    }
}