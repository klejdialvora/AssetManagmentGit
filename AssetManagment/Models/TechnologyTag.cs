using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class TechnologyTag
    {
        public string TagId { get; set; } = null!;
        public int TechnologyId { get; set; }

        public virtual Tag Tag { get; set; } = null!;
        public virtual TechnologyType Technology { get; set; } = null!;
    }
}
