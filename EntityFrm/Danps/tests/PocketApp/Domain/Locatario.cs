using PocketApp.Core.DomainObjects;
using System;

namespace PocketApp.Domain
{
    public class Locatario : Entity
    {
        public string Nome { get; private set; }
        public Guid Token { get; private set; }

        protected Locatario()
        {
        }

        public Locatario(string nome)
        {
            Nome = nome;
            Token = Guid.NewGuid();
        }
    }
}