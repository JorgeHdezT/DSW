using System.Collections.Generic;
using HernandezJorge_API_Ej1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HernandezJorge_API_Ej1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Juegos> listaJuegos = new List<Juegos>
        {
            new Juegos { Id = 1, Name = "Juego1", Price = 29.99f },
            new Juegos { Id = 2, Name = "Juego2", Price = 39.99f },
            new Juegos { Id = 3, Name = "Juego3", Price = 19.99f }
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Juegos>), 200)]
        public IActionResult Get()
        {
            return Ok(listaJuegos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Juegos), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var juego = listaJuegos.Find(j => j.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            return Ok(juego);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Juegos), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Juegos juego)
        {
            if (juego == null)
            {
                return BadRequest("Invalid data");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int maxId = listaJuegos[0].Id;
            foreach(var item in listaJuegos)
            {
                if (item.Id > maxId)
                {
                    maxId = item.Id;
                }
            }
            // Asignar un nuevo ID al juego
            juego.Id = maxId + 1;
            listaJuegos.Add(juego);

            return CreatedAtAction(nameof(Get), new { id = juego.Id }, juego);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Juegos juego)
        {
            if (juego == null || id != juego.Id)
            {
                return BadRequest("Invalid data");
            }

            // Validar el modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var index = listaJuegos.FindIndex(j => j.Id == id);
            if (index == -1)
            {
                return NotFound();
            }

            // Actualizar los datos del juego
            listaJuegos[index] = juego;

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var juego = listaJuegos.Find(j => j.Id == id);
            if (juego == null)
            {
                return NotFound();
            }

            // Eliminar el juego de la lista
            listaJuegos.RemoveAll(j => j.Id == id);

            return NoContent();
        }
    }
}
