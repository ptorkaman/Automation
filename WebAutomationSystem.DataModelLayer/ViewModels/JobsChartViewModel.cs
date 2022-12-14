using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class JobsChartViewModel
    {
        [Display(Name = "نام شغل")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "لطفا نام شغل را وارد نمایید")]
        public string JobsChartName { get; set; }

        [Display(Name = "توضیحات")]
        public string JobsChartDescription { get; set; }
        public int JobsChartLevel { get; set; }

        public int JobsChartId { get; set; }
    }

    public class JobsChartWithUserInfoViewModel
    {
        public int JobsChartID { get; set; }
        public string JobsChartName { get; set; }
        public int JobsChartLevel { get; set; }
        public string FirstName { get; set; }
        public string Family { get; set; }
    }

}
