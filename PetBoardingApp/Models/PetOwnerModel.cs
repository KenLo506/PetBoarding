using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class PetOwnerModel
    {
        [Key]
        public Guid OwnerID { get; set; } // PK
        [Required]
        public string FullName { get; set; }
        [MaxLength(1000)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(10)]
        public string EmergencyContact { get; set; }

        public List<PetModel> Pets { get; set; }

        public PetOwnerModel()
        {
            OwnerID = Guid.NewGuid();
            Pets = new List<PetModel>();    
        }

    }
}