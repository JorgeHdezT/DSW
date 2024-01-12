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

        [HttpGet("list-users")]
        [Authorize(Roles = "Admin")]
        // [Authorize(Roles = "Admin")] // Asegura que solo los admins pueden listar usuarios
        public IActionResult ListUsersWithRoles()
        {
            try
            {
                // Obtiene la lista de usuarios
                var users = _userManager.Users.ToList();

                // Crea una lista para almacenar la información de cada usuario
                var usersInfo = new List<object>();

                // Itera sobre cada usuario y obtiene su nombre y roles
                foreach (var user in users)
                {
                    var userRoles = _userManager.GetRolesAsync(user).Result;

                    // Agrega la información del usuario a la lista
                    usersInfo.Add(new
                    {
                        UserName = user.UserName,
                        Roles = userRoles
                    });
                }

                // Retorna la lista de usuarios con sus nombres y roles
                return Ok(usersInfo);
            }
            catch (Exception ex)
            {
                // Registra la excepción para obtener más detalles
                Console.WriteLine($"Error al listar usuarios: {ex}");
                return StatusCode(500, "Error interno al listar usuarios");
            }
        }



        /* PROFE! Espero que esto le sea de ayuda!
         * 
         * PARA ESTE METODO, HAY UNAS VALIDACIONES Y REQUERIMIENTOS MÍNIMOS. 
         * Este sería el formato de un json de ejemplo.
            {
              "userName": "NuevoUsuario",
              "password": "P@ssw0rd123",
              "role": "admin"
            }
         */
        [HttpPost("create-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserParameters parameters)
        {
            try
            {
                var role = IsValidRole(parameters.Role) ? parameters.Role : "user";

                var existingUser = await _userManager.FindByNameAsync(parameters.UserName);
                if (existingUser != null)
                {
                    return BadRequest("Ese nombre de usuario ya está en uso");
                }

                var newUser = new IdentityUser { UserName = parameters.UserName };
                var result = await _userManager.CreateAsync(newUser, parameters.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, role);
                    return Ok("Usuario creado exitosamente");
                }
                else
                {
                    // Captura los errores de Identity y devuelve detalles
                    var errorDetails = result.Errors.Select(e => new { Code = e.Code, Description = e.Description });
                    return BadRequest($"Error al crear el usuario: {Newtonsoft.Json.JsonConvert.SerializeObject(errorDetails)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear usuario: {ex}");
                return StatusCode(500, "Error interno al crear usuario");
            }
        }

        // Método para verificar si el rol es válido
        private bool IsValidRole(string role)
        {
            return role == "admin" || role == "manager" || role == "user";
        }

        // Clase para mapear los parámetros del cuerpo de la solicitud
        public class CreateUserParameters
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }


        /**************************************************************************/
        /*BORRAR USUARIO */

        [HttpDelete("delete-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserParameters parameters)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(parameters.UserName);

                if (user != null)
                {
                    var result = await _userManager.DeleteAsync(user);

                    if (result.Succeeded)
                    {
                        return Ok("Usuario eliminado exitosamente");
                    }
                    else
                    {
                        var errorDetails = result.Errors.Select(e => new { Code = e.Code, Description = e.Description });
                        return BadRequest($"Error al eliminar el usuario: {Newtonsoft.Json.JsonConvert.SerializeObject(errorDetails)}");
                    }
                }
                else
                {
                    return BadRequest($"No se encontró un usuario con el nombre {parameters.UserName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar usuario: {ex}");
                return StatusCode(500, "Error interno al eliminar usuario");
            }
        }

        public class DeleteUserParameters
        {
            public string UserName { get; set; }
        }


    }
}
