using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
{
    public class FacilityModel
    {
        [Key]
        public Guid FacilityID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FacilityName { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public int MaxOccupancy { get; set; }

        public List<BookingModel> Bookings { get; set; }

        public List<EmployeeModel> Employees { get; set; }

        public FacilityModel()
        {
            FacilityID = Guid.NewGuid();
            Bookings = new List<BookingModel>();
        }
    }
}