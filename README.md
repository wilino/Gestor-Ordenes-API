# Gestor de Órdenes API

## Descripción
El **Gestor de Órdenes API** es una API REST desarrollada en .NET 7 que permite gestionar un sistema de órdenes de compra. El sistema maneja entidades como **Clientes**, **Órdenes**, **Productos**, y los detalles de las órdenes (productos que el cliente ha comprado), todo ello con relaciones maestro-detalle. La API permite realizar operaciones como la creación, consulta y gestión de órdenes, asegurando la consistencia de los datos mediante transacciones.

### Entidades Principales:
- **Cliente**: Representa a un cliente que realiza pedidos.
- **Producto**: Representa los productos que se pueden comprar, con un stock y precio asociados.
- **Orden**: Una orden de compra que pertenece a un cliente.
- **DetalleOrden**: Contiene los detalles de los productos comprados en una orden, como la cantidad y el subtotal.

## Características
- **Ciclo de vida de una orden**: Un cliente realiza una orden que incluye uno o varios productos. La API valida que haya suficiente stock disponible antes de realizar la transacción.
- **Transacciones**: Todas las operaciones de creación de órdenes se realizan dentro de una transacción para asegurar la integridad de los datos. Si alguna parte del proceso falla, se revierte todo (rollback).
- **Base de datos en memoria**: La API utiliza una base de datos en memoria para pruebas rápidas. Cada vez que la aplicación se reinicia, los datos precargados se reinicializan.
- **Datos precargados**: Se incluyen productos y clientes precargados para realizar pruebas iniciales con la API.

## Datos Precargados
Al iniciar la aplicación, se precargan datos para **Clientes** y **Productos** mediante el archivo `CargadorDatos.cs`

## Endpoints Principales

### 1. Obtener una Orden por ID
- **URL**: `/api/Orden/{id}`
- **Método**: GET
- **Descripción**: Recupera los detalles de una orden por su ID.
- **Respuesta**:
  ```json
  {
    "id": 1,
    "clienteId": 1,
    "nombreCliente": "Mario Vargas Llosa",
    "fechaOrden": "2024-10-01T00:00:00",
    "detallesOrden": [
      {
        "productoId": 1,
        "nombreProducto": "Ceviche Clásico",
        "cantidad": 2,
        "subtotal": 50.00
      }
    ]
  }
  ```

### 2. Crear una Orden
- **URL**: `/api/Orden`
- **Método**: POST
- **Descripción**: Crea una nueva orden para un cliente específico.
- **Body**:
  ```json
  {
    "clienteId": 1,
    "detalles": [
      {
        "productoId": 1,
        "cantidad": 10
      }
    ]
  }
  ```
- **Validaciones**:
  - Verifica que el **cliente** exista.
  - Verifica que haya **stock suficiente** para los productos en la orden.
  - Si alguna validación falla, se hace rollback y no se procesa la orden.
 
## Herramientas Utilizadas
- **.NET 7**
- **Entity Framework Core** (con base de datos en memoria para pruebas)
- **Swagger** para la documentación de la API

**Nota**: Este proyecto incluye datos precargados y es ideal para hacer pruebas rápidas. Si deseas utilizar una base de datos persistente, puedes cambiar la configuración de **Entity Framework** para conectarlo a una base de datos SQL o cualquier otro proveedor.
