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
   public class Post :BaseEntity
    {
        public long id { get; set; }

        [DisplayName("Chapter Name")]
        public string chaptername { get; set; }
        [DisplayName("Chapter Title")]
        public string title { get; set; }
        [DisplayName("Chapter Number")]
        public int chapter_no { get; set; }
        [DisplayName("Search Key Words")]
        public string searchingwords { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("IsActive")]
        public Boolean isactive { get; set; }

        [DisplayName("Department")]
        public long departmentid { get; set; }
        [ForeignKey("departmentid")]
        public virtual Department Department { get; set; }

        [DisplayName("Post Category")]
        public long postcategoryid { get; set; }
        [ForeignKey("postcategoryid")]
      
        public virtual PostCategory PostCategory { get; set; }

    }
}
