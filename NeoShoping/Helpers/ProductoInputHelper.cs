using System;
using NeoShoping.Entities;

namespace NeoShoping.Helpers
{
    public static class ProductoInputHelper
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                ProductoValidacionHelper.MostrarError("Ingrese un numero entero: ");
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
                    Console.WriteLine("Ingrese un numero entero que sea 0 o mayor.");
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
                ProductoValidacionHelper.MostrarError("Entrada invalida. Intente de nuevo: ");
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
                    ProductoValidacionHelper.MostrarError("El campo no puede estar vacío. Intente de nuevo: ");
                }
            } while (string.IsNullOrWhiteSpace(texto));
            return texto.Trim();
        }

        public static string LeerTextoOpcional(string mensaje, string valorActual)
        {
            Console.Write(mensaje);
            string entrada = Console.ReadLine();
            return string.IsNullOrWhiteSpace(entrada) ? valorActual : entrada.Trim();
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

        public static void LeerYActualizarDatosProducto(Producto producto)
        {
            Console.WriteLine("Ingrese los nuevos datos (deje vacio para mantener el valor actual):\n");

            string nuevoNombre = ProductoInputHelper.LeerTextoOpcional("Nuevo nombre: ", producto.Nombre);
            string nuevaDescripcion = ProductoInputHelper.LeerTextoOpcional("Nueva descripción: ", producto.Descripcion);
            decimal nuevoPrecio = ProductoInputHelper.LeerDecimalOpcional("Nuevo precio: ", producto.Precio);
            int nuevoStock = ProductoInputHelper.LeerEnteroOpcional("Nuevo stock: ", producto.Stock);
            int nuevoIdProveedor = ProductoInputHelper.LeerEnteroOpcional("Nuevo ID Proveedor: ", producto.IdProveedor);

            producto.Nombre = nuevoNombre;
            producto.Descripcion = nuevaDescripcion;
            producto.Precio = nuevoPrecio;
            producto.Stock = nuevoStock;
            producto.IdProveedor = nuevoIdProveedor;
        }

    }
}
