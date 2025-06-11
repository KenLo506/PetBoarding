using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class PetModel
    {
        [Key]
        public Guid PetID { get; set; }
        [Required]
        public PetOwnerModel Owner { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Breed { get; set; }

        public int Age { get; set; }
        [MaxLength(100)]
        public string Vaccines { get; set; }
        [MaxLength(100)]
        public string Medications { get; set; }
        [MaxLength(500)]
        public string ExtraNotes { get; set; }
        public virtual List<BookingModel> Bookings { get; set; }

        public PetModel()
        {
            PetID = Guid.NewGuid();
            Bookings = new List<BookingModel>();
        }

    }
}