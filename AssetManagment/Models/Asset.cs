using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class Asset
    {
        public int AssetId { get; set; }
        public string? AssetName { get; set; }
        public string? AssetDesc { get; set; }
        public int? AssetInventoryNumber { get; set; }
        public string AssetTagMacAddress { get; set; }
      //  public virtual ICollection<Tag>? IAsstTag { get; set; }
    }
}
