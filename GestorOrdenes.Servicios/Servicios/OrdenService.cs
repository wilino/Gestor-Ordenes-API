using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Dominio.Interfaces;
using GestorOrdenes.Servicios.DTOs;
using GestorOrdenes.Servicios.Excepciones;
using GestorOrdenes.Servicios.Interfaces;
using GestorOrdenes.Servicios.Validaciones;

namespace GestorOrdenes.Servicios.Servicios
{
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IClienteRepository _clienteRepository;

        public OrdenService(IOrdenRepository ordenRepository, IProductoRepository productoRepository, IClienteRepository clienteRepository)
        {
            _ordenRepository = ordenRepository;
            _productoRepository = productoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task CrearOrden(CrearOrdenDto ordenDto)
        {
            using (var transaction = await _ordenRepository.BeginTransactionAsync())
            {
                try
                {
                    var cliente = await _clienteRepository.ObtenerPorId(ordenDto.ClienteId);
                    if (cliente == null)
                    {
                        throw new ClienteNoEncontradoException(ordenDto.ClienteId);
                    }

                    ValidarOrden.ValidarDetallesOrden(ordenDto.DetallesOrden);


                    foreach (var detalle in ordenDto.DetallesOrden)
                    {
                        var producto = await _productoRepository.ObtenerPorId(detalle.ProductoId);
                        if (producto == null)
                        {
                            throw new ProductoNoEncontradoException(detalle.ProductoId);
                        }

                        if (producto.CantidadStock < detalle.Cantidad)
                        {
                            throw new StockInsuficienteException(producto.Nombre, detalle.Cantidad, producto.CantidadStock);
                        }

                        await _productoRepository.ActualizarStock(detalle.ProductoId, detalle.Cantidad);
                    }

                    var nuevoOrden = new Orden
                    {
                        ClienteId = ordenDto.ClienteId,
                        FechaOrden = DateTime.Now,
                        DetallesOrden = new List<DetalleOrden>()
                        
                    };


                    foreach (var detalle in ordenDto.DetallesOrden)
                    {
                        var producto = await _productoRepository.ObtenerPorId(detalle.ProductoId);
                        nuevoOrden.DetallesOrden.Add(new DetalleOrden
                        {
                            ProductoId = detalle.ProductoId,
                            Cantidad = detalle.Cantidad,
                            Subtotal = detalle.Cantidad * producto.Precio
                        });
                    }


                    await _ordenRepository.CrearOrden(nuevoOrden);


                    await transaction.CommitAsync();
                }
                catch (Exception)
                {

                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<OrdenDto> ObtenerPorId(int id)
        {
            var orden = await _ordenRepository.ObtenerPorId(id);

            if (orden == null)
            {
                return null;
            }

            var ordenDto = new OrdenDto
            {
                Id = orden.Id,
                ClienteId = orden.ClienteId,
                NombreCliente=orden.Cliente.Nombre,
                FechaOrden = orden.FechaOrden,
                DetallesOrden = orden.DetallesOrden.Select(detalle => new DetalleOrdenDto
                {
                    ProductoId = detalle.ProductoId,
                    NombreProducto = detalle.Producto.Nombre, 
                    Cantidad = detalle.Cantidad,
                    Subtotal = detalle.Subtotal
                }).ToList()
            };

            return ordenDto;
        }
    }
}

