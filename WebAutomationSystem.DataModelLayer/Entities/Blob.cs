using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class Blob: BaseClass<long>
    {

        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public long BlobDescriptionId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedById { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CategoryId { get; set; }
        public BlobDescription BlobDescription { get; set; }
        public Category Category { get; set; }
        public BlobStream BlobStream { get; set; }
    }
}
