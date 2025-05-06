using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public enum BookingStatus
    {
        Scheduled,
        CheckedIn,
        CheckedOut,
        Canceled
    }
    public class BookingModel
    {
        [Key]
        public Guid BookingID { get; set; }
        [Required]
        public PetModel PetID { get; set; }

        public string PetInstructions { get; set; }

        public DateTime BookingStartTime { get; set; }

        public DateTime BookingEndTime { get; set; }

        public DateTime? ActualCheckInTime { get; set; }

        public DateTime? ActualCheckOutTime { get; set; }

        public EmployeeModel CheckInByEmployeeID { get; set; } 

        public EmployeeModel CheckedOutByEmployeeID { get; set; } 

        public FacilityModel FacilityID { get; set; } 

        public BookingStatus Status { get; set; }

        public string FeedingSchedule { get; set; }

        public string FoodAmount { get; set; }

        public BookingModel()
        {
            BookingID = Guid.NewGuid();
            Status = BookingStatus.Scheduled;
        }

    }
}