using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class ForeignDocument
    {
        [Key]
        public int ForeignDocumentID { get; set; }
        public string FullNameDelivery { get; set; }
        public string PhoneNumberDelivery { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentContent { get; set; }
        public string DocumentImagePath { get; set; }
        public DateTime DocumentEnterDate { get; set; }
        public string OrgnizationDocumentName { get; set; }
        public string UserID_SaveDocument { get; set; }
        public string UserID_RecieveDocument { get; set; }
        public string DocumentNumber { get; set; }
        public int JobsChartID { get; set; }
        //
        [ForeignKey("UserID_SaveDocument")]
        public virtual ApplicationUsers User_SaveDocument { get; set; }
        [ForeignKey("UserID_RecieveDocument")]
        public virtual ApplicationUsers User_RecieveDocument { get; set; }
        [ForeignKey("JobsChartID")]
        public virtual JobsChart JobsChart { get; set; }
    }
}