using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebAutomationSystem.DataModelLayer.Entities
{
   public class JobsChart
    {
        [Key]
        public int JobsChartID { get; set; }
        public string JobsChartName { get; set; }
        public string JobsChartDescription { get; set; }
        public int JobsChartLevel { get; set; }

    }
}
