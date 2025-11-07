using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class RolePermission
    {
        [Key]
        public long RolePermissionId { get; set; }

        public int RoleId { get; set; }
        public string PermissionKey { get; set; }

        public virtual Role Role { get; set; }
    }
}