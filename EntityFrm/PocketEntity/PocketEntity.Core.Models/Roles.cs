using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            this.RolePermission = new HashSet<RolePermission>();
            this.UserRole = new HashSet<UserRole>();
        }

        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public int TenantId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolePermission> RolePermission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}