using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebAppTemplate.Models
{
    public class ContactUsModel
    {
        [Key]
        public Guid ContactUsID { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public ContactUsModel()
        {
            ContactUsID = Guid.NewGuid();
        }
    }
}