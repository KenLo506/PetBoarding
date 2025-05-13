using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Views.Employee
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(string FullName, Guid Facility, DateTime ShiftCheckIn, DateTime ShiftCheckOut, string Role = null)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            EmployeeModel employeeModel = new EmployeeModel();

            var facilityModel = dbContext.FacilityModels.FirstOrDefault(o => o.FacilityID == Facility);
            if (facilityModel == null) return Content("Error: FacilityID not found in the database.");

            employeeModel.FullName = FullName;
            employeeModel.Facility = facilityModel;
            employeeModel.Role = Role;
            employeeModel.ShiftCheckIn = ShiftCheckIn;
            employeeModel.ShiftCheckOut = ShiftCheckOut;


            dbContext.EmployeeModels.Add(employeeModel);
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

            EmployeeModel employeeModel = dbContext.EmployeeModels.FirstOrDefault(x => x.EmployeeID == ID);

            if (employeeModel != null)
            {
                dbContext.EmployeeModels.Remove(employeeModel);
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
                return Content("EmployeeID does not exist");
            }

            return Content("Deleted: " + ID);
        }
    }
}