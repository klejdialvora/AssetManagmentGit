using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class AssetsInGroups
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }

        public IEnumerable<Asset>? assets { get; set; } = null;
    }
}
