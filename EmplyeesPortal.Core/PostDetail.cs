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
  public  class PostDetail:BaseEntity
    {
        public long id { get; set; }
        public long departmentid { get; set; }
        public long postcategoryid { get; set; }

        public long postid { get; set; }
        public string employeeid { get; set; }

        public Boolean is_read { get; set; }
        public Boolean is_understand { get; set; }
        public DateTime first_visit_date { get; set; }
        public DateTime last_visit_date { get; set; }

        [ForeignKey("departmentid")]
        public virtual Department Department { get; set; }

        [ForeignKey("postcategoryid")]
        public virtual PostCategory PostCategory { get; set; }

        [ForeignKey("postid")]
        public virtual Post Post { get; set; }




    }
}
