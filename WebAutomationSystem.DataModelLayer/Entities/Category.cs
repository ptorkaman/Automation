using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public int CreatedById { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime CreatedOn { get; set; }

        public int? LastModifiedById { get; set; }

        [Display(Name = "تاریخ ویرایش")]
        public DateTime? LastModifiedOn { get; set; }
        public string Title { get; set; }
    }
}
