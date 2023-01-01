using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<GroupUser> GroupUsers { get; set; }
    }
}
