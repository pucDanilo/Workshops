using AutoMapper;
using Danps.Core.Data;
using Danps.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PocketEntity.Core;
using PocketEntity.Core.Models;
using PocketEntity.Core.ViewModels;
using PocketEntity.Helpers;
using PocketEntity.Services.Models;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

    /*
namespace PocketEntity.Services.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UsersController : WebAPIControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;

        protected ILogger Logger;

        public UsersController(ILogger<UsersController> logger, QuickPocketContext context, IUserService userService, IOptions<AppSettings> appSettings) : base(context)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            this.Logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]TenantViewModel userDto)
        {
            Logger?.LogDebug("{0} has been invoked", nameof(Authenticate));

            var user = _userService.Authenticate(userDto.TenantName, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var config = new ConfigType(user.TenantId, user.TenantName);
            //config.ContaCorrenteIds = user.ContaCorrentes.Select(a => a.ContaCorrenteId).ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(config.GetClaim()),
                Expires = DateTime.UtcNow.AddMinutes(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.TenantId,
                Username = user.TenantName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]TenantViewModel userDto)
        {
            // map dto to entity
            var user = new Tenants() { TenantName = userDto.TenantName };

            try
            {
                // save
                _userService.Create(userDto.TenantName, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // HttpContext.User.Identity.Name
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                // or
                var a = identity.FindFirst("CodigoUsuario").Value;
            }

            var user = _userService.Get(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]IViewModelDefault userDto)
        {
         //   userDto.TenantId = id;

            try
            {
                // save
                //_userService.Update(userDto, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}*/