using System;
namespace GestorOrdenes.Servicios.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }
    }
}

