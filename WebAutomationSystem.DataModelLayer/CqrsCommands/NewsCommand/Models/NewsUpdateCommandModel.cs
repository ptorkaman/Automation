using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.CqrsCommands.NewsCommand.Models
{
    public class NewsUpdateCommandModel : IRequest<int>
    {
        public int NewsID { get; set; }
        [Display(Name = "عنوان خبر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "عنوان خبر وارد نشده است.")]
        public string NewsTitle { get; set; }

        [Display(Name = "متن خبر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "متن خبر وارد نشده است.")]
        public string NewsContent { get; set; }
        [Display(Name = "تاریخ خبر")]
        public DateTime NewsDate { get; set; }
        [Display(Name = "پیوست")]
        public string NewsAttachment { get; set; }
        public string UserID { get; set; }
    }
}
