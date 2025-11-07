using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class UserPermission
    {
        [Key] public long UserPermissionId { get; set; }
        public int UserId { get; set; }
        public string PermissionKey { get; set; }
        public bool Granted { get; set; }

        public virtual User User { get; set; }
    }
}