using System;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Logic;

namespace NeoShoping.Presentation
{
    public class FrmOrdenes
    {
        public static void GestionarOrdenes()
        {
            var context = new NeoShopingDataContext();
            List<Orden> ordenes = context.Ordenes.ToList();

            bool back = false;
            int intentos = 0;

            MenuGestionarOrdenes();

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
                        Console.WriteLine("Entrada inválida. Debes ingresar un número.\n");
                    }
                    else
                    {
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                OrdenLogic.AgregarOrden();
                                break;
                            case 2:
                                Console.Clear();
                                OrdenLogic.VerOBuscarOrdenes();
                                break;
                            case 3:
                                Console.Clear();
                                OrdenLogic.EditarOrden();
                                break;
                            case 4:
                                Console.Clear();
                                OrdenLogic.EliminarOrden();
                                break;
                            case 5:
                                Console.Clear();
                                FrmDetalleOrden.GestionarDetalleOrden();
                                break;
                            case 6:
                                back = true;
                                Console.Clear();
                                InicioUI.MostrarMenuOpciones();
                                InicioUI.MostrarMenu();
                                break;
                            default:
                                Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                                intentos++;
                                break;
                        }

                        if (intentos >= 3)
                        {
                            MenuGestionarOrdenes("simple");
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

        public static void MenuGestionarOrdenes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════ GESTIONAR ÓRDENES ═══════╗");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("║ 1- Agregar Orden                ║");
            Console.WriteLine("║ 2- Ver/Buscar Órdenes           ║");
            Console.WriteLine("║ 3- Editar Orden                 ║");
            Console.WriteLine("║ 4- Eliminar Orden               ║");
            Console.WriteLine("║ 5- Gestionar Detalles de Orden  ║");
            Console.WriteLine("║ 6- Volver al Menu Principal     ║");
            Console.WriteLine("║                                 ║");
            Console.WriteLine("╚═════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuGestionarOrdenes(string estilo)
        {
            if (estilo == "simple")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n╔═════════ OPCIONES VALIDAS ═════════╗");
                Console.WriteLine("║                                    ║");
                Console.WriteLine("║ 1- Agregar Orden                   ║");
                Console.WriteLine("║ 2- Ver/Buscar Órdenes              ║");
                Console.WriteLine("║ 3- Editar Orden                    ║");
                Console.WriteLine("║ 4- Eliminar Orden                  ║");
                Console.WriteLine("║ 5- Volver al Menu Principal        ║");
                Console.WriteLine("║                                    ║");
                Console.WriteLine("╚════════════════════════════════════╝\n");
                Console.ResetColor();
            }
        }

        public static void MenuVerOBuscarOrdenes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═════ VER/BUSCAR ÓRDENES ═════╗");
            Console.WriteLine("║                              ║");
            Console.WriteLine("║ 1- Ver Todas las Órdenes     ║");
            Console.WriteLine("║ 2- Buscar Orden              ║");
            Console.WriteLine("║ 3- Volver al Menu Anterior   ║");
            Console.WriteLine("║                              ║");
            Console.WriteLine("╚══════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuDeSalida()
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔══════════════════════════════════╗");
                Console.WriteLine("║ 1- Volver al menu anterior       ║");
                Console.WriteLine("║ 2- Salir                         ║");
                Console.WriteLine("╚══════════════════════════════════╝\n");
                Console.ResetColor();

                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        opcionValida = true;
                        Console.Clear();
                        GestionarOrdenes();
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
