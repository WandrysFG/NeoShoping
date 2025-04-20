using System;
using System.Collections.Generic;
using NeoShopping.Entities;

namespace NeoShopping.Helpers
{
    public class InfoHelpers
    {
        public static string LeerNombreProveedor()
        {
            return InputHelper.LeerTextoNoVacio("Nombre del proveedor: ", 50);
        }

        public static string LeerTelefonoProveedor()
        {
            return InputHelper.LeerTextoNoVacio("\nTeléfono del proveedor: ", 20);
        }

        public static string LeerEmailProveedor()
        {
            return InputHelper.LeerTextoNoVacio("\nEmail del proveedor: ", 100);
        }

        public static string LeerDireccionProveedor()
        {
            return InputHelper.LeerTextoNoVacio("\nDirección del proveedor: ", 200);
        }

        public static string LeerRNCProveedor()
        {
            return InputHelper.LeerTextoNoVacio("\nRNC del proveedor: ", 15);
        }

        public static Proveedor ObtenerDatosProveedor()
        {
            string nombre = LeerNombreProveedor();
            string telefono = LeerTelefonoProveedor();
            string email = LeerEmailProveedor();
            string direccion = LeerDireccionProveedor();
            string rnc = LeerRNCProveedor();

            return new Proveedor(nombre, telefono, email, direccion, rnc);
        }

        public static string LeerNombreProducto()
        {
            return InputHelper.LeerTextoNoVacio("Nombre del producto: ");
        }

        public static string LeerDescripcionProducto()
        {
            return InputHelper.LeerTextoNoVacio("\nDescripción del producto: ");
        }

        public static decimal LeerPrecioProducto()
        {
            return InputHelper.LeerDecimal("\nPrecio del producto: ");
        }

        public static int LeerStockProducto()
        {
            return InputHelper.LeerEntero("\nStock del producto: ");
        }

        public static int LeerIdProveedor()
        {
            return InputHelper.LeerEntero("\nID del proveedor: ");
        }

        public static Producto ObtenerDatosProducto()
        {
            string nombre = LeerNombreProducto();
            string descripcion = LeerDescripcionProducto();
            decimal precio = LeerPrecioProducto();
            int stock = LeerStockProducto();
            int idProveedor = LeerIdProveedor();

            return new Producto(nombre, precio, stock, descripcion)
            {
                IdProveedor = idProveedor
            };
        }

        public static int LeerIdCliente()
        {
            return InputHelper.LeerEntero("ID del cliente: ");
        }

        public static DateTime LeerFechaOrden()
        {
            return InputHelper.LeerFecha("\nFecha de la orden (yyyy-mm-dd): ");
        }

        public static decimal LeerTotalOrden()
        {
            return InputHelper.LeerDecimal("\nTotal de la orden: ");
        }

        public static string LeerEstadoOrden()
        {
            return InputHelper.LeerTextoNoVacio("\nEstado de la orden: ");
        }

        public static Orden ObtenerDatosOrden()
        {
            int idCliente = LeerIdCliente();
            int idProveedor = LeerIdProveedor();
            DateTime fecha = LeerFechaOrden();
            decimal total = LeerTotalOrden();
            string estado = LeerEstadoOrden();

            return new Orden(idCliente, idProveedor, fecha, total, estado);
        }

        public static DateTime LeerFechaEntrega()
        {
            return InputHelper.LeerFecha("\nFecha de entrega (YYYY-MM-DD): ");
        }

        public static string LeerRecibidoPor()
        {
            return InputHelper.LeerTextoNoVacio("\nRecibido por: ");
        }

        public static string LeerObservaciones()
        {
            return InputHelper.LeerTextoOpcional("\nObservaciones (opcional): ");
        }

        public static Entrega ObtenerDatosEntrega()
        {
            int idOrden = LeerIdOrden();
            DateTime fechaEntrega = LeerFechaEntrega();
            string recibidoPor = LeerRecibidoPor();
            string observaciones = LeerObservaciones();

            return new Entrega(idOrden, fechaEntrega, recibidoPor, observaciones);
        }

        public static int LeerIdOrden()
        {
            return InputHelper.LeerEntero("Ingrese el ID de la orden: ");
        }

        public static int LeerIdProducto()
        {
            return InputHelper.LeerEntero("\nIngrese el ID del producto: ");
        }

        public static int LeerCantidad()
        {
            return InputHelper.LeerEntero("\nIngrese la Cantidad: ");
        }

        public static decimal LeerPrecioUnitario()
        {
            return InputHelper.LeerDecimal("\nIngrese el Precio unitario: ");
        }

        public static DetalleOrden ObtenerDatosDetalleOrden()
        {
            int idOrden = LeerIdOrden();
            int idProducto = LeerIdProducto();
            int cantidad = LeerCantidad();
            decimal precioUnitario = LeerPrecioUnitario();

            return new DetalleOrden(idOrden, idProducto, cantidad, precioUnitario);
        }

        public static string LeerNombreCliente()
        {
            return InputHelper.LeerTextoNoVacio("Nombre del cliente: ", 50);
        }

        public static string LeerApellidoCliente()
        {
            return InputHelper.LeerTextoNoVacio("\nApellido del cliente: ", 100);
        }

        public static string LeerTelefonoCliente()
        {
            return InputHelper.LeerTextoNoVacio("\nTeléfono del cliente (formato 000-000-0000): ");
        }

        public static string LeerEmailCliente()
        {
            return InputHelper.LeerTextoNoVacio("\nEmail del cliente: ", 100);
        }

        public static string LeerDireccionCliente()
        {
            return InputHelper.LeerTextoNoVacio("\nDirección del cliente: ", 200);
        }

        public static Cliente ObtenerDatosCliente()
        {
            string nombre = LeerNombreCliente();
            string apellido = LeerApellidoCliente();
            string telefono = LeerTelefonoCliente();
            string email = LeerEmailCliente();
            string direccion = LeerDireccionCliente();

            return new Cliente(nombre, apellido, telefono, email, direccion);
        }
    }
}