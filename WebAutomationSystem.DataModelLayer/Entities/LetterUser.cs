using System;
using System.Collections.Generic;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class LetterUser
    {
        public int Id { get; set; }
        public int LetterId { get; set; }
        public string UserId { get; set; }
        public ApplicationUsers User { get; set; }

        public bool IsRead { get; set; }
    }
}
