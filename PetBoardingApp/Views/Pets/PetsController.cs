using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security.Provider;
using PetBoardingApp.Models;

namespace PetBoardingApp.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }
        ///Pets/Create?Name=Bob&Breed=Shiba&Age=8&Vaccines=None&Medications=HeartGuard&ExtraNotes=needsbrush&OwnerID=CF0ED4EA-305E-4179-B6F9-F306B2B03517
        public ActionResult Create(string Name, Guid OwnerID, string Breed = null, int Age = 0, string Vaccines = null, string Medications = null, string ExtraNotes = null )
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            if (string.IsNullOrWhiteSpace(Name)) return Content("Pet must have Name");

            if (OwnerID == null) return Content("Pet must have Owner");

            var ownerModel = dbContext.PetOwnerModels.FirstOrDefault(o => o.OwnerID == OwnerID);

            if (ownerModel == null)
            {
                return Content("Error: OwnerID not found in the database.");
            }

            PetModel petModel = new PetModel();

            petModel.Name = Name;   
            petModel.Breed = Breed;
            petModel.Age = Age;
            petModel.Vaccines = Vaccines;
            petModel.Medications = Medications;
            petModel.ExtraNotes = ExtraNotes;
            petModel.Owner = ownerModel;

            dbContext.PetModels.Add(petModel);

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
        //Pets/Read?ID=C0941407-535C-471D-8E27-7FDB0A5EB251
        public ActionResult Read(Guid ID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetModel petModel = dbContext.PetModels.Include("Owner").FirstOrDefault(x => x.PetID == ID);//explicitly load owner

            if (petModel == null)
            {
                return Content("No Pet with this Id");
            }

            string ownerIDres = petModel.Owner != null ? petModel.Owner.OwnerID.ToString() : "No Owner Assigned";
            //string ownerIDres =  petModel.OwnerID.OwnerID.ToString();

            return Content("Pet Id: " + petModel.PetID + " Pet Name: " + petModel.Name + " Pet Owner ID: " + ownerIDres + " Pet Breed: " + petModel.Breed +
                " Pet Age: " + petModel.Age + " Vaccines: " + petModel.Vaccines + " Medications: " + petModel.Medications +
                " Extra Notes: " + petModel.ExtraNotes);
        }
        //Pets/Delete?ID=C0941407-535C-471D-8E27-7FDB0A5EB251
        public ActionResult Delete(Guid ID)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetModel petModel = dbContext.PetModels.FirstOrDefault(x => x.PetID == ID);

            if (petModel != null)
            {
                dbContext.BookingModels.RemoveRange(petModel.Bookings);
                dbContext.PetModels.Remove(petModel);
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
                return Content("PetID does not exist");
            }

            return Content("Deleted: " + ID);
        }
        //public ActionResult Edit(Guid ID, int )
        //{
        //    ApplicationDbContext dbContext = new ApplicationDbContext();

        //}
    }
}