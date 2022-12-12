using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class BlobDescription : BaseClass<long>
    {
        public string Description { get; set; }
        
        public IList<Blob> Blobs { get; set; }
    }
}
