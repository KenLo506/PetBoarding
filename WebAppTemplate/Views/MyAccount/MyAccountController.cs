using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            return View();
        }

        //MyAccount/Create?Fullname=John&Email=john123@gmail.com&Phone=1234567890&EmergencyContact=0987654321
        public ActionResult Create(string FullName, string Email, string Phone, string EmergencyContact)
        {       
            ApplicationDbContext dbContext = new ApplicationDbContext();

            PetOwnerModel ownerModel = new PetOwnerModel();

            ownerModel.FullName = FullName;
            ownerModel.Email = Email;
            ownerModel.Phone = Phone;
            ownerModel.EmergencyContact = EmergencyContact;
            
            dbContext.PetOwnerModels.Add(ownerModel);
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
    }
}