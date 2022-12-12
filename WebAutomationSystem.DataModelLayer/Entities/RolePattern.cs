﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
    public class RolePattern
    {
        [Key]
        public int RolePatternID { get; set; }

        public string RolePatternName { get; set; }
        public string RolePatternDescription { get; set; }
    }
}
