using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class Reminder
    {
        [Key]
        public int ReminderID { get; set; }
        public string ReminderTtile { get; set; }
        public string ReminderContent { get; set; }
        public DateTime ReminderCreateDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public bool IsRead { get; set; }
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUsers Users { get; set; }
    }
}