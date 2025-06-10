using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBoardingApp.Models;

namespace PetBoardingApp.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }
        /*
        /Bookings/Create?Pet=3DEC4195-4F7C-46E6-9C1C-E1C82E1535B0&BookingStartTime=2025-05-10T09:00:00&BookingEndTime=2025-05-12T18:00:00&Facility=A6A02726-2C12-4D56-80AF-6FDF85C18CCF&CheckInByEmployeeID=5753150E-9280-4DC0-B688-5DE02471DA5B&CheckedOutByEmployeeID=5753150E-9280-4DC0-B688-5DE02471DA5B&Status=Scheduled&PetInstructions=%22Give%20Buddy%20extra%20playtime%22&FeedingSchedule=%22Twice%20per%20day%22&FoodAmount=%222%20cups%22
        */
        public ActionResult Create(Guid Pet, DateTime BookingStartTime, DateTime BookingEndTime, Guid Facility, BookingStatus Status = BookingStatus.Scheduled, 
            string PetInstructions = null, DateTime? ActualCheckInTime = null, DateTime? ActualCheckOutTime = null, Guid? CheckInByEmployeeID = null, Guid? CheckedOutByEmployeeID = null, 
            string FeedingSchedule = null, string FoodAmount = null)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            if (Pet == null) return Content("Booking must have Pet specified");
            if (BookingStartTime == null) return Content("Booking time needs to be specified");
            if (BookingEndTime == null) return Content("Booking time needs to be specified");
            if (Facility == null) return Content("Facility must be specified");

            if (BookingStartTime >= BookingEndTime) return Content("Error: Booking start time must be BEFORE the end time.");
            if (ActualCheckInTime >= ActualCheckOutTime) return Content("Error: Actual Booking start time must be BEFORE the end time.");

            var overlappingBooking = dbContext.BookingModels.FirstOrDefault(b => b.Pet.PetID == Pet &&
                         ((BookingStartTime >= b.BookingStartTime && BookingStartTime <= b.BookingEndTime) ||
                         (BookingEndTime >= b.BookingStartTime && BookingEndTime <= b.BookingEndTime)));

            if (overlappingBooking != null) return Content("Error: The pet already has a booking during this time.");

            var petModel = dbContext.PetModels.FirstOrDefault(o => o.PetID == Pet);
            if (petModel == null) return Content("Error: PetID not found in the database.");

            var facilityModel = dbContext.FacilityModels.FirstOrDefault(o => o.FacilityID == Facility);
            if (facilityModel == null) return Content("Error: FacilityID not found in the database.");

            var checkinEmployee = dbContext.EmployeeModels.FirstOrDefault(o => o.EmployeeID == CheckInByEmployeeID);
            if (checkinEmployee == null) return Content("Error: EmployeeID not found in the database.");

            var checkoutEmployee = dbContext.EmployeeModels.FirstOrDefault(o => o.EmployeeID == CheckedOutByEmployeeID);
            if (checkinEmployee == null) return Content("Error: EmployeeID not found in the database.");

            BookingModel bookingModel = new BookingModel();

            bookingModel.Pet = petModel;
            bookingModel.BookingStartTime = BookingStartTime;
            bookingModel.BookingEndTime = BookingEndTime;
            bookingModel.Facility = facilityModel;
            bookingModel.Status = Status;
            bookingModel.PetInstructions = PetInstructions;
            bookingModel.ActualCheckInTime = ActualCheckInTime;
            bookingModel.ActualCheckOutTime = ActualCheckOutTime;
            bookingModel.CheckInByEmployeeID = checkinEmployee;
            bookingModel.CheckedOutByEmployeeID = checkoutEmployee;
            bookingModel.FeedingSchedule = FeedingSchedule;
            bookingModel.FoodAmount = FoodAmount;

            dbContext.BookingModels.Add(bookingModel);

            try
            {
                dbContext.SaveChanges();
                return Content("Created Successfully!");
            }

            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }


        public ActionResult Delete(Guid ID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            BookingModel bookingModel = dbContext.BookingModels.FirstOrDefault(x => x.BookingID == ID);

            if (bookingModel != null)
            {
                dbContext.BookingModels.Remove(bookingModel);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return Content("Error: " + ex.Message);
                }
            }
            else
            {
                return Content("BookingID does not exist");
            }

            return Content("Deleted: " + ID);
        }
    }
}