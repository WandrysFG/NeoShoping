using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;

namespace NeoShoping.Presentation
{
    public class MensajesConsola
    {
        public static void MostrarMensajeDeExito()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProducto agregado correctamente.\n");
            Console.ResetColor();
            FrmProductos.MenuDeSalida();
        }

    }
}
