using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class Letters
    {
        [Key]
        public int Id { get; set; }
        public string LetterContent { get; set; }
        public string LetterSubject { get; set; }
        //فوریت نامه
        public byte ImmediatellyStatus { get; set; }
        //طبقه بندی نامه
        public byte ClassificationStatus { get; set; }
        //پیوست
        public bool AttachmentStatus { get; set; }
        //درخواست پاسخ
        public bool ReplyStatus { get; set; }
        //آدرس فایل پیوست
        public string LetterAttachamentFile { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string UserID { get; set; }
        public DateTime LetterCreateDate { get; set; }

        //
        [ForeignKey("UserID")]
        public virtual ApplicationUsers Users { get; set; }
    }
}