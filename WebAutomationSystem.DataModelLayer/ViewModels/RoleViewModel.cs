using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
   public class RoleViewModel
    {
        [Display(Name =  "نام انگلیسی دسترسی")]
        [Required (AllowEmptyStrings = false, ErrorMessage = "لطفا {0} وارد نمایید.")]
        public string Name { get; set; }

        [Display(Name = "نام فارسی دسترسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} وارد نمایید.")]
        public string Description { get; set; }

        public string RoleLevel { get; set; }
    }
}
