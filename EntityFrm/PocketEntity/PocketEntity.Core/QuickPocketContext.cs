using Danps.Core.Models;
using Microsoft.EntityFrameworkCore;
using PocketEntity.Core.Models;

namespace PocketEntity.Core
{
    public class QuickPocketContext : DbContext
    {
        public QuickPocketContext(DbContextOptions<QuickPocketContext> options, IUserInfo UserInfo)
            : base(options)
        {
        }

        public virtual DbSet<ContaCorrente> ContaCorrente { get; set; }
        public virtual DbSet<ContraCheque> ContraCheque { get; set; }
        public virtual DbSet<Exceptions> Exceptions { get; set; }
        public virtual DbSet<ExtratoTitulo> ExtratoTitulo { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Pregao> Pregao { get; set; }
        public virtual DbSet<Protocolo> Protocolo { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Titulo> Titulo { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<UserPreference> UserPreference { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VersionInfo> VersionInfo { get; set; }
    }
}