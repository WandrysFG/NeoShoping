using System;

namespace NeoShoping.Helpers
{
    public static class ProductoValidacionHelper
    {
        public static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(mensaje);
            Console.ResetColor();
        }
    }
}
