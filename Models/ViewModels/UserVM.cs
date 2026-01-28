using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce3.Models.ViewModels
{
    public class UserVM
    {
        public UserVM()
        {
            Roles = new List<Role>()
            {
                new Role{Id=-1,Name="Select Role"},
                new Role{Id=1,Name="Admin"},
                new Role{Id=2,Name="Customer"},
                new Role{Id=3,Name="Vendor"},
                new Role{Id=4,Name="CustomerCare"},
            };
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is a Required Field")]
        [MinLength(4, ErrorMessage = "Name Should be  atleast 4 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a Required Field")]
        [RegularExpression(@"\w+@\w+\.\w{2,3}", ErrorMessage = "Email is Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "DOB is a Required Field")]
        public DateTime DOB { get; set; }


        [Required(ErrorMessage = "Mobile is a Required Field")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Gender is a Required Field")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Password is a Required Field")]
        public string password { get; set; }

        [Required(ErrorMessage = "Role is a Required Field")]
        public short RoleId { get; set; }

        public int Status { get; set; }


        public IEnumerable<Role> Roles { get; set; }


    }
    public class Role
    {
        public short Id { get; set; }
        public string Name { get; set; }
    }
}
