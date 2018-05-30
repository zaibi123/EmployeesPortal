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
    public class NewsFeed:BaseEntity
    {
        public long id { get; set; }

        public long departmentid { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("IsActive")]
        public Boolean isactive { get; set; }

        [ForeignKey("departmentid")]
        public virtual Department Department { get; set; }
    }
}
