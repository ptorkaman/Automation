using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class ForeignDocumentViewModel
    {
        public int ForeignDocumentID { get; set; }
        [Display(Name = "مشخصات نامه رسان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام و نام خانوادگی نامه رسان وارد نشده است.")]
        public string FullNameDelivery { get; set; }
        [Display(Name = "شماره تماس نامه رسان")]
        public string PhoneNumberDelivery { get; set; }
        [Display(Name = "موضوع سند")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "موضوع سند وارد نشده است.")]
        public string DocumentTitle { get; set; }
        [Display(Name = "متن سند")]
        public string DocumentContent { get; set; }
        [Display(Name = "تصویر سند")]
        public string DocumentImagePath { get; set; }
        [Display(Name = "تاریخ ثبت سند")]
        public DateTime DocumentEnterDate { get; set; }
        [Display(Name = "مرجع ارسال کننده")]
        public string OrgnizationDocumentName { get; set; }
        public string UserID_SaveDocument { get; set; }
        [Display(Name = "واحد ارائه دهنده خدمت")]
        public string UserID_RecieveDocument { get; set; }
        public string DocumentNumber { get; set; }
        public int JobsChartID { get; set; }
        public string JobsChartName { get; set; }
    }
}
