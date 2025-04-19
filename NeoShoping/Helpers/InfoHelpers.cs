using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoShoping.Entities;

namespace NeoShoping.Helpers
{
    public class InfoHelpers
    {
        // Proveedor
        public static string LeerNombreProveedor()
        {
            return InputHelper.LeerTextoNoVacio("Nombre del proveedor: ", 50);
        }

        public static string LeerTelefonoProveedor()
        {
            return InputHelper.LeerTextoNoVacio("Teléfono del proveedor: ", 20);
        }

        public static string LeerEmailProveedor()
        {
            return InputHelper.LeerTextoNoVacio("Email del proveedor: ", 100);
        }

        public static string LeerDireccionProveedor()
        {
            return InputHelper.LeerTextoNoVacio("Dirección del proveedor: ", 200);
        }

        public static string LeerRNCProveedor()
        {
            return InputHelper.LeerTextoNoVacio("RNC del proveedor: ", 15);
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


        // Producto
        public static string LeerNombreProducto()
        {
            return InputHelper.LeerTextoNoVacio("Nombre del producto: ");
        }

        public static string LeerDescripcionProducto()
        {
            return InputHelper.LeerTextoNoVacio("Descripción del producto: ");
        }

        public static decimal LeerPrecioProducto()
        {
            return InputHelper.LeerDecimal("Precio del producto: ");
        }

        public static int LeerStockProducto()
        {
            return InputHelper.LeerEntero("Stock del producto: ");
        }

        public static int LeerIdProveedor()
        {
            return InputHelper.LeerEntero("ID del proveedor: ");
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


        // Orden
        public static int LeerIdCliente()
        {
            return InputHelper.LeerEntero("ID del cliente: ");
        }

        public static DateTime LeerFechaOrden()
        {
            return InputHelper.LeerFecha("Fecha de la orden (yyyy-mm-dd): ");
        }

        public static decimal LeerTotalOrden()
        {
            return InputHelper.LeerDecimal("Total de la orden: ");
        }

        public static string LeerEstadoOrden()
        {
            return InputHelper.LeerTextoNoVacio("Estado de la orden: ");
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

        // Entrega
        public static DateTime LeerFechaEntrega()
        {
            return InputHelper.LeerFecha("Fecha de entrega (YYYY-MM-DD): ");
        }

        public static string LeerRecibidoPor()
        {
            return InputHelper.LeerTextoNoVacio("Recibido por: ");
        }

        public static string LeerObservaciones()
        {
            return InputHelper.LeerTextoOpcional("Observaciones (opcional): ");
        }

        public static Entrega ObtenerDatosEntrega()
        {
            int idOrden = LeerIdOrden();
            DateTime fechaEntrega = LeerFechaEntrega();
            string recibidoPor = LeerRecibidoPor();
            string observaciones = LeerObservaciones();

            return new Entrega(idOrden, fechaEntrega, recibidoPor, observaciones);
        }


        // Detalle Orden
        public static int LeerIdOrden()
        {
            return InputHelper.LeerEntero("Ingrese el ID de la orden: ");
        }

        public static int LeerIdProducto()
        {
            return InputHelper.LeerEntero("Ingrese el ID del producto: ");
        }

        public static int LeerCantidad()
        {
            return InputHelper.LeerEntero("Ingrese la Cantidad: ");
        }

        public static decimal LeerPrecioUnitario()
        {
            return InputHelper.LeerDecimal("Ingrese el Precio unitario: ");
        }

        public static decimal LeerSubTotal()
        {
            return InputHelper.LeerDecimal("Ingrese el subtotal: ");
        }

        public static DetalleOrden ObtenerDatosDetalleOrden()
        {
            int idOrden = LeerIdOrden();
            int idProducto = LeerIdProducto();
            int cantidad = LeerCantidad();
            decimal precioUnitario = LeerPrecioUnitario();
            decimal Subtotal = LeerSubTotal();

            return new DetalleOrden(idOrden, idProducto, cantidad, precioUnitario);
        }

        // Cliente
        public static string LeerNombreCliente()
        {
            return InputHelper.LeerTextoNoVacio("Nombre del cliente: ", 50);
        }

        public static string LeerApellidoCliente()
        {
            return InputHelper.LeerTextoNoVacio("Apellido del cliente: ", 100);
        }

        public static string LeerTelefonoCliente()
        {
            return InputHelper.LeerTextoNoVacio("Teléfono del cliente (formato 000-000-0000): ");
        }

        public static string LeerEmailCliente()
        {
            return InputHelper.LeerTextoNoVacio("Email del cliente: ", 100);
        }

        public static string LeerDireccionCliente()
        {
            return InputHelper.LeerTextoNoVacio("Dirección del cliente: ", 200);
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