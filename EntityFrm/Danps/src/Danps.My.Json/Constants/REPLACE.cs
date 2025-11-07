using Danps.My.Domain.Models;
using Danps.My.Domain.ViewModels;
using Danps.My.Json.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Danps.My.Json.Constants
{
    public class Util
    {

        public static MyModelo MODELO_BUILDER_MAPPING => new MyModelo
        {
            Nome = "Declaracao BUILDER_MAPPING",
            Mensagem = "            builder.Property(t => t.{NOME}).HasColumnName(\"{NOME}\"); ",
            Tags = new MyTag[]
            {
                new MyTag{ Token = "{NOME}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Nome" }},
            }
        };

        public static MyModelo MODELO_ENTITY_MAPPING => new MyModelo
        {
            Nome = "MODELO_ENTITY_MAPPING", 
            Tags = new MyTag[]
           {
                new MyTag{ Token = "{NOME_CLASSE}", Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "NomeEntidade" } },
                new MyTag{ Token = "{CORE_DOMAIN}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "CoreDomain"}} ,
                new MyTag{ Token = "{PROJETO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Projeto"}},
                new MyTag{ Token = "{AREA}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Area"}},
                new MyTag{ Token = "{NOME_TABELA}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "NomeInterface"}},

                new MyTag { ModeloSecundario =  MODELO_BUILDER_MAPPING, Token = "{CAMPOS}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Campos"}},
           }
        };


        public static string FirstLetterToUpperCase( string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static void UpdateProperties2(string file, string saida)
        {
            var json = File.ReadAllText(file);
            var objetos = JsonConvert.DeserializeObject<Rootobject>(json);


            foreach (var objeto in objetos.dbo)
            {

            }
        }

            public static void UpdateProperties(string file, string saida, string soluctionName, Dictionary<string, string> projectNames)
        {           
            var json = File.ReadAllText(file);
            var objetos = JsonConvert.DeserializeObject<Rootobject>(json);


            objetos.soluctionName = soluctionName;
            foreach (var objeto in objetos.dbo)
            {
                var projetoName = DictionaryIndexOf(objeto.table.name, projectNames);
                objeto.projeto = $"{objetos.soluctionName}.{projetoName}";                
                objeto.table.classe = MyDefaultName(objeto.table.name, REPLACE.FIELD_NAME);
                foreach(var coluna in objeto.table.columns)
                {
                    coluna.Nome = MyDefaultName(coluna.name, REPLACE.FIELD_NAME);
                    coluna.Tipo = MyDefaultName(coluna.name, REPLACE.TYPE_CSHARP);
                }

                var campos = objeto.table.columns.Where(a => a.indexes == null || a.indexes.Any(b=>!b.is_primary_key)).Select(c => new CampoViewModel { Tipo = c.Tipo, Nome = c.Nome}).ToArray();
                var pk = objeto.table.columns.Where(a => a.indexes != null && a.indexes.Any(b => b.is_primary_key)).Select(c => new CampoViewModel { Tipo = c.Tipo, Nome = c.Nome, }).ToArray();

                var ent = new EntidadeViewModel(){
                    ParametroConstrutor = campos, 
                    Construtor = campos, 
                    Campos = campos.Concat(pk).ToArray(), 
                    NomeEntidade = objeto.table.classe,
                    Projeto = objeto.projeto,
                    Area = projetoName
                };
                var mensagem = File.ReadAllText(@"D:\375364\EntityFrm\Danps\templates\src\PROJETO.Data\Mappings\NOME_CLASSEMapping.cs.txt");

                var modelo = MODELO_ENTITY_MAPPING;
                modelo.Mensagem = mensagem; 
                var arquivo = modelo.Executar(ent).Mensagem;
            }
            File.WriteAllText(saida, JsonConvert.SerializeObject(objetos));
            /*
            
            var model = (MyModelo)modeloEntidade.Clone();
            var arquivo = model.Executar(ent).Mensagem;

            System.IO.File.WriteAllText($"{dirertorio}{root.MyAggregateClasses.First().MyClass.Nome}.cs", arquivo);
            */
        }
        public static string MyDefaultName(string valor, Dictionary<string, string> dicionario = null)
        {
            if(dicionario != null)
                valor = DictionaryIndexOf(valor, dicionario);
            var strings = new char[] {';', ':', '!', '?', ',', '.', '_', '-', '/', '&', '\'', '('};
            var saida = valor.ToLower().Split(strings);

            string prevchar = string.Join("", saida.Select(a => FirstLetterToUpperCase(a)));
             
            return prevchar;


        }
        public static string DictionaryIndexOf (string nome, Dictionary<string, string> chaves )
        {
            foreach (var item in chaves)
            {
                if (nome.IndexOf(item.Key) >= 0)
                {
                   return item.Value;
                }
            }
            return nome;

        }
    }
    public class REPLACE
    {
        public static Dictionary<string, string> FIELD_NAME => new Dictionary<string, string>()
        {
            {"qtd_", "Quantidade_"},
            {"ctd_arquivo", "Conteudo_"},
            {"ind_atual", "Atual_"},
            {"idt_dom_", ""},
            {"seq_dom_", "Identificador_"},
            {"num_", "Numero_"},
            {"sgl_", "Sigla_"},
            {"nom_", "nome_"},
            {"dsc_", "Descricao_"},
            {"cod_", "Codigo_"},
            {"obs_", "Observacao_"},
            {"ind_", "Exige_"},
            {"usu_", "Usuario_"},
            {"dat_", "Data_"},
        };

        public static Dictionary<string, string> TYPE_CSHARP => new Dictionary<string, string>() {
            {"varbinary","Byte[]" },
            {"binary","Byte[]"},
            {"varchar","String"},
            {"char","Char"},
            {"nvarchar","String"},
            {"nchar","String"},
            {"text","String"},
            {"ntext","String"},
            {"uniqueidentifier","Guid"},
            {"rowversion","Byte[]"},
            {"bit","Boolean"},
            {"tinyint","Byte"},
            {"smallint","short"},
            {"int","int"},
            {"bigint","int"},
            {"smallmoney","decimal"},
            {"money","decimal"},
            {"numeric","decimal"},
            {"decimal","decimal"},
            {"real","Single"},
            {"float","Double"},
            {"smalldatetime","DateTime"},
            {"datetime","DateTime"},
            {"datetime2","DateTime"},
            {"sql_variant","Object"}
        };
    }
}