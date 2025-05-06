using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public class PetModel
    {
        [Key]
        public Guid PetID { get; set; }
        [Required]
        public PetOwnerModel OwnerID { get; set; }
        [Required]
        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string Vaccines { get; set; }

        public string Medications { get; set; }

        public string ExtraNotes { get; set; }

        public List<BookingModel> Bookings { get; set; }
        public PetModel()
        {
            PetID = Guid.NewGuid();
            Bookings = new List<BookingModel>();
        }

    }
}