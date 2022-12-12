using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime NewsDate { get; set; }
        public string NewsAttachment { get; set; }
        public string UserID { get; set; }
        
        public bool flag { get; set; }
        //
        [ForeignKey("UserID")]
        public virtual ApplicationUsers User { get; set; }
    }
}