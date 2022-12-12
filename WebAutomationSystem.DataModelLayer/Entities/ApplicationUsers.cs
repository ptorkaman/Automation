using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class ApplicationUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string PersonalCode { get; set; }
        public string MelliCode { get; set; }
        public string Address { get; set; }
        //public string BirthDayDate { get; set; }
        public DateTime BirthDayDateMilladi { get; set; }
        public byte Gender { get; set; }
        public string ImagePath { get; set; }
        public string SignaturePath { get; set; }
        public byte IsActive { get; set; }
        public DateTime RegisterDate { get; set; }

        //1 = Admin    2 = User
        public byte IsAdmin { get; set; }
        public long? BlobDescriptionId { get; set; }
        public BlobDescription BlobDescription { get; set; }

        public long? BlobDescriptionSignatureId { get; set; }
        public BlobDescription BlobDescriptionSignature { get; set; }
    }
}
