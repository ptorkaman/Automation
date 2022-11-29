using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
   public class ReminderViewModel
    {
        public int ReminderID { get; set; }


        [Display(Name = "عنوان یادآوری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        public string ReminderTtile { get; set; }


        [Display(Name = "متن یادآوری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        public string ReminderContent { get; set; }

        public DateTime ReminderCreateDate { get; set; }
        
        [Display(Name = "تاریخ یادآوری")]
        public DateTime ReminderDate { get; set; }
        [Display(Name = "وضعیت خواندن")]
        public bool IsRead { get; set; }
        public string UserID { get; set; }
    }
}
