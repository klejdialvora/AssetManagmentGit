using System;
using System.Collections.Generic;

namespace AssetManagment.Models
{
    public partial class Group
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public byte[]? GroupIcon { get; set; }
    }
}
