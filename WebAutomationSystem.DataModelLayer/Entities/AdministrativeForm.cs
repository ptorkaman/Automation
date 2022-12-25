using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class AdministrativeForm
    {
        [Key]
        public int Id { get; set; }
        public bool AdministrativeFormType { get; set; }
        public string AdministrativeFormTitle { get; set; }
        public string AdministrativeFormContent { get; set; }
        public string UserID { get; set; }
        public int SecretariatTypeId { get; set; }
        public SecretariatType SecretariatType { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUsers User { get; set; }


       
    }
}