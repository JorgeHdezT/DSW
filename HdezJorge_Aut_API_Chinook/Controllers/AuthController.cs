using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APIMusica_HdezJorge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


/*
  {
    "userName": "admin",
    "password": "admin"
  }
*/

namespace APIMusica_HdezJorge
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User auth)
        {
            // Verifica las credenciales del usuario (puedes personalizar esto según tu lógica de autenticación)
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == auth.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, auth.Password))
            {
                return Unauthorized();
            }

            var token = await CreateToken(user);
            return Ok(new { Token = token });
        }

        private async Task<string> CreateToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
        // METODO PARA VER QUE ROL TIENES ACTUALMENTE (Idea extra hecha y pensada por mi)

        [HttpGet("get-user-role")]
        [Authorize] // Asegura que el usuario esté autenticado
        public IActionResult GetUserRole()
        {
            try
            {
                // Obtiene el nombre del usuario actual
                var userName = User.Identity.Name;

                // Obtiene los roles del usuario actual
                var userRoles = ((ClaimsIdentity)User.Identity).Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value);

                // Retorna los roles del usuario
                return Ok(new {Roles = userRoles });
            }
            catch (Exception ex)
            {
                // Registra la excepción para obtener más detalles
                Console.WriteLine($"Error al obtener el rol del usuario: {ex}");
                return StatusCode(500, "Error interno al obtener el rol del usuario");
            }
        }
    }
}
