using System;
using System.Text.RegularExpressions;
using NeoShoping.Entities;

namespace NeoShoping.Helpers
{
    public static class InputHelper
    {
        // Metodos generales
        public static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                MostrarError("\nIngrese un número entero válido: \n");
            }
            return valor;
        }

        public static int LeerEnteroNoNegativo(string mensaje)
        {
            int valor;
            do
            {
                Console.Write(mensaje);
                if (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
                {
                    MostrarError("\nIngrese un número entero que sea 0 o mayor.\n");
                }
            } while (valor < 0);

            return valor;
        }

        public static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor))
            {
                MostrarError("\nEntrada inválida. Intente de nuevo: \n");
            }
            return valor;
        }

        public static string LeerTextoNoVacio(string mensaje, int maxLength = int.MaxValue)
        {
            string texto;
            Console.Write(mensaje);
            do
            {
                texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    MostrarError("\nEl campo no puede estar vacío. Intente de nuevo: \n");
                }
                else if (texto.Length > maxLength)
                {
                    MostrarError($"\nMáximo {maxLength} caracteres. Intente de nuevo: \n");
                    texto = string.Empty;
                }
            } while (string.IsNullOrWhiteSpace(texto));
            return texto.Trim();
        }

        public static string LeerTextoOpcional(string mensaje, string valorActual, int maxLength = int.MaxValue)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) ? valorActual : entrada.Trim().Length <= maxLength ? entrada.Trim() : valorActual;
        }

        public static string LeerTextoOpcional(string mensaje)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) ? "" : entrada.Trim();
        }

        public static decimal LeerDecimalOpcional(string mensaje, decimal valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (decimal.TryParse(entrada, out decimal resultado) && resultado > 0)
                return resultado;
            return valorActual;
        }

        public static int LeerEnteroOpcional(string mensaje, int valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int resultado) && resultado >= 0)
                return resultado;
            return valorActual;
        }

        public static string LeerEmailOpcional(string mensaje, string valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return (!string.IsNullOrWhiteSpace(entrada) && entrada.Contains("@") && entrada.Length <= 100) ? entrada : valorActual;
        }

        public static string LeerTelefonoOpcional(string mensaje, string valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            return (!string.IsNullOrWhiteSpace(entrada) && regex.IsMatch(entrada)) ? entrada : valorActual;
        }

        public static DateTime LeerFechaOpcional(string mensaje, DateTime valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (DateTime.TryParse(entrada, out DateTime resultado))
                return resultado;
            return valorActual;
        }

        private static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(mensaje);
            Console.ResetColor();
        }

        // Metodos para Producto
        public static void LeerYActualizarDatosProducto(Producto producto)
        {
            Console.WriteLine("Ingrese los nuevos datos (deje vacío para mantener el valor actual):\n");

            string nuevoNombre = LeerTextoOpcional("Nuevo nombre: ", producto.Nombre);
            string nuevaDescripcion = LeerTextoOpcional("Nueva descripción: ", producto.Descripcion);
            decimal nuevoPrecio = LeerDecimalOpcional("Nuevo precio: ", producto.Precio);
            int nuevoStock = LeerEnteroOpcional("Nuevo stock: ", producto.Stock);
            int nuevoIdProveedor = LeerEnteroOpcional("Nuevo ID Proveedor: ", producto.IdProveedor);

            producto.Nombre = nuevoNombre;
            producto.Descripcion = nuevaDescripcion;
            producto.Precio = nuevoPrecio;
            producto.Stock = nuevoStock;
            producto.IdProveedor = nuevoIdProveedor;
        }

        // Metodo para Proveedor
        public static void LeerYActualizarDatosProveedor(Proveedor proveedor)
        {
            Console.WriteLine("\nIngrese los nuevos datos (deje vacío para mantener el valor actual):\n");

            string nuevoNombre = LeerTextoOpcional("Nuevo nombre: ", proveedor.Nombre);
            string nuevoTelefono = LeerTelefonoOpcional("Nuevo teléfono (formato 000-000-0000): ", proveedor.Telefono);
            string nuevoEmail = LeerEmailOpcional("Nuevo email: ", proveedor.Email);
            string nuevaDireccion = LeerTextoOpcional("Nueva dirección: ", proveedor.Direccion);
            string nuevoRNC = LeerTextoOpcional("Nuevo RNC: ", proveedor.RNC);

            proveedor.Nombre = nuevoNombre;
            proveedor.Telefono = nuevoTelefono;
            proveedor.Email = nuevoEmail;
            proveedor.Direccion = nuevaDireccion;
            proveedor.RNC = nuevoRNC;
        }

        // Metodos para Orden
        public static DateTime LeerFecha(string mensaje)
        {
            DateTime fecha;
            Console.Write(mensaje);
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                ValidacionesHelper.MostrarError("Fecha inválida. Formato esperado: yyyy-mm-dd");
            }
            return fecha;
        }

        public static int LeerEnteroOrden(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                ValidacionesHelper.MostrarError("Ingrese un número entero: ");
            }
            return valor;
        }

        public static decimal LeerDecimalOrden(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor))
            {
                ValidacionesHelper.MostrarError("Entrada inválida. Intente de nuevo: ");
            }
            return valor;
        }

        public static string LeerTextoNoVacioOrden(string mensaje)
        {
            string texto;
            Console.Write(mensaje);
            do
            {
                texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    ValidacionesHelper.MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
                }
            } while (string.IsNullOrWhiteSpace(texto));
            return texto.Trim();
        }

        public static DateTime LeerFechaOrden(string mensaje)
        {
            DateTime fecha;
            Console.Write(mensaje);
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                ValidacionesHelper.MostrarError("Fecha inválida. Formato esperado: yyyy-mm-dd");
            }
            return fecha;
        }

        public static void LeerYActualizarDatosOrden(Orden orden)
        {
            Console.WriteLine("Ingrese los nuevos datos (deje vacío para mantener el valor actual):\n");

            int nuevoIdCliente = LeerEnteroOrden("Nuevo ID Cliente: ");
            DateTime nuevaFecha = LeerFechaOrden("Nueva fecha (yyyy-mm-dd): ");
            decimal nuevoTotal = LeerDecimalOrden("Nuevo total: ");
            string nuevoEstado = LeerTextoNoVacioOrden("Nuevo estado: ");

            orden.IdCliente = nuevoIdCliente;
            orden.FechaOrden = nuevaFecha;
            orden.Total = nuevoTotal;
            orden.Estado = nuevoEstado;
        }

        // Metodo para Entrega
        public static void LeerYActualizarDatosEntrega(Entrega entrega)
        {
            Console.WriteLine("\nIngrese los nuevos datos de la entrega (deje vacío para mantener el valor actual):\n");

            int nuevoIdOrden = LeerEnteroOpcional("Nuevo ID de Orden: ", entrega.IdOrden);
            DateTime nuevaFechaEntrega = LeerFechaOpcional("Nueva Fecha de Entrega (yyyy-mm-dd): ", entrega.FechaEntrega);
            string nuevoRecibidoPor = LeerTextoOpcional("Nuevo nombre de quien recibió: ", entrega.RecibidoPor, 50);
            string nuevasObservaciones = LeerTextoOpcional("Nuevas observaciones: ", entrega.Observaciones, 250);

            entrega.IdOrden = nuevoIdOrden;
            entrega.FechaEntrega = nuevaFechaEntrega;
            entrega.RecibidoPor = nuevoRecibidoPor;
            entrega.Observaciones = nuevasObservaciones;
        }

        // Metodo DetalleOrden
        public static void LeerYActualizarDatosDetalleOrden(DetalleOrden detalle)
        {
            Console.WriteLine("\nIngrese los nuevos datos del detalle de orden (deje vacío para mantener el valor actual):\n");

            int nuevoIdOrden = LeerEnteroOpcional("Nuevo ID de Orden: ", detalle.IdOrden);
            int nuevoIdProducto = LeerEnteroOpcional("Nuevo ID de Producto: ", detalle.IdProducto);
            int nuevaCantidad = LeerEnteroOpcional("Nueva cantidad: ", detalle.Cantidad);
            decimal nuevoPrecioUnitario = LeerDecimalOpcional("Nuevo precio unitario: ", detalle.PrecioUnitario);
            decimal nuevoSubtotal = LeerDecimalOpcional("Nuevo subtotal: ", detalle.Subtotal);

            detalle.IdOrden = nuevoIdOrden;
            detalle.IdProducto = nuevoIdProducto;
            detalle.Cantidad = nuevaCantidad;
            detalle.PrecioUnitario = nuevoPrecioUnitario;
        }

        // Metodo para Cliente
        public static void LeerYActualizarDatosCliente(Cliente cliente)
        {
            Console.WriteLine("\nIngrese los nuevos datos del cliente (deje vacío para mantener el valor actual):\n");

            string nuevoNombre = LeerTextoOpcional("Nuevo nombre: ", cliente.Nombre, 50);
            string nuevoApellido = LeerTextoOpcional("Nuevo apellido: ", cliente.Apellido, 100);
            string nuevoTelefono = LeerTelefonoOpcional("Nuevo teléfono (formato 000-000-0000): ", cliente.Telefono);
            string nuevoEmail = LeerEmailOpcional("Nuevo email: ", cliente.Email);
            string nuevaDireccion = LeerTextoOpcional("Nueva dirección: ", cliente.Direccion, 200);

            cliente.Nombre = nuevoNombre;
            cliente.Apellido = nuevoApellido;
            cliente.Telefono = nuevoTelefono;
            cliente.Email = nuevoEmail;
            cliente.Direccion = nuevaDireccion;
        }

    }
}
