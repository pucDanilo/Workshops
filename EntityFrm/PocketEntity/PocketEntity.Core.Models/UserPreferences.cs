using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class UserPreference
    {
        [Key]
        public int UserPreferenceId { get; set; }

        public long UserId { get; set; }
        public string PreferenceType { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}