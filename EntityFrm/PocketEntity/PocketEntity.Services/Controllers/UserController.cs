
using AutoMapper;
using Danps.Core.Models;
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
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace PocketEntity.Services.Controllers
{
    [Authorize, Route("[controller]")]
    public class UserController : WebAPIControllerBase
    {
        private IUserService _UserService;
        private readonly AppSettings _appSettings;
        private IMapper _mapper;

        protected ILogger Logger;

        public UserController(ILogger<UserController> logger, QuickPocketContext context, IUserService UserService, IOptions<AppSettings> appSettings) : base(context)
        {
            _UserService = UserService;
            _appSettings = appSettings.Value;
            this.Logger = logger;
        }

        [AllowAnonymous, HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            Logger?.LogDebug("{ 0} has been invoked", nameof(Authenticate));

            var user = (TenantViewModel)_UserService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var config = new ConfigType(user.TenantId, user.TenantName);
            //config.ContaCorrenteIds = user.ContaCorrente.Select(a => a.ContaCorrenteId).ToArray();

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
        public IActionResult Register([FromBody]UserDto userDto)
        {
            // map dto to entity
            var user = new Tenant() { TenantName = userDto.Username };

            try
            {
                // save
                _UserService.Create(userDto.Username, userDto.Password);
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
            var User = _UserService.GetAll();
            return Ok(User);
        }

        [HttpGet("{ id}")]
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

            var user = _UserService.Get(id);
            //var userDto = _mapper.Map<UserDto>(user);
            return Ok(user);
        }

        [HttpPut("{ id}")]
        public IActionResult Update(int id, [FromBody]TenantViewModel userDto)
        {
            //   userDto.TenantId = id;

            try
            {
                // save
                //_UserService.Update(userDto, userDto.Password);
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
            _UserService.Delete(id);
            return Ok();
        }
    }
}