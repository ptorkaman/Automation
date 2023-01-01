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

        //نوع نامه  
        [Display(Name = "نوع نامه")]
        public byte SecretriantLetterType { get; set; }

        //گیرندگان   
        [Display(Name = "گیرندگان نامه")]
        public List<int> Recievers { get; set; }

        //گروه   
        [Display(Name = "گروه دریافت کننده نامه ")]
        public int? GroupId { get; set; }

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

        public byte LetterType { get; set; }
        public int MainLetterID { get; set; }

        [Display(Name = "دبیرخانه")]
        [Required( ErrorMessage = "لطفا {0} وارد نمایید.")]
        public int SecretariatTypeId { get; set; }
    }

    public class LettersListViewModel
    {
        public int LetterID { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        //فوریت نامه
        //1 عادی
        //2 فوری
        //3 آنی
        public byte ImmediatellyStatus { get; set; }
        public string ImmediatellyStatusText { get; set; }
        //طبقه بندی نامه
        //1 عادی
        //2 محرمانه
        //3 فوق محرمانه
        public byte ClassificationStatus { get; set; }
        public string ClassificationStatusText { get; set; }
        //پیوست
        //1 دارد
        //0 ندارد
        public bool AttachmentStatus { get; set; }
        public string AttachmentStatusText { get; set; }
        //درخواست پاسخ
        //1 دارد
        //0 ندارد
        public bool ReplyStatus { get; set; }
        public string ReplyStatusText { get; set; }
        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string UserID { get; set; }
        public DateTime LetterCreateDate { get; set; }

        public byte LetterType { get; set; }
        public int MainLetterID { get; set; }
    }

    public class MyLetterViewModel
    {
        public int LetterID { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        //فوریت نامه
        //1 عادی
        //2 فوری
        //3 آنی
        public byte ImmediatellyStatus { get; set; }
        public string ImmediatellyStatusText { get; set; }
        //طبقه بندی نامه
        //1 عادی
        //2 محرمانه
        //3 فوق محرمانه
        public byte ClassificationStatus { get; set; }
        public string ClassificationStatusText { get; set; }
        //پیوست
        //1 دارد
        //0 ندارد
        public bool AttachmentStatus { get; set; }
        public string AttachmentStatusText { get; set; }
        //درخواست پاسخ
        //1 دارد
        //0 ندارد
        public bool ReplyStatus { get; set; }
        public string ReplyStatusText { get; set; }
        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }
        public DateTime? ReplyDate { get; set; }

        //آیدی ارسال کننده نامه
        public string UserID_Sender { get; set; }
        public string UserID_Reciever { get; set; }
        //تاریخ ارسال نامه
        public DateTime LetterSentDate { get; set; }
        public string FirstName_Sender { get; set; }
        public string Family_sender { get; set; }
        public string FullName_sender { get; set; }
        public string UserName_sender { get; set; }
        public bool ReadType { get; set; }
        public string ReadTypeText { get; set; }
        public string LetterNumber { get; set; }

        public byte LetterType { get; set; }
        public int MainLetterID { get; set; }
    }

    public class SentLetterViewModel
    {
        public int LetterID { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        //فوریت نامه
        //1 عادی
        //2 فوری
        //3 آنی
        public byte ImmediatellyStatus { get; set; }
        public string ImmediatellyStatusText { get; set; }
        //طبقه بندی نامه
        //1 عادی
        //2 محرمانه
        //3 فوق محرمانه
        public byte ClassificationStatus { get; set; }
        public string ClassificationStatusText { get; set; }
        //پیوست
        //1 دارد
        //0 ندارد
        public bool AttachmentStatus { get; set; }
        public string AttachmentStatusText { get; set; }
        //درخواست پاسخ
        //1 دارد
        //0 ندارد
        public bool ReplyStatus { get; set; }
        public string ReplyStatusText { get; set; }
        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }
        public DateTime? ReplyDate { get; set; }

        //آیدی ارسال کننده نامه
        public string UserID_Sender { get; set; }
        //تاریخ ارسال نامه
        public DateTime LetterSentDate { get; set; }
        public string FirstName_Reciever { get; set; }
        public string Family_Reciever { get; set; }
        public string FullName_Reciever { get; set; }
        public string UserName_Reciever { get; set; }
        public string LetterNumber { get; set; }

        public byte LetterType { get; set; }
        public int MainLetterID { get; set; }
    }

    public class ReferLetterViewModel
    {
        public int LetterID { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        //فوریت نامه
        //1 عادی
        //2 فوری
        //3 آنی
        public byte ImmediatellyStatus { get; set; }
        public string ImmediatellyStatusText { get; set; }
        //طبقه بندی نامه
        //1 عادی
        //2 محرمانه
        //3 فوق محرمانه
        public byte ClassificationStatus { get; set; }
        public string ClassificationStatusText { get; set; }
        //پیوست
        //1 دارد
        //0 ندارد
        public bool AttachmentStatus { get; set; }
        public string AttachmentStatusText { get; set; }

        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }

        //تاریخ ارسال نامه
        public DateTime LetterReferDate { get; set; }
        public string LetterNumber { get; set; }

        //مشخصات دریافت کننده ارجاع
        public ReferLetterUserInfo UserInfo_RecievedRefer { get; set; }
        //مشخصات ایجاد کننده نامه
        public ReferLetterUserInfo UserInfo_Creator { get; set; }
    }

    public class RecievedReferLetterViewModel
    {
        public int LetterID { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        //فوریت نامه
        //1 عادی
        //2 فوری
        //3 آنی
        public byte ImmediatellyStatus { get; set; }
        public string ImmediatellyStatusText { get; set; }
        //طبقه بندی نامه
        //1 عادی
        //2 محرمانه
        //3 فوق محرمانه
        public byte ClassificationStatus { get; set; }
        public string ClassificationStatusText { get; set; }
        //پیوست
        //1 دارد
        //0 ندارد
        public bool AttachmentStatus { get; set; }
        public string AttachmentStatusText { get; set; }

        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }

        //تاریخ دریافت ارجاع
        public DateTime LetterrecievedReferDate { get; set; }
        public string LetterNumber { get; set; }

        //مشخصات ارسال کننده ارجاع
        public ReferLetterUserInfo UserInfo_Refer { get; set; }
        //مشخصات ایجاد کننده نامه
        public ReferLetterUserInfo UserInfo_Creator { get; set; }
    }

    public class ReferLetterUserInfo
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}