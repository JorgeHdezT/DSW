using ApellidoNombre_v1.Data;
using Microsoft.EntityFrameworkCore;

namespace ApellidoNombre_v1.Models
{
    public static class SeedData

    {
       
            public static void Initializa(IServiceProvider serviceProvider)
            {
                using (var context2 = new JardineriaContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<JardineriaContext>>()))
                {

                    if (context2.Recomendaciones.Any())
                    {
                        return;
                    }
                context2.Recomendaciones.AddRange(
                    new Recomendacion
                    {
                        Title = "Title AR-010",
                        Descripcion = "Description",
                        Estacion = "Primavera",
                        CodigoProducto = "AR-010"
                    },
                    new Recomendacion
                    {
                        Title = "Title AR-009",

                         Descripcion = "Description Aromatica",
                        Estacion = "Primavera",
                        CodigoProducto = "AR-009",
                    });
                    context2.SaveChanges();
                }

            }
        }
    }

