using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class SentLetters
    {

        [Key]
        public int SentLetterdID { get; set; }
        public int LetterID { get; set; }
        public DateTime SentLetterDate { get; set; }
        public string userId_sender { get; set; }
        public string userId_reciever { get; set; }
        public bool ReadType { get; set; }
        //
        [ForeignKey("userId_reciever")]
        public virtual ApplicationUsers Users_Reciever { get; set; }
        [ForeignKey("LetterID")]
        public virtual Letters Letter { get; set; }

        public bool IsHiddenReciver { get; set; }//رونوشت یا گیرنده مخفی
        public bool IsCopyReciver { get; set; }//رونوشت
    }
}