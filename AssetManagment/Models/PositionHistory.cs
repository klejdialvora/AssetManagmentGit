using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class PositionHistory
    {
        public int PositionID { get; set; } 
        public string? PositionTag { get; set; }
        public double? PositionX { get; set; }
        public double? PositionY { get; set; }
        public DateTime? PositionDate { get; set; }

    }
}
