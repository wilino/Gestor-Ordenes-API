using System;
using GestorOrdenes.Dominio.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace GestorOrdenes.Datos
{
    public static class CargadorDatos
    {
        public static void Precargar(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<ApplicationDbContext>())
            {
                // Precargar Productos
                if (!context.Productos.Any())
                {
                    context.Productos.AddRange(
                        new Producto { Nombre = "Ceviche Clásico", Precio = 25.0m, CantidadStock = 100 },
                        new Producto { Nombre = "Lomo Saltado", Precio = 30.0m, CantidadStock = 80 },
                        new Producto { Nombre = "Ají de Gallina", Precio = 22.0m, CantidadStock = 70 },
                        new Producto { Nombre = "Tacu Tacu", Precio = 20.0m, CantidadStock = 50 },
                        new Producto { Nombre = "Causa Limeña", Precio = 18.0m, CantidadStock = 90 },
                        new Producto { Nombre = "Anticuchos", Precio = 28.0m, CantidadStock = 60 },
                        new Producto { Nombre = "Mazmorra Morada", Precio = 10.0m, CantidadStock = 100 },
                        new Producto { Nombre = "Picarones", Precio = 12.0m, CantidadStock = 110 },
                        new Producto { Nombre = "Crema Antiarrugas", Precio = 50.0m, CantidadStock = 40 },
                        new Producto { Nombre = "Protector Solar SPF 50", Precio = 20.0m, CantidadStock = 120 },
                        new Producto { Nombre = "Serum Vitamina C", Precio = 45.0m, CantidadStock = 60 },
                        new Producto { Nombre = "Crema Hidratante", Precio = 30.0m, CantidadStock = 80 },
                        new Producto { Nombre = "Labial Mate Rojo", Precio = 15.0m, CantidadStock = 200 },
                        new Producto { Nombre = "Corrector de Ojeras", Precio = 22.0m, CantidadStock = 70 },
                        new Producto { Nombre = "Paracetamol 500mg", Precio = 5.0m, CantidadStock = 500 },
                        new Producto { Nombre = "Ibuprofeno 200mg", Precio = 8.0m, CantidadStock = 400 },
                        new Producto { Nombre = "Aspirina 100mg", Precio = 4.0m, CantidadStock = 300 },
                        new Producto { Nombre = "Jarabe para la Tos", Precio = 12.0m, CantidadStock = 150 },
                        new Producto { Nombre = "Vitamina C 1000mg", Precio = 18.0m, CantidadStock = 200 },
                        new Producto { Nombre = "Alcohol en Gel 500ml", Precio = 10.0m, CantidadStock = 250 }
                    );
                }

                // Precargar Clientes
                if (!context.Clientes.Any())
                {
                    context.Clientes.AddRange(
                        new Cliente { Nombre = "Mario Vargas Llosa", CorreoElectronico = "mario.vargasllosa@example.com" },
                        new Cliente { Nombre = "Tula Rodríguez", CorreoElectronico = "tula.rodriguez@example.com" },
                        new Cliente { Nombre = "Eva Ayllón", CorreoElectronico = "eva.ayllon@example.com" },
                        new Cliente { Nombre = "Keanu Reeves", CorreoElectronico = "keanu.reeves@example.com" },
                        new Cliente { Nombre = "Scarlett Johansson", CorreoElectronico = "scarlett.johansson@example.com" },
                        new Cliente { Nombre = "Gian Marco", CorreoElectronico = "gian.marco@example.com" },
                        new Cliente { Nombre = "Magaly Medina", CorreoElectronico = "magaly.medina@example.com" },
                        new Cliente { Nombre = "Natalie Vértiz", CorreoElectronico = "natalie.vertiz@example.com" },
                        new Cliente { Nombre = "Leonardo DiCaprio", CorreoElectronico = "leonardo.dicaprio@example.com" },
                        new Cliente { Nombre = "Angelina Jolie", CorreoElectronico = "angelina.jolie@example.com" }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}

