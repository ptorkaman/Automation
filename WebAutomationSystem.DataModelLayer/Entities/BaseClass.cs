using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class BaseClass<T>
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? LastModifiedById { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
