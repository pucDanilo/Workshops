using Danps.Core.Models;
using Danps.Core.Services;
using Microsoft.AspNetCore.Mvc;
using PocketEntity.Core;
using PocketEntity.Core.Models;
using PocketEntity.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace PocketEntity.Services.Controllers
{
    public class Hero
    {
        public int id;
        public string name;
    }
    [Route("api/[controller]")]
    public class HeroesController : WebAPIControllerBase
    {
        private IApiValueService ApiValueService;

        public HeroesController(QuickPocketContext context) : base(context)
        {
            this.ApiValueService = new ApiValueService();
        }
        [HttpGet]
        public Hero[] Get()
        {
            var heroes = new Hero[]
            {
                new Hero { id= 11, name= "Mr. Nice" },
                new Hero { id= 12, name= "Narco" },
                new Hero { id= 13, name= "Bombasto" },
                new Hero { id= 14, name= "Celeritas" },
                new Hero { id= 15, name= "Magneta" },
                new Hero { id= 16, name= "RubberMan" },
                new Hero { id= 17, name= "Dynama" },
                new Hero { id= 18, name= "Dr IQ" },
                new Hero { id= 19, name= "Magma" },
                new Hero { id= 20, name= "Tornado" }
            };
            return heroes;
        }
         
        [HttpGet("{id}")]
        public Hero Get(int id)
        {
            return Get().FirstOrDefault(a=>a.id == id);
        }
         
        [HttpPost] public void Post([FromBody]string value) { }         
        [HttpPut("{id}")] public void Put(int id, [FromBody]string value) { }
        [HttpDelete("{id}")] public void Delete(int id) { }
    }


        [Route("api/[controller]")]
    public class ValuesController : WebAPIControllerBase
    {
        private IApiValueService ApiValueService;

        public ValuesController(QuickPocketContext context) : base(context)
        {
            this.ApiValueService = new ApiValueService();
        }

        /*
         *
                //[{"label":"Qual ambiente de banco de dados: ","required":"true","value":{"label":"Produção","value":1},"options":[{"label":"Produção","value":1},{"label":"Homologação","value":2},{"label":"Desenvolvimento","value":3},{"label":"Qualidade","value":4}]},{"label":"Nome do servidor/instância:","value":""},{"label":"Nome do banco de dados:","value":""},{"label":"Agendamento do JOB (informações sobre quando o JOB será executado)","value":"","checkbox":[{"label":"Todos os dias (nesse caso, não marque as próximas opções)","value":"false"},{"label":"Segunda-feira","value":"false"},{"label":"Terça-feira","value":"false"},{"label":"Quarta-feira","value":"false"},{"label":"Quinta-feira","value":"false"},{"label":"Sexta-feira","value":"false"},{"label":"Sábado","value":"false"},{"label":"Domingo","value":"false"}]},{"label":"JOB Mensal: [informar dia/mês - ou não se aplica]","value":"Não se aplica"},{"label":"JOB Anual : [informar dia/mês - ou não se aplica]","value":"Não se aplica"},{"label":"Horário de execução: [essa informação é uma referência, a equipe de banco de dados irá verificar se é possível executar o JOB no horário estipulado ou não]","value":""},{"label":"Observação: [informar dados relevantes do JOB, tais como arquivos de scripts anexados, deve ser executado antes/após a execução de outro JOB, etc.]","value":""}]
                //[{"label":"Qual ambiente de banco de dados: ","required":"true","options":[{"label":"Produção","value":1},{"label":"Homologação","value":2},{"label":"Desenvolvimento","value":3},{"label":"Qualidade","value":4}]},{"label":"Nome do servidor/instância:","value":""},{"label":"Nome do login:","value":""},{"label":"Banco de dados padrão do login:","value":""},{"label":"Tipo de permissão: ","value":"","checkbox":[{"label":"Leitura","value":"false"},{"label":"Escrita","value":"false"},{"label":"Exclusão","value":"false"},{"label":"Execução","value":"false"},{"label":"Database owner (dono do banco de dados)","value":"false"}]},{"label":"Observação: [informar dados relevantes do JOB, tais como arquivos de scripts anexados, deve ser executado antes/após a execução de outro JOB, etc.]","value":""}]

        $scope.Objetos.Teste = [{ "label": "Nome do servidor/instância", "obrigatorio": "required", "value": "" }, { "label": "Nome do banco de dados a ser criado", "value": "" }];
        $scope.Objetos.Teste1 = [{ "label": "Ambiente de banco de dados", "required": "true", "value": "", "options": [{ "label": "Produção", "value": 1 }, { "label": "Homologação", "value": 2 }, { "label": "Desenvolvimento", "value": 3 }, { "label": "Qualidade", "value": 4 }] }, { "label": "Nome do servidor/instância", "required": "true", "name": "servidor/instância", "value": "" }, { "label": "Nome do banco de dados a ser criado", "name": "Banco de dados", "value": "", "options": [{ "label": "Sim", "value": 1 }, { "label": "Não", "value": 2 }] }, { "label": "Login de acesso ao banco", "name": " acesso de dados", "value": "", "checkbox": [{ "label": "Aluno", "value": "false" }, { "label": "Professor", "value": "false" }, { "label": "Coordenador", "value": "false" }] }];
        $scope.Objetos.Banco = [{ "label": "Nome do Banco", "name": "Servidor/instância", "value": "" }, { "label": "Agência", "value": "" }, { "label": "Conta", "value": "" }];
        */

        // GET api/values
        [HttpGet]
        public ApiModelo[] Get()
        {

            return ApiValueService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ApiFormulario[] Get(int id)
        {
            return ApiValueService.GetFormulario(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}