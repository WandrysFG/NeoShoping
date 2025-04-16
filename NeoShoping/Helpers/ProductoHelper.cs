using System;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Presentation;

namespace NeoShoping.Helpers
{
    public static partial class ProductoHelper
    {
        public static void MostrarListaProductos(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╚═════════════════════ Lista de Productos ═════════════════════╝\n");
            Console.ResetColor();

            var productos = context.Productos.ToList();

            if (productos.Any())
            {
                foreach (var p in productos)
                {
                    Console.WriteLine($"ID: {p.IdProducto} ║ Nombre: {p.Nombre} ║ Precio: {p.Precio} ║ Stock: {p.Stock} ║ ID Proveedor: {p.IdProveedor}");
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados.");
            }

            FrmProductos.Pausa();
        }


        public static void BuscarProductoPorId(List<Producto> productos)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╚═════════════════════ Buscar Producto ═════════════════════╝\n");
            Console.ResetColor();

            int id = ProductoInputHelper.LeerEntero("Ingrese el ID del producto: ");
            var producto = productos.FirstOrDefault(p => p.IdProducto == id);

            if (producto != null)
            {
                Console.WriteLine($"\n║ ID: {producto.IdProducto}");
                Console.WriteLine($"║ Nombre: {producto.Nombre}");
                Console.WriteLine($"║ Descripción: {producto.Descripcion}");
                Console.WriteLine($"║ Precio: {producto.Precio}");
                Console.WriteLine($"║ Stock: {producto.Stock}");
                Console.WriteLine($"║ ID Proveedor: {producto.IdProveedor}");
            }
            else
            {
                Console.WriteLine("\nProducto no encontrado. Verifique que el ID sea correcto.");
            }

            FrmProductos.Pausa();
        }
    }
}



//using System;

//namespace NeoShoping.Helpers
//{
//    public static class ProductoHelper
//    {
//        public static int LeerEntero(string mensaje)
//        {
//            int valor;
//            Console.Write(mensaje);
//            while (!int.TryParse(Console.ReadLine(), out valor))
//            {
//                MostrarError("Entrada inválida. Intente de nuevo: ");
//            }
//            return valor;
//        }

//        public static decimal LeerDecimal(string mensaje)
//        {
//            decimal valor;
//            Console.Write(mensaje);
//            while (!decimal.TryParse(Console.ReadLine(), out valor))
//            {
//                MostrarError("Entrada inválida. Intente de nuevo: ");
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
//                    MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
//                }
//            } while (string.IsNullOrWhiteSpace(texto));
//            return texto.Trim();
//        }

//        public static void Pausa()
//        {
//            Console.WriteLine("\nPresione una tecla para continuar...");
//            Console.ReadKey();
//            Console.Clear();
//        }

//        public static string LeerTextoOpcional(string mensaje, string valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            return string.IsNullOrWhiteSpace(entrada) ? valorActual: entrada.Trim();
//        }

//        public static decimal LeerDecimalOpcional(string mensaje, decimal valorActual)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            if (decimal.TryParse(entrada, out decimal resultado) && resultado > 0)
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

//        public static T LeerValorOpcional<T>(string mensaje, T valorActual, Func<string, (bool exito, T valor)> convertidor)
//        {
//            Console.Write(mensaje);
//            string entrada = Console.ReadLine();
//            if (!string.IsNullOrWhiteSpace(entrada))
//            {
//                var (exito, valor) = convertidor(entrada);
//                if (exito) return valor;
//            }
//            return valorActual;
//        }

//        public static string LeerNombreProducto()
//        {
//            return LeerTextoNoVacio("Nombre del producto: ");
//        }

//        public static string LeerDescripcionProducto()
//        {
//            return LeerTextoNoVacio("Descripción del producto: ");
//        }

//        public static decimal LeerPrecioProducto()
//        {
//            return LeerDecimal("Precio del producto: ");
//        }

//        public static int LeerStockProducto()
//        {
//            return LeerEntero("Stock del producto: ");
//        }

//        public static int LeerIdProveedor()
//        {
//            return LeerEntero("ID del proveedor: ");
//        }

//        private static void MostrarError(string mensaje)
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.Write(mensaje);
//            Console.ResetColor();
//        }
//    }
//}
