using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmplyeesPortal.Core
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [DisplayName("First Name*")]
        [MaxLength(100)]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [DisplayName("Last Name*")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName
        {
            get
            {
                string fullname = FirstName + " " + LastName;
                return fullname;
            }
        }

        public string Address { get; set; }

        [DisplayName("City Name")]
        [MaxLength(100)]
        public string City { get; set; }

        [DisplayName("State Name")]
        public long? StateId { get; set; }

        [DisplayName("Country Name")]
        public long? CountryId { get; set; }

        [DisplayName("Zip")]
        [MaxLength(20)]
        public string Zip { get; set; }

        [DisplayName("Phone")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [DisplayName("Mobile")]
        [MaxLength(20)]
        public string Mobile { get; set; }

        [DisplayName("Profile Image")]
        [MaxLength(255)]
        public string ProfileImage { get; set; }
      
        [DisplayName("Status")]
        public bool isactive { get; set; }
    }
}