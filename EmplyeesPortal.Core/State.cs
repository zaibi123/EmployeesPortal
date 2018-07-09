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
  public  class State:BaseEntity
    {
        public long id { get; set; }
        [Required(ErrorMessage = "State Name Is Required.")]
        [MaxLength(40)]
        [DisplayName("State Name")]
        public string name { get; set; }

        [MaxLength(2)]
        [DisplayName("Abbreviation")]
        public string abbreviation { get; set; }
        [Required(ErrorMessage = "Country Is Required.")]
        [DisplayName("Country")]
        public long countryid { get; set; }

        [DisplayName("Country")]
        [ForeignKey("countryid")]
        public virtual Country Country { get; set; }
    }
}
