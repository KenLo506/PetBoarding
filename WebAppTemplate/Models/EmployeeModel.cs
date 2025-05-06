using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppTemplate.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid EmployeeID { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Role { get; set; }
        public DateTime ShiftCheckIn { get; set; }
        public DateTime ShiftCheckOut { get; set; }
        [Required]
        public FacilityModel FacilityID { get; set; }
        public EmployeeModel()
        {
            EmployeeID = Guid.NewGuid();
        }
    }
}