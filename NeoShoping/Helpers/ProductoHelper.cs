using System;

namespace NeoShoping.Helpers
{
    public static class ProductoHelper
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

        public static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor))
            {
                MostrarError("Entrada inválida. Intente de nuevo: ");
            }
            return valor;
        }

        public static string LeerTextoNoVacio(string mensaje)
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
            } while (string.IsNullOrWhiteSpace(texto));
            return texto.Trim();
        }

        public static void Pausa()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static string LeerTextoOpcional(string mensaje, string valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) ? valorActual: entrada.Trim();
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

        public static T LeerValorOpcional<T>(string mensaje, T valorActual, Func<string, (bool exito, T valor)> convertidor)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entrada))
            {
                var (exito, valor) = convertidor(entrada);
                if (exito) return valor;
            }
            return valorActual;
        }

        public static string LeerNombreProducto()
        {
            return LeerTextoNoVacio("Nombre del producto: ");
        }

        public static string LeerDescripcionProducto()
        {
            return LeerTextoNoVacio("Descripción del producto: ");
        }

        public static decimal LeerPrecioProducto()
        {
            return LeerDecimal("Precio del producto: ");
        }

        public static int LeerStockProducto()
        {
            return LeerEntero("Stock del producto: ");
        }

        public static int LeerIdProveedor()
        {
            return LeerEntero("ID del proveedor: ");
        }

        private static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(mensaje);
            Console.ResetColor();
        }
    }
}
