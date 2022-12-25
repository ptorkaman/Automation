using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class CartableUserViewModel
    {
        [Display(Name = "کاربر")]
        public string UserId { get; set; }
        [Display(Name = "کارتابل")]
        public int CartableId { get; set; }
        public int Id { get; set; }

    }



}
