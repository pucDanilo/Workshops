using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.UserPermission = new HashSet<UserPermission>();
            this.UserRole = new HashSet<UserRole>();
        }

        [Key]
        public int UserId { get; set; }

        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Nullable<System.DateTime> LastDirectoryUpdate { get; set; }
        public string UserImage { get; set; }
        public System.DateTime InsertDate { get; set; }
        public int InsertUserId { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public short IsActive { get; set; }
        public int TenantId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPermission> UserPermission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}