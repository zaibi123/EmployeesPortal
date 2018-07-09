using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace EmployeesPortal.Web.Models
{
    public class UploadImagesVM
    {
        public long id { get; set; }
        [DisplayName("Upload images")]
        public HttpPostedFileBase images { get; set; }
    }
}