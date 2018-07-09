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
   public class Comments:BaseEntity
    {
        public long id { get; set; }
        [DisplayName("Comment")]
        public string comment { get; set; }

        public long postid { get; set; }

        [ForeignKey("postid")]
        public virtual Post post { get; set; }

        public string commentbyUserId { get; set; }

        public string commentbyUserName { get; set; }
        public DateTime commentDate { get; set; }

        
    }
}
