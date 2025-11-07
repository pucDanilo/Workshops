using Danps.My.Domain.Models;

namespace Danps.ConsoleApp.Bancos
{
    public static class EXEMPLO_GITHUB_TEMPLATE
    {
        public static object MODELO = new
        {
            Titulo = "NET Core ",
            Descricao = "Projeto de api ",
            Usuario = "psdanilo",
            Projeto = "AppHourControl"
        };

        public static MyModelo TEMPLATE => new MyModelo
        {
            Nome = "GitHub Template",
            Mensagem = @"
# {NOME_PROJETO}

{PROJETO_DESCRICAO}

![GitHub repo size](https://img.shields.io/github/repo-size/{GIT_USUARIO}/{GIT_PROJETO}?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/{GIT_USUARIO}/{GIT_PROJETO}?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/{GIT_USUARIO}/{GIT_PROJETO}?style=for-the-badge)
![Bitbucket open issues](https://img.shields.io/bitbucket/issues/{GIT_USUARIO}/{GIT_PROJETO}?style=for-the-badge)
![Bitbucket open pull requests](https://img.shields.io/bitbucket/pr-raw/{GIT_USUARIO}/{GIT_PROJETO}?style=for-the-badge)

> Linha adicional de texto informativo sobre o que o projeto faz. Sua introdução deve ter cerca de 2 ou 3 linhas. Não exagere, as pessoas não vão ler.

## Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:
<!---Estes são apenas requisitos de exemplo. Adicionar, duplicar ou remover conforme necessário--->
* Você instalou a versão mais recente de `<linguagem / dependência / requeridos>`
* Você tem uma máquina `<Windows / Linux / Mac>`. Indique qual sistema operacional é compatível / não compatível.
* Você leu `<guia / link / documentação_relacionada_ao_projeto>`.

## Instalando <nome_do_projeto>

Para instalar o <nome_do_projeto>, siga estas etapas:

Windows:
```
<comando_de_instalação>
```

## Veja o desenvolvimento do projeto:

Para ver o desenvolvimento acesse o planejamento:

[![Github](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/{GIT_USUARIO}/{GIT_PROJETO})

## 🔖 Licensa
[![LICENSA](https://img.shields.io/badge/Custom_GPL_3.0-E58080?style=for-the-badge&logo=bookstack&logoColor=white)](/LICENSE)

<p align=""center"">Copyright © 2021 {GIT_USUARIO}</p>
",
            Tags = new MyTag[]
            {
                new MyTag{ Token = "{NOME_PROJETO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Titulo"}},
                new MyTag{ Token = "{PROJETO_DESCRICAO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Descricao"}},
                new MyTag{ Token = "{GIT_USUARIO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Usuario"}},
                new MyTag{ Token = "{GIT_PROJETO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Projeto"}},
            }
        };
    }
}