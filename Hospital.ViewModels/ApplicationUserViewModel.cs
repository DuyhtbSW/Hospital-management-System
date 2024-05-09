using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctors { get; set; }= new List<ApplicationUser>();
        public string Name { get; set; }
        public string Address{ get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public Gender Gender { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }

        public ApplicationUserViewModel() { }
        public ApplicationUserViewModel(ApplicationUser user) {
            Name = user.Name;
            Address= user.Address;
            Gender = user.Gender;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
            Email = user.Email;
            UserName = user.UserName;

        }
        public ApplicationUser ConvertViewModelToModel (ApplicationUserViewModel model)
        {
            return new ApplicationUser
            {
                Name = model.Name,
                Address = model.Address,
                Gender = model.Gender,
                IsDoctor = model.IsDoctor,
                Specialist = model.Specialist,
                Email = model.Email,
                UserName = model.UserName,

            };
        }
       
    }
}
