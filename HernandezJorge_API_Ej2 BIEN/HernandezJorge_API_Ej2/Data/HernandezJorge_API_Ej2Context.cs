using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HernandezJorge_API_Ej2.Models;

namespace HernandezJorge_API_Ej2.Data
{
    public class HernandezJorge_API_Ej2Context : DbContext
    {
        public HernandezJorge_API_Ej2Context (DbContextOptions<HernandezJorge_API_Ej2Context> options)
            : base(options)
        {
        }

        public DbSet<HernandezJorge_API_Ej2.Models.Game> Game { get; set; } = default!;

        public DbSet<HernandezJorge_API_Ej2.Models.Genre>? Genre { get; set; }

        //Seeder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                    new Game { JuegoId = 1, Titulo = "Juego1", GeneroId = 1 },
                    new Game { JuegoId = 2, Titulo = "Juego2", GeneroId = 2 },
                    new Game { JuegoId = 3, Titulo = "Juego3", GeneroId = 3 }
                );


            modelBuilder.Entity<Genre>().HasData(
                    new Genre { GeneroId = 1, Nombre = "Accion" },
                    new Genre { GeneroId = 2, Nombre = "Aventura" },
                    new Genre { GeneroId = 3, Nombre = "Carreras" }
                );
        }
    }
}
