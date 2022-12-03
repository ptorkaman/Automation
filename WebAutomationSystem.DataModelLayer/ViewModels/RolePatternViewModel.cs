using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class RolePatternViewModel
    {
        public int Id { get; set; }
        [Display(Name = "عنوان نقش کاربری")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "لطفا {0} وارد نمایید.")]
        public string RolePatternName { get; set; }
        [Display(Name = "توضیحات")]
        public string RolePatternDescription { get; set; }
    }
}
