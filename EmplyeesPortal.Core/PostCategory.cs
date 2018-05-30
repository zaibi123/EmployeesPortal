using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace EmplyeesPortal.Core
{
  public   class PostCategory:BaseEntity
    {
        public long id { get; set; }
        [DisplayName("Category Name")]
        public string name { get; set; }
        [DisplayName("IsActive")]
        public Boolean isactive { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
