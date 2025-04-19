using System;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Logic;

namespace NeoShoping.Presentation
{
    public class FrmDetalleOrden
    {
        public static void GestionarDetalleOrden()
        {
            var context = new NeoShopingDataContext();
            List<DetalleOrden> detallesOrden = context.DetallesOrden.ToList();

            bool back = false;
            int intentos = 0;

            MenuGestionarDetalleOrden();

            while (!back)
            {
                try
                {
                    Console.Write("Seleccione una opción: ");

                    string input = Console.ReadLine();
                    int option;

                    if (!int.TryParse(input, out option))
                    {
                        intentos++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrada inválida. Debes ingresar un número.\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                DetallesOrdenLogic.AgregarDetalleOrden();
                                break;
                            case 2:
                                Console.Clear();
                                DetallesOrdenLogic.VerOBuscarDetallesOrden();
                                break;
                            case 3:
                                Console.Clear();
                                DetallesOrdenLogic.EditarDetalleOrden();
                                break;
                            case 4:
                                Console.Clear();
                                DetallesOrdenLogic.EliminarDetalleOrden();
                                break;
                            case 5:
                                back = true;
                                Console.Clear();
                                InicioUI.MostrarMenuOpciones();
                                InicioUI.MostrarMenu();
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                                Console.ResetColor();
                                intentos++;
                                break;
                        }

                        if (intentos >= 3)
                        {
                            MenuGestionarDetalleOrden("simple");
                            intentos = 0;
                        }
                    }
                }
                catch (FormatException ex)
                {
                    intentos++;
                    Console.WriteLine($"Formato incorrecto: {ex.Message}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}\n");
                }
            }
        }

        public static void MenuGestionarDetalleOrden()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════ GESTIONAR DETALLE ORDEN ═══════╗");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║ 1- Agregar Detalle de Orden           ║");
            Console.WriteLine("║ 2- Ver/Buscar Detalle de Orden        ║");
            Console.WriteLine("║ 3- Editar Detalle de Orden            ║");
            Console.WriteLine("║ 4- Eliminar Detalle de Orden          ║");
            Console.WriteLine("║ 5- Volver atrás                       ║");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("╚═══════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuGestionarDetalleOrden(string estilo)
        {
            if (estilo == "simple")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔══════════ OPCIONES VALIDAS ══════════╗");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("║ 1- Agregar Detalle de Orden          ║");
                Console.WriteLine("║ 2- Ver/Buscar Detalle de Orden       ║");
                Console.WriteLine("║ 3- Editar Detalle de Orden           ║");
                Console.WriteLine("║ 4- Eliminar Detalle de Orden         ║");
                Console.WriteLine("║ 5- Volver atrás                      ║");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("╚══════════════════════════════════════╝\n");
                Console.ResetColor();
            }
        }

        public static void MenuVerOBuscarDetalleOrden()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════ VER/BUSCAR DETALLE ORDEN ═══════╗");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("║ 1- Ver Todos los Detalles de Orden    ║");
            Console.WriteLine("║ 2- Buscar Detalle de Orden            ║");
            Console.WriteLine("║ 3- Volver atrás                       ║");
            Console.WriteLine("║                                       ║");
            Console.WriteLine("╚═══════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuDeSalida()
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n╔═══════════════════════╗");
                Console.WriteLine("║ 1- Volver atrás       ║");
                Console.WriteLine("║ 2- Salir              ║");
                Console.WriteLine("╚═══════════════════════╝\n");
                Console.ResetColor();

                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        opcionValida = true;
                        Console.Clear();
                        GestionarDetalleOrden();
                        break;
                    case "2":
                        opcionValida = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nGracias por usar NeoShoping. ¡Hasta pronto!");
                        Console.ResetColor();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
