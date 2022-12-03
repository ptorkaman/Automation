using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class LettersViewModel
    {
        public int LetterID { get; set; }

        [Display(Name = "متن نامه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} وارد نمایید.")]
        [MinLength(5, ErrorMessage = "متن نامه باید حداقل 5 کاراکتر باشد.")]
        public string LetterContent { get; set; }

        [Display(Name = "موضوع نامه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} وارد نمایید.")]
        [StringLength(maximumLength: 300, MinimumLength = 8, ErrorMessage = "موضوع نامه بایستی حداقل 8 و حداکثر 300 کاراکتر باشد.")]
        public string LetterSubject { get; set; }
        //فوریت نامه
        [Display(Name = "فوریت")]
        public byte ImmediatellyStatus { get; set; }
        //طبقه بندی نامه
        [Display(Name = "طبقه بندی")]
        public byte ClassificationStatus { get; set; }
        //پیوست
        [Display(Name = "پیوست")]
        public byte AttachmentStatus { get; set; }
        //درخواست پاسخ
        [Display(Name = "تقاضای پاسخ")]
        public byte ReplyStatus { get; set; }
        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }
        [Display(Name = "تاریخ پاسخ")]
        public string ReplyDate { get; set; }
        public string UserID { get; set; }
        [Display(Name = "تاریخ نامه")]
        public DateTime LetterCreateDate { get; set; }
    }
}