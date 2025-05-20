using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;
using WebAppTemplate.ViewModels;

namespace WebAppTemplate.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs

        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactUsSubmissionVM());
        }

        [HttpPost]
        public ActionResult Index(ContactUsSubmissionVM contactUsVM)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ContactUsModel contactModel = new ContactUsModel();

            if (string.IsNullOrEmpty(contactUsVM.Name)) {
                return Content("Name Is required");
            }

            if (string.IsNullOrEmpty(contactUsVM.Email))
            {
                return Content("Email Is required");
            }

            if (string.IsNullOrEmpty(contactUsVM.Message))
            {
                return Content("Message Is required");
            }

            contactModel.Name = contactUsVM.Name;
            contactModel.Email = contactUsVM.Email;
            contactModel.Message = contactUsVM.Message;

            dbContext.ContactUsModels.Add(contactModel);
            try
            {
                dbContext.SaveChanges();
                return View("ContactUsSuccessful");
            }

            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }

        public ActionResult ContactUsSuccessful()
        {
            return View();
        }

    }
}