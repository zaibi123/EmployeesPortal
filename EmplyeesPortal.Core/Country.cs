using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmplyeesPortal.Core
{
   public class Country:BaseEntity
    {
        public long id { get; set; }

        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(2, ErrorMessage = "Please enter 2 character code.")]
        [DisplayName("Code 2")]
        public string iso { get; set; }

        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(3, ErrorMessage = "Please enter 3 character code.")]
        [DisplayName("Code 3")]
        public String iso3 { get; set; }

        [MaxLength(80)]
        [DisplayName("Country Name")]
        [Required(ErrorMessage = "Country Name Is Required.")]
        public string name { get; set; }


        [MaxLength(80)]
        [DisplayName("Nice Country Name")]
        [Required(ErrorMessage = "Nice Country Name Is Required.")]
        public string nicename { get; set; }


        [DisplayName("Country Code")]
        public Int16? numcode { get; set; }

        [DisplayName("Country Phone Code")]
        public Int16? phonecode { get; set; }
    }
}
