using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class ReferralLetters
    {
        [Key]
        public int ReferralLettersID { get; set; }
        public int LetterID { get; set; }
        //کاربر ایجاد کننده نامه
        public string mainUserID { get; set; }
        //کاربر ارجاع دهنده نامه
        public string ReferUserID { get; set; }
        //کاربر دریافت کننده ارجاع
        public string RecieveReferUserID { get; set; }

        public DateTime ReferDate { get; set; }
        public bool ReadType { get; set; }
        public string Description { get; set; }
        //
        [ForeignKey("LetterID")]
        public virtual Letters Letters { get; set; }
        [ForeignKey("mainUserID")]
        public virtual ApplicationUsers Users_main { get; set; }
        [ForeignKey("ReferUserID")]
        public virtual ApplicationUsers Users_ReferUserId { get; set; }
        [ForeignKey("RecieveReferUserID")]
        public virtual ApplicationUsers Users_RecieveUserId { get; set; }
    }
}
