using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class ApplicationRoles : IdentityRole
    {
        public string RoleLevel { get; set; }
        public string Description { get; set; }
    }
}
