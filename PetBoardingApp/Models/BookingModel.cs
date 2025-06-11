using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PetBoardingApp.Models
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
        public PetModel Pet { get; set; }
        [MaxLength(1000)]
        public string PetInstructions { get; set; }
        [Required]
        public DateTime BookingStartTime { get; set; }
        [Required]
        public DateTime BookingEndTime { get; set; }

        public DateTime? ActualCheckInTime { get; set; }

        public DateTime? ActualCheckOutTime { get; set; }

        public EmployeeModel CheckInByEmployeeID { get; set; } 

        public EmployeeModel CheckedOutByEmployeeID { get; set; } 
        [Required]
        public FacilityModel Facility { get; set; }
        [Required]
        public BookingStatus Status { get; set; }
        [MaxLength(100)]
        public string FeedingSchedule { get; set; }
        [MaxLength(100)]
        public string FoodAmount { get; set; }

        public BookingModel()
        {
            BookingID = Guid.NewGuid();
            Status = BookingStatus.Scheduled;
        }

    }
}