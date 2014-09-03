using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public partial class S_Province
    {
        [Required(ErrorMessage="必须的")]
        [Display(Name = "ProvinceID", ResourceType = typeof(Resources.Resource))]
        public long ProvinceID { get; set; }
        [Required(ErrorMessage="必须的")]
        [Display(Name = "ProvinceName",ResourceType=typeof(Resources.Resource))]

        public string ProvinceName { get; set; }
        [Display(Name = "DateCreated", ResourceType = typeof(Resources.Resource))]
        public Nullable<System.DateTime> DateCreated { get; set; }
        [Display(Name = "DateUpdated", ResourceType = typeof(Resources.Resource))]
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}