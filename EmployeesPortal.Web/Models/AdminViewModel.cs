using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
namespace EmployeesPortal.Web.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required.")]
        [DisplayName("First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required.")]
        [DisplayName("Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }

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
      
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}