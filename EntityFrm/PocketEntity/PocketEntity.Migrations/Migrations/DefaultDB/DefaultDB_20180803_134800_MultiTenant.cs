using FluentMigrator;

namespace PocketEntity.Migrations.DefaultDB
{/*
    public class ConvertHex
    {
        public static byte[] HexStringToByteArray(string hexString)
        {
            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
    }
    */

    [Migration(20180803134800)]
    public class DefaultDB_20180803_134800_MultiTenant
        : AutoReversingMigration
    {
        public override void Up()
        {
            string password = "123";
            byte[] passwordHash;
            byte[] passwordSalt;
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            this.CreateTableWithId32("Tenant", "TenantId", s => s
                .WithColumn("TenantName").AsString(100).NotNullable()
                .WithColumn("PasswordHash").AsBinary(256).Nullable()
                .WithColumn("PasswordSalt").AsBinary(256).Nullable()
            );
            Insert.IntoTable("Tenant")
                .Row(new
                {
                    TenantName = "danps",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });

            Insert.IntoTable("Tenant")
                .Row(new
                {
                    TenantName = "foobar",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });

            Insert.IntoTable("Tenant")
                .Row(new
                {
                    TenantName = "bob",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                });

            Alter.Table("User")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);

            Alter.Table("Role")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);

            Alter.Table("Language")
                .AddColumn("TenantId").AsInt32()
                    .NotNullable().WithDefaultValue(1);
        }
    }
}