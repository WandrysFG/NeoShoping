//using System;
//using NeoShoping.Entities;
//using NeoShoping.Helpers.ProductoHelpers;

//namespace NeoShoping.Helpers.OrdenHelpers
//{
//    public static class OrdenInputHelper
//    {
//        public static int LeerEntero(string mensaje)
//        {
//            int valor;
//            Console.Write(mensaje);
//            while (!int.TryParse(Console.ReadLine(), out valor))
//            {
//                OrdenValidacionHelper.MostrarError("Ingrese un número entero: ");
//            }
//            return valor;
//        }

//        public static decimal LeerDecimal(string mensaje)
//        {
//            decimal valor;
//            Console.Write(mensaje);
//            while (!decimal.TryParse(Console.ReadLine(), out valor))
//            {
//                OrdenValidacionHelper.MostrarError("Entrada inválida. Intente de nuevo: ");
//            }
//            return valor;
//        }

//        public static string LeerTextoNoVacio(string mensaje)
//        {
//            string texto;
//            Console.Write(mensaje);
//            do
//            {
//                texto = Console.ReadLine();
//                if (string.IsNullOrWhiteSpace(texto))
//                {
//                    OrdenValidacionHelper.MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
//                }
//            } while (string.IsNullOrWhiteSpace(texto));
//            return texto.Trim();
//        }

//        public static DateTime LeerFecha(string mensaje)
//        {
//            DateTime fecha;
//            Console.Write(mensaje);
//            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
//            {
//                OrdenValidacionHelper.MostrarError("Fecha inválida. Formato esperado: yyyy-mm-dd");
//            }
//            return fecha;
//        }

//        public static string LeerTextoOpcional(string mensaje, string valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            return string.IsNullOrWhiteSpace(entrada) ? valorActual : entrada.Trim();
//        }

//        public static decimal LeerDecimalOpcional(string mensaje, decimal valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            if (decimal.TryParse(entrada, out decimal resultado) && resultado > 0)
//                return resultado;
//            return valorActual;
//        }

//        public static DateTime LeerFechaOpcional(string mensaje, DateTime valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            if (DateTime.TryParse(entrada, out DateTime resultado))
//                return resultado;
//            return valorActual;
//        }

//        public static int LeerEnteroOpcional(string mensaje, int valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            if (int.TryParse(entrada, out int resultado) && resultado >= 0)
//                return resultado;
//            return valorActual;
//        }

//        public static void LeerYActualizarDatosOrden(Orden orden)
//        {
//            Console.WriteLine("Ingrese los nuevos datos (deje vacío para mantener el valor actual):\n");

//            int nuevoIdCliente = LeerEnteroOpcional("Nuevo ID Cliente: ", orden.IdCliente);
//            DateTime nuevaFecha = LeerFechaOpcional("Nueva fecha (yyyy-mm-dd): ", orden.FechaOrden);
//            decimal nuevoTotal = LeerDecimalOpcional("Nuevo total: ", orden.Total);
//            string nuevoEstado = LeerTextoOpcional("Nuevo estado: ", orden.Estado);

//            orden.IdCliente = nuevoIdCliente;
//            orden.FechaOrden = nuevaFecha;
//            orden.Total = nuevoTotal;
//            orden.Estado = nuevoEstado;
//        }
//    }
//}
