
using Danps.Core.Data;
using Danps.Core.Services;
using Danps.Data;
using Microsoft.Extensions.Logging;
using PocketEntity.Core;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;
using System;
using System.Collections;
using System.Linq;

namespace PocketEntity.Services.Services
{
    public static class UserSpecificationExtensions
    {
        public static ISpecification<Tenant> PorNome(this ISpecification<Tenant> specification, string username)
        {
            return specification.And(x => x.TenantName == username);
        }
    }

    public class UserService : IUserService
    {
        public EfReadRepository<Tenant> repository { get; private set; }
        public QuickPocketContext context { get; private set; }
        public ILogger Logger { get; private set; }

        public UserService(ILogger logger, QuickPocketContext context)
        {
            this.Logger = logger;
            this.repository = new EfReadRepository<Tenant>(context);
            this.context = context;
        }

        IViewModelDefault IUserService.Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var spec = BuscarPorNome(username);

            var user = this.repository.FirstOrDefault(spec);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!PasswordHash.Verify(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return ToView(user);
        }

        private IViewModelDefault ToView(Tenant user)
        {
            var retorno = new TenantViewModel()
            {
                TenantId = user.TenantId,
                TenantName = user.TenantName
            };
            return retorno;
        }

        IViewModelDefault IUserService.Create(string nome, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            var spec = BuscarPorNome(nome);

            if (this.repository.Exists(spec))
                throw new Exception("Username " + nome + " is already taken");

            byte[] passwordHash, passwordSalt;
            PasswordHash.Create(password, out passwordHash, out passwordSalt);
            var user = new Tenant()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                TenantName = nome
            };
            context.Add(user);
            context.SaveChanges();
            return ToView(user);
        }

        private ISpecification<Tenant> BuscarPorNome(string username)
        {
            var sf = new SpecificationFactory();
            var spec2 = sf.Create<Tenant>().PorNome(username);
            return spec2;
        }

        public void Update(IViewModelDefault obj, string password = null)
        {
            var userParam = (TenantViewModel)obj;

            var user = context.Tenant.Where(a => a.TenantId == userParam.TenantId).FirstOrDefault();

            if (user == null)
                throw new Exception("User not found");

            if (userParam.TenantName != user.TenantName)
            {
                // username has changed so check if the new username is already taken
                var spec = BuscarPorNome(user.TenantName);
                if (this.repository.Exists(spec))
                    throw new Exception("Username " + userParam.TenantName + " is already taken");
            }
            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                PasswordHash.Create(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            context.Update(user);

            context.SaveChanges();
        }

        public IViewModelDefault Get(int id)
        {
            var user = context.Tenant.Where(a => a.TenantId == id).FirstOrDefault();
            return ToView(user);
        }

        public IList GetAll()
        {
            var user = context.Tenant.ToList();
            return (user);
        }

        public void Delete(int id)
        {
            var user = context.Tenant.Where(a => a.TenantId == id).FirstOrDefault();
            context.Tenant.Remove(user);
        }
    }
}