using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Views.Facility
{
    public class FacilityController : Controller
    {
        // GET: Facility
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string FacilityName, string Address, int MaxOccupancy)
        {
            if (FacilityName == null) return Content("Facility must have Name");
            ApplicationDbContext dbContext = new ApplicationDbContext();
            FacilityModel facilityModel = new FacilityModel();

            facilityModel.FacilityName = FacilityName;
            facilityModel.Address = Address;
            facilityModel.MaxOccupancy = MaxOccupancy;


            dbContext.FacilityModels.Add(facilityModel);
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

            FacilityModel facilityModel = dbContext.FacilityModels.FirstOrDefault(x => x.FacilityID == ID);

            if (facilityModel != null)
            {
                dbContext.EmployeeModels.RemoveRange(facilityModel.Employees);
                dbContext.FacilityModels.Remove(facilityModel);
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
                return Content("FacilityID does not exist");
            }

            return Content("Deleted: " + ID);
        }

    }
}