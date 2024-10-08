using System;
namespace GestorOrdenes.Servicios.Validaciones
{
    public static class ValidarCliente
    {
        public static void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacío.");
            }
        }

        public static void ValidarCorreoElectronico(string correoElectronico)
        {
            if (string.IsNullOrWhiteSpace(correoElectronico) || !correoElectronico.Contains("@"))
            {
                throw new ArgumentException("El correo electrónico no es válido.");
            }
        }
    }
}

