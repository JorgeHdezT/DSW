using Microsoft.EntityFrameworkCore;
using Musica_Corregido.Models;

namespace Musica_Corregido.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChinookContext(serviceProvider.GetRequiredService<DbContextOptions<ChinookContext>>()))
            {
                // Verificar si ya hay datos en la tabla de Reviews
                if (context.Reviews.Any())
                {
                    return; // La base de datos ya ha sido poblada
                }

                // Si no hay datos, entonces procedemos a agregar algunos datos de ejemplo

                context.Reviews.AddRange(
                    new Review
                    {
                        Title = "Título de la Review 1",
                        Description = "Descripción de la Review 1",
                        Rating = 4,
                        ArtistId = 1 
                    },
                    new Review
                    {
                        Title = "Título de la Review 2",
                        Description = "Descripción de la Review 2",
                        Rating = 5,
                        ArtistId = 2 
                    }

                );

                context.SaveChanges();
            }
        }
    }

}
