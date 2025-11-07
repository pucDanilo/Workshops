using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class UserRole
    {
        [Key]
        public long UserRoleId { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}