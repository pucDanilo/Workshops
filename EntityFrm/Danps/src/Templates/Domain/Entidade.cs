using System;
using {DOMAIN};

namespace {NOME_NAMESPACE}
{
    public class {NOME_CLASSE}: {INTERFACE} 
    {
        {CAMPOS}

        protected {NOME_CLASSE}() { }
        public {NOME_CLASSE}({PARAMETRO_CONSTRUTOR})
        {
            {CONSTRUTOR}
        }
 
        public void Validar()
        { 
            Validacoes.ValidarSeIgual(Id, Guid.Empty, "O campo Id do produto não pode estar vazio"); 
        }
    }
}