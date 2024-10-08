using System;
namespace GestorOrdenes.Servicios.DTOs
{
    public class DetalleOrdenDto
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } 
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }

}

