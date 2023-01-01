using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer.ViewModels
{
    public class GroupUserViewModel
    {
        [Display(Name = "کاربر")]
        public string UserId { get; set; }
        [Display(Name = "گروه")]
        public int GroupId { get; set; }
        public int Id { get; set; }

    }



}
