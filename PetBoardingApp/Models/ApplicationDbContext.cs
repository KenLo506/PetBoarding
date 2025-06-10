using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetBoardingApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<PetModel> PetModels { get; set; }
        public DbSet<BookingModel> BookingModels { get; set; }
        public DbSet<FacilityModel> FacilityModels { get; set; }
        public DbSet<PetOwnerModel> PetOwnerModels { get; set; }
        public DbSet<ContactUsModel> ContactUsModels { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        
    }
}