using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _24dentistasdelisboa.Models
{
    public class ContactFormViewModel
    {
        [Required]
        public string ContactName { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]

        public string ContactPhoneNumber { get; set; }

        public string ContactMessage { get; set; }

        public int ReturnPageId { get; set; }

        public int ThankYouPageId { get; set; }
    }
}