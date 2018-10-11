using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class CreatePersonModel
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string HomeAddress { get; set; }

        public string HomeCity { get; set; }

        public string FacebookAccountId { get; set; }

        public string LinkedInId { get; set; }

        public string TwitterId { get; set; }

        public string EmailId { get; set; }

        public string ImagePath { get; set; }

    }
}
