using Polly;
using Workshops.Domain.Models;
using Workshops.Infrastructure.Context;
using Danps.WebAPI.Core.Configuration;

namespace WorkShops.Api
{
    public static class DbMigrationHelpers
    {
        /// <summary>
        ///     Generate migrations before running this method, you can use command bellow:
        ///     Nuget package manager: Add-Migration DbInit -context CustomerContext
        ///     Dotnet CLI: dotnet ef migrations add DbInit -c CustomerContext
        /// </summary>
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<WorkshopsDbContext>();
            await DbHealthChecker.TestConnection(context);

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                await context.Database.EnsureCreatedAsync();

                await EnsureSeedWorkshops(context);
            }

        }
        private static async Task EnsureSeedWorkshops(WorkshopsDbContext context)
        {
            if (context.Workshops.Any())
                return;

            var now = DateTimeOffset.Now;

            await context.Workshops.AddAsync(
            new Workshop
            {
                Title = "Introdução ao .NET 8",
                Description = "Workshop prático sobre as novidades do .NET 8.",
                StartAt = now.AddDays(3).AddHours(9),
                EndAt = now.AddDays(3).AddHours(17),
                Location = "Auditório Tech Center - São Paulo",
                Capacity = 100,
                IsOnline = false
            });
            await context.Workshops.AddAsync(

            new Workshop
            {
                Title = "Machine Learning com Python",
                Description = "Aplicações práticas de aprendizado de máquina.",
                StartAt = now.AddDays(7).AddHours(14),
                EndAt = now.AddDays(7).AddHours(18),
                Location = "Online",
                Capacity = 200,
                IsOnline = true
            });
            await context.Workshops.AddAsync(

                new Workshop
                {
                    Title = "Segurança em Aplicações Web",
                    Description = "Boas práticas de segurança e OWASP Top 10.",
                    StartAt = now.AddDays(10).AddHours(9),
                    EndAt = now.AddDays(10).AddHours(13),
                    Location = "Centro de Inovação - Belo Horizonte",
                    Capacity = 80,
                    IsOnline = false

                });
            await context.Workshops.AddAsync(
            new Workshop
            {
                Title = "DevOps e CI/CD",
                Description = "Automatização de pipelines com Azure DevOps e GitHub Actions.",
                StartAt = now.AddDays(15).AddHours(10),
                EndAt = now.AddDays(15).AddHours(16),
                Location = "Online",
                Capacity = 150,
                IsOnline = true

            });
            await context.Workshops.AddAsync(
            new Workshop
            {
                Title = "Cloud Computing com Azure",
                Description = "Introdução aos principais serviços do Microsoft Azure.",
                StartAt = now.AddDays(20).AddHours(9),
                EndAt = now.AddDays(20).AddHours(17),
                Location = "Microsoft Reactor - Rio de Janeiro",
                Capacity = 120,
                IsOnline = false

            });
            await context.SaveChangesAsync();
        }
    }
}