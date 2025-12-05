using Danps.Identity.API.Data;
using Danps.WebAPI.Core.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Danps.Identity.API.Configuration;

public static class DbMigrationHelpers
{
    /// <summary>
    ///     Generate migrations before running this method, you can use command bellow:
    ///     Nuget package manager: Add-Migration DbInit -context ApplicationDbContext
    ///     Dotnet CLI: dotnet ef migrations add DbInit -c ApplicationDbContext
    /// </summary>
    public static async Task EnsureSeedData(WebApplication app)
    {
        var services = app.Services.CreateScope().ServiceProvider;
        await EnsureSeedData(services);
    }

    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        var ssoContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await DbHealthChecker.TestConnection(ssoContext);

        if (env.IsDevelopment() || env.IsEnvironment("Docker"))
        {
            await ssoContext.Database.EnsureCreatedAsync();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await SeedUsersAndRolesAsync(userManager, roleManager);
        }
    }

    private static async Task SeedUsersAndRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // 1. Criar roles se não existirem
        var roles = new[] { "Instructor", "Admin" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // 2. Criar usuários de exemplo
        var users = new[]
        {
            new IdentityUser { UserName = "allroles@example.com", Email = "allroles@example.com", EmailConfirmed = true },
            new IdentityUser { UserName = "instructor@example.com", Email = "instructor@example.com", EmailConfirmed = true },
            new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com", EmailConfirmed = true },
            new IdentityUser { UserName = "norole@example.com", Email = "norole@example.com", EmailConfirmed = true }
        };
         
        // 3. Criar usuários e atribuir roles
        foreach (var user in users)
        {
            var existingUser = await userManager.FindByEmailAsync(user.Email);
            if (existingUser == null)
            {
                await userManager.CreateAsync(user, user.Email);
            }
        }

        // 4. Atribuir roles
        var userAllRoles = await userManager.FindByEmailAsync("allroles@example.com");
        await userManager.AddToRolesAsync(userAllRoles, roles);

        var userInstructor = await userManager.FindByEmailAsync("instructor@example.com");
        await userManager.AddToRoleAsync(userInstructor, "Instructor");

        var userAdmin = await userManager.FindByEmailAsync("admin@example.com");
        await userManager.AddToRoleAsync(userAdmin, "Admin");

        // Usuário sem role não recebe nada
    }
}