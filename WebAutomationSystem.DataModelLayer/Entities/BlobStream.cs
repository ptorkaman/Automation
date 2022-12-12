using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class BlobStream : BaseClass<long>
    {
       
        public byte[] File { get; set; }
        public Blob Blob { get; set; }
        public long BlobId { get; set; }
        
    }
}
