using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class Notation
    {
        [Key]
        public int NotationID { get; set; }
        public string NotationTitle { get; set; }
        public string NotationContent { get; set; }
        public DateTime NotationDate { get; set; }
        public string UserID_Creator { get; set; }
        public string UserID_Reciever { get; set; }
        //
        [ForeignKey("UserID_Creator")]
        public virtual ApplicationUsers User_Creator { get; set; }
        [ForeignKey("UserID_Reciever")]
        public virtual ApplicationUsers User_Reciever { get; set; }
    }
}
