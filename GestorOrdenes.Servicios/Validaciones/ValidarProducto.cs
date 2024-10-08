using System;
namespace GestorOrdenes.Servicios.Validaciones
{
    public static class ValidarProducto
    {
        public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del producto no puede estar vacío.");
            }
        }

        public static void ValidarPrecio(decimal precio)
        {
            if (precio <= 0)
            {
                throw new ArgumentException("El precio del producto debe ser mayor que cero.");
            }
        }

        public static void ValidarCantidadStock(int cantidadStock)
        {
            if (cantidadStock < 0)
            {
                throw new ArgumentException("La cantidad en stock no puede ser negativa.");
            }
        }
    }
}

