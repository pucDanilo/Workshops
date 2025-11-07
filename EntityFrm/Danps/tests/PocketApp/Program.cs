using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PocketApp.Application.AutoMapper;
using PocketApp.Application.Services;
using PocketApp.Application.ViewModels;
using PocketApp.Data;
using PocketApp.Data.Repository;
using PocketApp.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApp
{
    internal class Program
    {
        private static ServiceProvider _serviceProvider;

        private static void RegistroInstanciaDemoAsync()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IFluxoCaixaRepository, FluxoCaixaRepository>();

            services.AddScoped<IFluxoCaixaAppService, FluxoCaixaAppService>();

            services.AddSingleton<PocketContext>();

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));

            _serviceProvider = services.BuildServiceProvider();
        }

        static IFluxoCaixaRepository FluxoCaixaRepository => _serviceProvider.GetService<IFluxoCaixaRepository>();
        static IFluxoCaixaAppService FluxoCaixaAppService => _serviceProvider.GetService<IFluxoCaixaAppService>();
        static PocketContext context => _serviceProvider.GetService<PocketContext>();
        public static DateTime INICIO_MES = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);

        private static async Task Main(string[] args)
        {
            //PM> Add-Migration Initial
            //PM > Update - Database

            try
            {
                RegistroInstanciaDemoAsync();

                await IncluirTags();

                FluxoCaixaViewModel obj;
                var todos = await FluxoCaixaAppService.ObterTodos();
                if (todos == null || !todos.Any(a => a.Nome == "Bantestes"))
                {
                    obj = new FluxoCaixaViewModel { TipoCategoria = TipoCategoria.ContaCorrente, Nome = "Bantestes", SaldoAnterior = 1000 };
                    await FluxoCaixaAppService.AdicionarFluxoCaixa(obj);
                }
                else
                {
                    obj = todos.FirstOrDefault();
                    Console.WriteLine(obj.Nome);
                }

                Tag DESPESAS = context.Tags.Where(a => a.Nome == "Despesas").FirstOrDefault();
                Tag SALARIO = context.Tags.Where(a => a.Nome == "Salario").FirstOrDefault();
                Tag MORADIA = context.Tags.Where(a => a.Nome == "Moradia").FirstOrDefault();
                Tag ASSINATURAS = context.Tags.Where(a => a.Nome == "Assinaturas").FirstOrDefault();

                //FluxoCaixaRepository.AdicionarMovimentacao(obj.Id, new Movimentacao(DESPESAS.Id, INICIO_MES, 4000, "CRED TEV"));
                await FluxoCaixaRepository.UnitOfWork.Commit();
                
                /*

        await FluxoCaixaAppService.AdicionarFluxoCaixa(c1);

        context.Tags.Add(DESPESAS);
                context.Tags.Add(SALARIO);
                context.Tags.Add(MORADIA);
                context.Tags.Add(ASSINATURAS);
                context.SaveChanges();
            }

                */

                Console.WriteLine("Hello World!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*
            using (var context = new PocketContext())
            {
                context.Tenants.Add(new Locatario ("John One"));
                context.SaveChanges();
            }

            using (var context = new PocketContext())
            {
        public static DateTime INICIO_MES = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
        public static Tag DESPESAS => new Tag(1, "Despesas");
        public static Tag SALARIO => new Tag(2, "Salario");
        public static Tag MORADIA => new Tag(1, "Moradia");
        public static Tag ASSINATURAS => new Tag(1, "Assinaturas");

                context.Tags.Add(DESPESAS);
                context.Tags.Add(SALARIO);
                context.Tags.Add(MORADIA);
                context.Tags.Add(ASSINATURAS);
                context.SaveChanges();
            }

            **/
            /*
            using (var context = new PocketContext())
            {
                var c1 = new FluxoCaixa(TipoCategoria.ContaCorrente, "Bantestes", 1000);
                context.CashFlows.Add(c1);

                c1.AdicionarItem(new Movimentacao(SALARIO.Id, INICIO_MES, 4000, "CRED TEV"));
                c1.AdicionarItem(new Movimentacao(DESPESAS.Id, INICIO_MES.AddDays(5), -300, "SAQUE ATM"));
                c1.AdicionarItem(new Movimentacao(ASSINATURAS.Id, INICIO_MES.AddDays(10), -50, "Assinatura Netflix"));
                c1.AdicionarItem(new Movimentacao(DESPESAS.Id, INICIO_MES.AddDays(10), -150, "PIZZA"));
                c1.AdicionarItem(new Movimentacao(MORADIA.Id, INICIO_MES.AddDays(32), -1500, "Prestação Casa"));
                context.CashFlows.Update(c1);
                context.SaveChanges();

                context.CashFlows.Add(new FluxoCaixa(TipoCategoria.ContaCorrente, "Caixa Forte", 5000));
                context.SaveChanges();
                context.CashFlows.Add(new FluxoCaixa(TipoCategoria.ContaCorrente, "Carteira", 0));
                context.SaveChanges();
                context.CashFlows.Add(new FluxoCaixa(TipoCategoria.ContaCorrente, "Mastercard", 2000));
                context.SaveChanges();
                context.CashFlows.Add(new FluxoCaixa(TipoCategoria.ContaCorrente, "Visa", 4500));
                context.SaveChanges();
            }
            */
        }

        private static async Task IncluirTags()
        {/*
            context.Tags.Add(new Tag(1, "Despesas"));
            context.Tags.Add(new Tag(2, "Salario"));
            context.Tags.Add(new Tag(1, "Moradia"));
            context.Tags.Add(new Tag(1, "Assinaturas"));*/
            await context.Commit();
        }
    }/*

    public enum TipoFluxoCaixa
    {
        ,
        ,
        ,
    }
    */
}