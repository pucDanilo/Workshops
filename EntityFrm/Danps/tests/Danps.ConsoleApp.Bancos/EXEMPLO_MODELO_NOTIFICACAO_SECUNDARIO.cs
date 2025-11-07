using Danps.My.Domain.Models;

namespace Danps.ConsoleApp.Bancos
{
    public static class EXEMPLO_MODELO_NOTIFICACAO_SECUNDARIO
    {
        public static MyModelo MODELO_PARAMETRO_CONSTRUTOR => new MyModelo
        {
            Concatenador = ", ",
            Nome = "Parametro Construtor",
            Mensagem = "            {TIPO} {NOME}",
            Tags = new MyTag[]
                {
                    new MyTag{ Token = "{NOME}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Nome" }},
                    new MyTag{ Token = "{TIPO}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Tipo" }},
                }
        }
        ;

        public static MyModelo MODELO_CONSTRUTOR => new MyModelo
        {
            Nome = "Conteudo Construtor",
            Mensagem = "            this.{NOME} = {NOME};",
            Tags = new MyTag[]
                {
                    new MyTag{ Token = "{NOME}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Nome" }},
                    new MyTag{ Token = "{TIPO}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Tipo" }},
                }
        };

        public static MyModelo MODELO_CAMPOS => new MyModelo
        {
            Nome = "Declaracao Campos",
            Mensagem = "        public {TIPO} {NOME} { get; private set; }",
            Tags = new MyTag[]
                {
                    new MyTag{ Token = "{NOME}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Nome" }},
                    new MyTag{ Token = "{TIPO}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Tipo" }},
            }
        };

        public static MyModelo MODELO_DB_SET => new MyModelo
        {
            Nome = "DBSET",
            Mensagem = "        public DbSet<{TIPO}> {NOME} { get; set; }",
            Tags = new MyTag[]
                {
                    new MyTag{ Token = "{NOME}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Nome" }},
                    new MyTag{ Token = "{TIPO}" , Objeto = new MyObjetoOrigem{ Nome ="Campo", Propriedade = "Tipo" }},
            }
        };

        public static MyModelo MODELO_CONTEXTO => new MyModelo
        {
            Nome = "Context Template",
            Mensagem = @"
namespace {PROJETO}.{Area}.Data
{
    public class {AREA}Context : DbContext, IUnitOfWork
    {
        public {AREA}Context(DbContextOptions<{AREA}Context> options)
            : base(options) { }

        {DBSET}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = ""varchar(100)"";

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof({AREA}Context).Assembly);
        }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(""DataCadastro"") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(""DataCadastro"").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(""DataCadastro"").IsModified = false;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }
}
",
            Tags = new MyTag[]
            {
                new MyTag{ Token = "{PROJETO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Projeto"}},
                new MyTag{ Token = "{AREA}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Area"}},
                new MyTag { ModeloSecundario =  MODELO_DB_SET, Token = "{DBSET}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Classes"}},
            }
        };

        public static MyModelo MODELO_ENTITY_DDD => new MyModelo
        {
            Nome = "MODELO_ENTITY_DDD",
            Mensagem = @"
using {CORE_DOMAIN}.Domain;
using {CORE_DOMAIN}.DomainObjects;
using System;

namespace {PROJETO}.{AREA}.Domain
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
            Validacoes.ValidarSeIgual(Id, Guid.Empty, ""O campo Id do produto não pode estar vazio"");
        }
    }
}
",
            Tags = new MyTag[]
            {
                new MyTag{ Token = "{NOME_CLASSE}", Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "NomeEntidade" } },
                new MyTag{ Token = "{CORE_DOMAIN}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "CoreDomain"}} ,
                new MyTag{ Token = "{PROJETO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Projeto"}},
                new MyTag{ Token = "{AREA}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Area"}},
                new MyTag{ Token = "{INTERFACE}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "NomeInterface"}},

                new MyTag{ ModeloSecundario =  MODELO_PARAMETRO_CONSTRUTOR,  Token = "{PARAMETRO_CONSTRUTOR}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "ParametroConstrutor"}},
                new MyTag{ ModeloSecundario =  MODELO_CONSTRUTOR, Token = "{CONSTRUTOR}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Construtor"}},
                new MyTag { ModeloSecundario =  MODELO_CAMPOS, Token = "{CAMPOS}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Campos"}},
            }
        };

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
            Mensagem = @"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using {CORE_DOMAIN}.Domain;
using {CORE_DOMAIN}.DomainObjects;
using System;
using {PROJETO}.{AREA}.Domain;

namespace {PROJETO}.{AREA}.Mappings
{
    public class {NOME_CLASSE}Mapping : IEntityTypeConfiguration<{NOME_CLASSE}>
    {
        public void Configure(EntityTypeBuilder<{NOME_CLASSE}> builder)
        {
            builder.HasKey(p => p.Id);
            {CAMPOS}
            builder.ToTable(""{NOME_CLASSE}"");
        }
    }
}
",
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

        public static MyModelo MODELO_MIGRATION => new MyModelo
        {
            Nome = "MODELO_MIGRATION",
            Mensagem = @"
using Microsoft.EntityFrameworkCore.Migrations;

namespace {PROJETO}.{AREA}.Migrations
{
    public partial class {NOME_CLASSE}_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @""{DEFINITION}"";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(""{DROP}"");
        }
    }
",
            Tags = new MyTag[]
            {
                new MyTag{ Token = "{NOME_CLASSE}", Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "NomeEntidade" } },
                new MyTag{ Token = "{CORE_DOMAIN}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "CoreDomain"}} ,
                new MyTag{ Token = "{PROJETO}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Projeto"}},
                new MyTag{ Token = "{AREA}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Area"}},
                new MyTag{ Token = "{INTERFACE}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "NomeInterface"}},
                new MyTag{ Token = "{DEFINITION}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Definition"}},
                new MyTag{ Token = "{DROP}" , Objeto = new MyObjetoOrigem{ Nome ="EntidadeDomain", Propriedade = "Drop"}},
            }
        };
    }
}