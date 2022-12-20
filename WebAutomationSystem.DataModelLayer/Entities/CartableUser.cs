using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class CartableUser 
    {
        public string UserId { get; set; }
        public int CartableId { get; set; }
        public int Id { get; set; }
    }
}
