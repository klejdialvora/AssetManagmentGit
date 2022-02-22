using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class Tag
    {
        public string TagMacAddress { get; set; } = null!;
        public int? TagInventoryNumber { get; set; }
        public int? TagBatteryStatus { get; set; }
       
    }
}
