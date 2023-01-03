using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class UserJob
    {
        [Key]
        public int UserJobID { get; set; }
        public string UserID { get; set; }
        public int JobID { get; set; }
        public DateTime StartJobDate { get; set; }
        public DateTime EndJobDate { get; set; }
        public bool IsHaveJob { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUsers Users { get; set; }

        [ForeignKey("JobID")]
        public virtual JobsChart Jobs { get; set; }
    }
}