using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class RolePatternDetails
    {
        [Key]
        public int Id { get; set; }
        public int RolePatternID { get; set; }
        public string RoleID { get; set; }

        [ForeignKey("RolePatternID")]
        public virtual RolePattern RP { get; set; }

        [ForeignKey("RoleID")]

        public virtual ApplicationRoles Roles { get; set; }
    }
}
