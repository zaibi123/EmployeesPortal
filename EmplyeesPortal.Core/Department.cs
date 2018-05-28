using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplyeesPortal.Core
{
    public class Department:BaseEntity
    {
        public long id { get; set; }
        [DisplayName("Department Name")]
        public string name { get; set; }
        [DisplayName("IsActive")]
        public Boolean isactive { get; set; }
    }
}
