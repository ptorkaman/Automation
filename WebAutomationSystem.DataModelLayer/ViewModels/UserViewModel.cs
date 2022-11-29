using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class UserViewModel
    {
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

}
