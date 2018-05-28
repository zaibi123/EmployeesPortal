using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeesPortal.Core
{
    public class BaseEntity
    {
        [DisplayName("Created Date")]
        public DateTime createdonutc { get; set; }

        [DisplayName("Last Updated Date")]
        public DateTime? updatedonutc { get; set; }

        [MaxLength(20)]
        [DisplayName("IP Used")]
        public string ipused { get; set; }

        [MaxLength]
        [DisplayName("Last Updated By")]
        public string userid { get; set; }
    }
}
