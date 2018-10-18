using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class EditContactsViewModel
    {
        [Display(Name = "Contact No")]
        [Required]
        public string ContactNo { get; set; }

        [Display(Name = "Type")]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Person ID")]
        public int PersonId { get; set; }

        [Display(Name = "Contact ID")]
        public int ContactId { get; set; }
    }
}