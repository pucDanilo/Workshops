using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Permissions;

namespace PocketEntity.Services
{
    public sealed class ConfigType
    {
        // private members
        private int[] contaCorrenteIds;
        private int tenantId;

        private string nome;

        // Constructors
        public ConfigType()
        {
        }

        public ConfigType(int TenantId, string Nome)
        {
            this.tenantId = TenantId;
            this.nome = Nome;
        }

        // Public properties
        [DataMember] public int TenantId { get { return this.tenantId; } set { this.tenantId = value; } }

        [DataMember] public int[] ContaCorrenteIds { get { return this.contaCorrenteIds; } set { this.contaCorrenteIds = value; } }
        [DataMember] public string Nome { get { return this.nome; } set { this.nome = value; } }
        public Claim[] GetClaim()
        {
            return new Claim[]
            {
                new Claim("TenantId", this.tenantId.ToString()),
                new Claim(ClaimTypes.Name, this.Nome),
                new Claim(ClaimTypes.UserData, string.Join(',' , this.contaCorrenteIds)),
            };
        }
    }
}