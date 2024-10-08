using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorOrdenes.Dominio.Entidades
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaOrden { get; set; }
        public List<DetalleOrden> DetallesOrden { get; set; }
    }
}