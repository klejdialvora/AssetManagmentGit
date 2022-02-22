using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class AssetGroup
    {
        public int AssetGroupId { get; set; }
        public int AssetId { get; set; }
        public int GroupId { get; set; }


        public virtual Asset Asset { get; set; } = null!;
        public virtual Group AssetGroups { get; set; } = null!;
    }
}
