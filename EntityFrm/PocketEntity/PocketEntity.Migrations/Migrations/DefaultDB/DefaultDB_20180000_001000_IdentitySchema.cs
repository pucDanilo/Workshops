using FluentMigrator;
using System;

namespace PocketEntity.Migrations.DefaultDB
{
    [Migration(20180000001000)]
    public class DefaultDB_20180000_001000_IdentitySchema : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("AspNetRole").WithColumn("Id").AsString().NotNullable().PrimaryKey("PK_AspNetRole")
                    .WithColumn("ConcurrencyStamp").AsString()
                    .WithColumn("Name").AsString(256)
                    .WithColumn("NormalizedName").AsString(256)
                    .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                    .WithColumn("Description").AsString()
                    .WithColumn("IPAddress").AsString()
                    ;

            Create.Table("AspNetUserTokens")
                .WithColumn("UserId").AsString().NotNullable()
                .WithColumn("LoginProvider").AsString().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Value").AsString();

            Create.PrimaryKey("PK_AspNetUserTokens").OnTable("AspNetUserTokens").Columns(new string[] { "UserId", "LoginProvider", "Name" });

            Create.Table("AspNetUser").WithColumn("Id").AsString().NotNullable().PrimaryKey("PK_AspNetUser")
                .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("ConcurrencyStamp").AsString()
                .WithColumn("Email").AsString(256)
                .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                .WithColumn("LockoutEnd").AsDateTimeOffset()
                .WithColumn("NormalizedEmail").AsString(256)
                .WithColumn("NormalizedUserName").AsString(256)
                .WithColumn("PasswordHash").AsString()
                .WithColumn("PhoneNumber").AsString()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
                .WithColumn("SecurityStamp").AsString()
                .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                .WithColumn("UserName").AsString(256)
                .WithColumn("Name").AsString(256);

            Create.Table("AspNetRoleClaims")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("PK_AspNetRoleClaims").Identity()
                .WithColumn("ClaimType").AsString()
                .WithColumn("ClaimValue").AsString()
                .WithColumn("RoleId").AsString().NotNullable();
            Create.Table("AspNetUserClaims")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("PK_AspNetUserClaims").Identity()
                .WithColumn("ClaimType").AsString()
                .WithColumn("ClaimValue").AsString()
                .WithColumn("UserId").AsString().NotNullable();
            Create.Table("AspNetUserLogins")
                .WithColumn("LoginProvider").AsString().NotNullable()
                .WithColumn("ProviderKey").AsString().NotNullable()
                .WithColumn("ProviderDisplayName").AsString()
                .WithColumn("UserId").AsString().NotNullable();

            Create.PrimaryKey("PK_AspNetUserLogins").OnTable("AspNetUserLogins").Columns(new string[] { "LoginProvider", "ProviderKey" });

            Create.Table("AspNetUserRole")
                .WithColumn("UserId").AsString().NotNullable()
                .WithColumn("RoleId").AsString().NotNullable();
            Create.PrimaryKey("PK_AspNetUserRole").OnTable("AspNetUserRole").Columns(new string[] { "UserId", "RoleId" });

            Create.ForeignKey("FK_AspNetUserLogins_AspNetUser_UserId").FromTable("AspNetUserLogins").ForeignColumn("UserId")
                .ToTable("AspNetUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_AspNetUserClaims_AspNetUser_UserId").FromTable("AspNetUserClaims").ForeignColumn("UserId")
                .ToTable("AspNetUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_AspNetRoleClaims_AspNetRole_RoleId").FromTable("AspNetRoleClaims").ForeignColumn("RoleId")
                .ToTable("AspNetRole").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_AspNetUserTokens_AspNetUser_UserId").FromTable("AspNetUserTokens").ForeignColumn("UserId")
                .ToTable("AspNetUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_AspNetUserRole_AspNetRole_RoleId").FromTable("AspNetUserRole").ForeignColumn("RoleId")
                .ToTable("AspNetRole").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_AspNetUserRole_AspNetUser_UserId").FromTable("AspNetUserRole").ForeignColumn("UserId")
                .ToTable("AspNetUser").PrimaryColumn("Id").OnDelete(System.Data.Rule.Cascade);

            Create.Index("RoleNameIndex").OnTable("AspNetRole").OnColumn("NormalizedName");

            Create.Index("IX_AspNetRoleClaims_RoleId").OnTable("AspNetRoleClaims").OnColumn("RoleId");

            Create.Index("IX_AspNetUserClaims_UserId").OnTable("AspNetUserClaims").OnColumn("UserId");

            Create.Index("IX_AspNetUserLogins_UserId").OnTable("AspNetUserLogins").OnColumn("UserId");

            Create.Index("IX_AspNetUserRole_RoleId").OnTable("AspNetUserRole").OnColumn("RoleId");
            Create.Index("IX_AspNetUserRole_UserId").OnTable("AspNetUserRole").OnColumn("UserId");
            Create.Index("EmailIndex").OnTable("AspNetUser").OnColumn("NormalizedEmail");
            Create.Index("UserNameIndex").OnTable("AspNetUser").OnColumn("NormalizedUserName").Unique();
        }
    }
}