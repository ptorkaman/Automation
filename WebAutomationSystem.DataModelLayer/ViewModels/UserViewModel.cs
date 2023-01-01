using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class UserViewModel
    {
        public bool SignaturePermission { get; set; }

        public long? BlobDescriptionSignatureId { get; set; }
        public string BlobDescriptionSignatureSaveId { get; set; }

        public BlobDescription BlobDescriptionSignature { get; set; }

        public long? BlobDescriptionId { get; set; }
        public string BlobDescriptionSaveId { get; set; }
        public BlobDescription BlobDescription { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<IFormFile> SignFiles { get; set; }
        public string Id { get; set; }

        [Display(Name = "نام")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "{0} باید حداقل 2 و حداکثر 100 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [StringLength(maximumLength: 250, MinimumLength = 2, ErrorMessage = "{0} باید حداقل 2 و حداکثر 250 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        public string Family { get; set; }

        [Display(Name = "کدپرسنلی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [MinLength(10, ErrorMessage = "{0} باید 10 رقمی باشد")]
        [MaxLength(10 , ErrorMessage = "{0} باید 10 رقمی باشد")]
        public string PersonalCode { get; set; }

        [Display(Name = "کدملی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [MinLength(10, ErrorMessage = "{0} باید 10 رقمی باشد")]
        [MaxLength(10, ErrorMessage = "{0} باید 10 رقمی باشد")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "فرمت {0} صحیح نیست.")]
        public string MelliCode { get; set; }

        [Display(Name = "آدرس")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "{0} وارد نشده است.")]
        public string Address { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime? BirthDayDateMilladi { get; set; }

        [Display(Name = "جنسیت")]
        public byte Gender { get; set; }
        [Display(Name = "نوع")]
        public byte IsAdmin { get; set; }

        [Display(Name = "تصویر")]
        public string ImagePath { get; set; }
        [Display(Name = "امضا")]
        public string SignaturePath { get; set; }

        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false,ErrorMessage = "{0} وارد نشده است.")]
        [EmailAddress(ErrorMessage ="فرمت صحیح {0} رعایت نشده است.")]
        public string Email { get; set; }

        [Display(Name = "موبایل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [MinLength(11, ErrorMessage = "{0} باید 11 رقمی باشد")]
        [MaxLength(11, ErrorMessage = "{0} باید 11 رقمی باشد")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "فرمت {0} صحیح نیست.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} وارد نشده است.")]
        [StringLength(maximumLength: 40, MinimumLength = 4, ErrorMessage = "{0} باید حداقل 4 و حداکثر 40 کاراکتر باشد.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        public string UserName { get; set; }

        //public byte IaActive { get; set; }
        //public DateTime RegisterDate { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "نام کاربری وارد نشده است")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "از کاراکترهای غیرمجاز استفاده نکنید.")]
        public string UserName { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "رمز عبور وارد نشده است")]
        public string Password { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Display(Name = "رمز عبور قدیمی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "رمز عبور قدیمی وارد نشده است")]
        public string OldPassword { get; set; }


        [Display(Name = "رمز عبور جدید")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "رمز عبور جدید وارد نشده است")]
        [StringLength(maximumLength: 30, MinimumLength = 4, ErrorMessage = "رمز عبور باید حداقل 4 و حداکثر 30 کاراکتر باشد")]
        public string NewPassword { get; set; }


        [Display(Name = "تکرار رمز عبور جدید")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "تکرار رمز عبور وارد نشده است")]
        [Compare("NewPassword", ErrorMessage = "تکرار رمز عبور با رمز عبور جدید یکسان نیست")]
        public string ConfirmNewPassword { get; set; }
    }

    public class ChangePasswordByAdminViewModel
    {
        [Display(Name = "رمز عبور جدید")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار رمز عبور جدید")]
        public string ConfirmNewPassword { get; set; }

        public string  userId { get; set; }
    }

    public class UserFullNameViewModel
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
    }

    public class UserWithJobNameViewModel
    {
        public string UserID { get; set; }
        public string UserFullNameWithJob { get; set; }
        public int JobId { get;  set; }
    }
}
