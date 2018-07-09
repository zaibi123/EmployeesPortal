using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmplyeesPortal.Core;
namespace EmployeesPortal.Web.Models
{
    public class PostCommentVM
    {
        public long id { get; set; }
        [DisplayName("Comment")]
        public string comment { get; set; }

        public long postid { get; set; }

        public string commentby { get; set; }

        public DateTime commentDate { get; set; }

        public Post Post { get; set; }

        public IList<Comments> commentlist { get; set; }


    }
}