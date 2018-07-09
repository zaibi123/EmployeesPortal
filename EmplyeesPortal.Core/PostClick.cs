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
    public class PostClickCount:BaseEntity
    {
        public long id { get; set; }
        public long postid { get; set; }

        public string postclickby { get; set; }

        public string postclickdate { get; set; }

        [ForeignKey("postid")]
        public virtual Post Post { get; set; }

    }
}
