using Danps.My.Data;
using Danps.My.Domain.Models;
using Danps.My.Domain.ViewModels;
using Danps.My.Json.Constants;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Danps.ConsoleApp.Bancos
{
    internal partial class Program
    {
        public static void BancoExemplo()
        {
            using var db = new MyApplicationContext();
            MyBancoDados.HealthCheck(db);
            CriarModelos();
        }

        private static MyApplicationContext CriarModelos()
        {
            var db2 = new MyApplicationContext();
            MyBancoDados.GapDoEnsureCreated(db2);
            db2.Modelos.Add(EXEMPLO_MODELO_NOTIFICACAO_SECUNDARIO.MODELO_ENTITY_DDD);
            db2.Modelos.Add(EXEMPLO_MODELO_NOTIFICACAO_SECUNDARIO.MODELO_CONTEXTO);
            db2.Modelos.Add(EXEMPLO_MODELO_NOTIFICACAO_SECUNDARIO.MODELO_ENTITY_MAPPING);
            db2.Modelos.Add(EXEMPLO_MODELO_NOTIFICACAO_SECUNDARIO.MODELO_MIGRATION);

            db2.Modelos.Add(EXEMPLO_GITHUB_TEMPLATE.TEMPLATE);

            db2.SaveChanges();
            return db2;
        }

        public static void CriarModeloTeste(string nomeTabela, long modeloId)
        {
            using var db = new MyApplicationContext();

            var Produtos = db.MyClasses.Where(a => a.NomeTabela == "certificado").FirstOrDefault();
            var Categorias = db.MyClasses.Where(a => a.NomeTabela == "certificadora_atuacao_participante").FirstOrDefault();
            if (Produtos != null && Categorias != null)
            {
                var root = new MyAggregate
                {
                    Area = "Catalogo",
                    Projeto = "NerdStore",
                    CoreDomain = "Danps.Core",
                    NomeInterface = "Entity",
                    MyAggregateClasses = new List<MyAggregateClass>
                {
                    new MyAggregateClass { MyClass= Produtos, Principal = true } ,
                    new MyAggregateClass { MyClass = Categorias, Principal = false }
                }
                };

                db.MyAggregates.Add(root);
                db.SaveChanges();
            }

            var modelo = db.Modelos.Include(a => a.Tags).ThenInclude(m2 => m2.ModeloSecundario).ThenInclude(mt => mt.Tags).Where(a => a.Id == modeloId).FirstOrDefault();

            var classes = db.MyAggregates
                .Include(a => a.MyAggregateClasses)
                .ThenInclude(a => a.MyClass)
                .ThenInclude(a => a.MyClassFields)
                .FirstOrDefault();
            var ent = new EntidadeViewModel(classes);

            Console.WriteLine(modelo.Executar(ent).Mensagem);

            Console.WriteLine(Environment.NewLine);
        }

        public static void criarNovo()
        {
            BancoExemplo();
            //TesteModelo();

            // CriarModeloTeste("Produtos", 1);
        }

        private static void RUn(string dirertorio, MyModelo modeloEntidade, MyAggregate root)
        {
            var ent = new EntidadeViewModel(root.MyAggregateClasses.First(), root.NomeInterface, root.Projeto, root.Area, root.CoreDomain);
            var model = (MyModelo)modeloEntidade.Clone();
            var arquivo = model.Executar(ent).Mensagem;

            System.IO.File.WriteAllText($"{dirertorio}{root.MyAggregateClasses.First().MyClass.Nome}.cs", arquivo);
        }

        private static void Main(string[] args)
        {
            var projectNames = new Dictionary<string, string>()
            {
                { "documento", "Documento" },
                {"participante", "Usuario" },
                {"certificado", "Certificado" },
                {"diploma", "Diploma" },
                {"", "Cadastro" },
            };
            Util.UpdateProperties(@"D:\375364\EntityFrm\Danps\scripts\gad.json", @"D:\375364\EntityFrm\Danps\scripts\gad_convertido.json", "AssinaturaDigital", projectNames);


            //BancoExemplo();

            //criarNovo();
            //TesteModelo(@"D:\375364\EntityFrm\Students\src\Students.Domain\", "MODELO_ENTITY_DDD");
            //TesteModelo(@"D:\375364\EntityFrm\Students\src\Students.Domain\Mappings", "MODELO_ENTITY_MAPPING");

            using var db = new MyApplicationContext();
            var classes = db.MyClasses.Include(a => a.MyClassFields).ToArray();

            var m1 = db.Modelos.Include(a => a.Tags).ThenInclude(m2 => m2.ModeloSecundario).ThenInclude(mt => mt.Tags).Where(a => a.Nome == "MODELO_ENTITY_DDD").FirstOrDefault();
            var d1 = @"D:\375364\EntityFrm\Students\src\Students.Domain\Models\";

            var m2 = db.Modelos.Include(a => a.Tags).ThenInclude(m2 => m2.ModeloSecundario).ThenInclude(mt => mt.Tags).Where(a => a.Nome == "MODELO_ENTITY_MAPPING").FirstOrDefault();
            var d2 = @"D:\375364\EntityFrm\Students\src\Students.Domain\Mappings\";

            foreach (var classe in classes)
            {
                var root = new MyAggregate
                {
                    Area = "Catalogo",
                    Projeto = "NerdStore",
                    CoreDomain = "Danps.Core",
                    NomeInterface = "Entity",
                    MyAggregateClasses = new List<MyAggregateClass> { new MyAggregateClass { MyClass = classe, Principal = true } }
                };
                RUn(d1, m1, root);

                RUn(d2, m2, root);
            }

            var views = db.MySqlObject.ToList();
            foreach (var view in views)
            {
                var root2 = new
                {
                    Area = "Catalogo",
                    Projeto = "NerdStore",
                    CoreDomain = "Danps.Core",
                    NomeInterface = "Entity",
                    NomeEntidade = view.ObjectName + "_Migration",
                    Definition = view.Definition,
                    Drop = view.ObjectDrop,
                };
                var diretorio = @"D:\375364\EntityFrm\Students\src\Students.Data\Migrations\";
                var arquivo = EXEMPLO_MODELO_NOTIFICACAO_SECUNDARIO.MODELO_MIGRATION.Executar(root2).Mensagem;
                System.IO.File.WriteAllText($"{diretorio}{view.ObjectName}_Migration_v1.cs", arquivo);
            }

            //TesteContexto(modDb, myAggregate);

            Console.WriteLine(Environment.NewLine);
        }

        private static void TesteModelo(string dirertorio, string nomeModelo)
        {
            var db = new MyApplicationContext();
            var modeloEntidade = db.Modelos.Include(a => a.Tags).ThenInclude(m2 => m2.ModeloSecundario).ThenInclude(mt => mt.Tags).Where(a => a.Nome == nomeModelo).FirstOrDefault();

            var myAggregate = db.MyAggregates
                .Include(a => a.MyAggregateClasses)
                .ThenInclude(a => a.MyClass)
                .ThenInclude(a => a.MyClassFields)
                .FirstOrDefault();

            //var ent = new AggregateViewModel(myAggregate);
            //Console.WriteLine(modelo.Executar(ent).Mensagem);

            foreach (var classe in myAggregate.MyAggregateClasses)
            {
                var ent = new EntidadeViewModel(classe, myAggregate.NomeInterface, myAggregate.Projeto, myAggregate.Area, myAggregate.CoreDomain);
                var model = (MyModelo)modeloEntidade.Clone();
                var arquivo = model.Executar(ent).Mensagem;

                System.IO.File.WriteAllText($"{dirertorio}{classe.MyClass.Nome}.cs", arquivo);
            }
        }

        public static void TesteContexto(MyApplicationContext db, MyAggregate myAggregate)
        {
            var modelContexto = db.Modelos.Include(a => a.Tags).ThenInclude(m2 => m2.ModeloSecundario).ThenInclude(mt => mt.Tags).Where(a => a.Nome == "MODELO_CONTEXTO").FirstOrDefault();
            var ent = new ContextoViewModel(myAggregate);
            if (modelContexto != null)
            {
                var arquivo = modelContexto.Executar(ent).Mensagem;
                var diretorio = @"D:\375364\EntityFrm\Danps\tests\NerdStore.Catalogo.Data\";
                System.IO.File.WriteAllText($"{diretorio}{myAggregate.Projeto}.cs", arquivo);
            }
        }

        private static void TesteModelo()
        {
            var obj = new
            {
                Aluno = new { Nome = "Danilo", DescricaoOfertaCurso = "Curso" },
                DataInicioDivulgacao = "DataInicio de Teste",
                DataFimDivulgacao = "Data fim de Teste",
                TituloOportunidade = "Titulo de Teste",
                CodigoOportunidade = Guid.NewGuid().ToString()
            };

            var modelo = new MyModelo
            {
                Remetente = new MyRemetente { Nome = "SGDG - Sistema de Geral de Desenvolvimento Genérico", Assunto = "{NOME_ALUNO_CANDIDATO} e {CODIGO_OPORTUNIDADE}", },
                Mensagem = @"Prezado(s)
    Informamos  que o indivíduo {NOME_ALUNO_CANDIDATO} do curso {CURSO_ALUNO_CANDIDATO} se candidatou à oportunidade {CODIGO_OPORTUNIDADE}.
{TITULO_OPORTUNIDADE} de {INICIO_DIVULGACAO_OPORTUNIDADE} até {FIM_DIVULGACAO_OPORTUNIDADE}.
",
                Tags = new MyTag[]
                {
                    new MyTag{ Token = "{NOME_ALUNO_CANDIDATO}", Objeto = new MyObjetoOrigem{ Propriedade="Aluno.Nome"}} ,
                    new MyTag{ Token = "{CURSO_ALUNO_CANDIDATO}", Objeto = new MyObjetoOrigem{Propriedade="Aluno.DescricaoOfertaCurso" } },
                    new MyTag{ Token = "{CODIGO_OPORTUNIDADE}", Objeto = new MyObjetoOrigem{ Propriedade="CodigoOportunidade"}},
                    new MyTag{ Token = "{INICIO_DIVULGACAO_OPORTUNIDADE}", Objeto = new MyObjetoOrigem{ Propriedade="DataInicioDivulgacao"}},
                    new MyTag{ Token = "{FIM_DIVULGACAO_OPORTUNIDADE}", Objeto = new MyObjetoOrigem{ Propriedade="DataFimDivulgacao"}},
                    new MyTag{ Token = "{TITULO_OPORTUNIDADE}", Objeto = new MyObjetoOrigem{ Propriedade="TituloOportunidade"}},
                }
            };

            modelo = modelo.Executar(obj);
            Console.WriteLine(modelo.Mensagem);
            Console.WriteLine(modelo.Remetente.Assunto);
        }
    }
}