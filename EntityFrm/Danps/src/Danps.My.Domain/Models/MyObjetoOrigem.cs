
namespace Danps.My.Domain.Models
{
    public class MyObjetoOrigem
    {
        public string Nome { get; set; }
        public string Propriedade { get; set; }

        public override string ToString()
        {
            return $"{Nome}_{Propriedade}";

        }
        public override bool Equals(object obj)
        { 

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
             
            return ToString().Equals(obj.ToString());
        } 
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}