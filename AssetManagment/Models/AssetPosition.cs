using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class AssetPosition
    {
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public string? AssetDesc{ get; set; }
        public int? AssetInv{ get; set; }

        public double? PositionX { get; set; }
        public double? PositionY { get; set; }
       public  DateTime? PositionDate { get; set; }
       
    }
}
