using System;
using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class VersionInfo
    {
        [Key] public long Version { get; set; }
        public Nullable<System.DateTime> AppliedOn { get; set; }
        public string Description { get; set; }
    }
}