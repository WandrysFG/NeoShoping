using System;
using System.Text.RegularExpressions;

namespace NeoShoping.Helpers
{
    public static class ProveedorHelper
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                MostrarError("Entrada inválida. Intente de nuevo: ");
            }
            return valor;
        }

        public static string LeerTextoNoVacio(string mensaje, int maxLength)
        {
            string texto;
            Console.Write(mensaje);
            do
            {
                texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                {
                    MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
                }
                else if (texto.Length > maxLength)
                {
                    MostrarError($"Máximo {maxLength} caracteres. Intente de nuevo: ");
                    texto = string.Empty;
                }
            } while (string.IsNullOrWhiteSpace(texto));
            return texto.Trim();
        }

        public static string LeerTelefono(string mensaje)
        {
            string telefono;
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            Console.Write(mensaje);
            do
            {
                telefono = Console.ReadLine();
                if (!regex.IsMatch(telefono ?? ""))
                {
                    MostrarError("Formato de teléfono inválido (Ej: 809-123-4567). Intente de nuevo: ");
                    telefono = null;
                }
            } while (string.IsNullOrWhiteSpace(telefono));
            return telefono;
        }

        public static string LeerEmail(string mensaje)
        {
            string email;
            Console.Write(mensaje);
            do
            {
                email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
                {
                    MostrarError("Formato de email inválido. Intente de nuevo: ");
                    email = null;
                }
                else if (email?.Length > 100)
                {
                    MostrarError("Máximo 100 caracteres para el email. Intente de nuevo: ");
                    email = null;
                }
            } while (string.IsNullOrWhiteSpace(email));
            return email.Trim();
        }

        public static void Pausa()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static string LeerTextoOpcional(string mensaje, string valorActual, int maxLength)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) || entrada.Length > maxLength ? valorActual : entrada.Trim();
        }

        public static string LeerTelefonoOpcional(string mensaje, string valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            Regex regex = new Regex(@"^\d{3}-\d{3}-\d{4}$");
            return (!string.IsNullOrWhiteSpace(entrada) && regex.IsMatch(entrada)) ? entrada : valorActual;
        }

        public static string LeerEmailOpcional(string mensaje, string valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return (!string.IsNullOrWhiteSpace(entrada) && entrada.Contains("@") && entrada.Length <= 100) ? entrada : valorActual;
        }

        public static int LeerIdProveedor()
        {
            return LeerEntero("ID del proveedor: ");
        }

        public static string LeerNombreProveedor()
        {
            return LeerTextoNoVacio("Nombre del proveedor: ", 50);
        }

        public static string LeerTelefonoProveedor()
        {
            return LeerTelefono("Teléfono del proveedor (Ej: 809-123-4567): ");
        }

        public static string LeerEmailProveedor()
        {
            return LeerEmail("Email del proveedor: ");
        }

        public static string LeerDireccionProveedor()
        {
            return LeerTextoNoVacio("Dirección del proveedor: ", 200);
        }

        public static string LeerRNCProveedor()
        {
            return LeerTextoNoVacio("RNC del proveedor: ", 15);
        }

        public static string LeerNombreProveedorOpcional(string valorActual)
        {
            return LeerTextoOpcional("Nombre del proveedor: ", valorActual, 50);
        }

        public static string LeerTelefonoProveedorOpcional(string valorActual)
        {
            return LeerTelefonoOpcional("Teléfono del proveedor (Ej: 809-123-4567): ", valorActual);
        }

        public static string LeerEmailProveedorOpcional(string valorActual)
        {
            return LeerEmailOpcional("Email del proveedor: ", valorActual);
        }

        public static string LeerDireccionProveedorOpcional(string valorActual)
        {
            return LeerTextoOpcional("Dirección del proveedor: ", valorActual, 200);
        }

        public static string LeerRNCProveedorOpcional(string valorActual)
        {
            return LeerTextoOpcional("RNC del proveedor: ", valorActual, 15);
        }

        private static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(mensaje);
            Console.ResetColor();
        }
    }
}
