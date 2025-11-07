using System.ComponentModel.DataAnnotations;

namespace PocketEntity.Core.Models
{
    public partial class Tenant
    {
        [Key]
        public int TenantId { get; set; }
        public string TenantName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}