//using System;
//using System.Text.RegularExpressions;
//using NeoShoping.Entities;

//namespace NeoShoping.Helpers.ProveedorHelpers
//{
//    public static class ProveedorInputHelper
//    {
//        public static string LeerEmailOpcional(string mensaje, string valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            return (!string.IsNullOrWhiteSpace(entrada) && entrada.Contains("@") && entrada.Length <= 100) ? entrada : valorActual;
//        }
//        public static string LeerTelefonoOpcional(string mensaje, string valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
//            return (!string.IsNullOrWhiteSpace(entrada) && regex.IsMatch(entrada)) ? entrada : valorActual;
//        }
//        public static int LeerEntero(string mensaje)
//        {
//            int valor;
//            Console.Write(mensaje);
//            while (!int.TryParse(Console.ReadLine(), out valor))
//            {
//                ProveedorValidacionHelper.MostrarError("Ingrese un numero entero: ");
//            }
//            return valor;
//        }

//        //public static string LeerTextoNoVacio(string mensaje)
//        //{
//        //    string texto;
//        //    Console.Write(mensaje);
//        //    do
//        //    {
//        //        texto = Console.ReadLine();
//        //        if (string.IsNullOrWhiteSpace(texto))
//        //        {
//        //            ProveedorValidacionHelper.MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
//        //        }
//        //    } while (string.IsNullOrWhiteSpace(texto));

//        //    return texto.Trim();
//        //}

//        public static string LeerTextoNoVacio(string mensaje, int maxLength)
//        {
//            string texto;
//            Console.Write(mensaje);
//            do
//            {
//                texto = Console.ReadLine();
//                if (string.IsNullOrWhiteSpace(texto))
//                {
//                    MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
//                }
//                else if (texto.Length > maxLength)
//                {
//                    MostrarError($"Máximo {maxLength} caracteres. Intente de nuevo: ");
//                    texto = string.Empty;
//                }
//            } while (string.IsNullOrWhiteSpace(texto));
//            return texto.Trim();
//        }

//        private static void MostrarError(string mensaje)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.Write(mensaje);
//            Console.ResetColor();
//        }

//        public static string LeerTextoOpcional(string mensaje, string valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            return string.IsNullOrWhiteSpace(entrada) ? valorActual : entrada.Trim();
//        }

//        public static void LeerYActualizarDatosProveedor(Proveedor proveedor)
//        {
//            Console.WriteLine("\nIngrese los nuevos datos (deje vacio para mantener el valor actual):\n");

//            string nuevoNombre = LeerTextoOpcional("Nuevo nombre: ", proveedor.Nombre);
//            string nuevoTelefono = LeerTextoOpcional("Nuevo telefono: ", proveedor.Telefono);
//            string nuevoEmail = LeerTextoOpcional("Nuevo email: ", proveedor.Email);
//            string nuevaDireccion = LeerTextoOpcional("Nueva direccion: ", proveedor.Direccion);
//            string nuevoRNC = LeerTextoOpcional("Nuevo RNC: ", proveedor.RNC);

//            proveedor.Nombre = nuevoNombre;
//            proveedor.Telefono = nuevoTelefono;
//            proveedor.Email = nuevoEmail;
//            proveedor.Direccion = nuevaDireccion;
//            proveedor.RNC = nuevoRNC;
//        }
//    }
//}
