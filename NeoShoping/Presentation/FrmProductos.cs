using System;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Logic;

namespace NeoShoping.Presentation
{
    public class FrmProductos
    {
        public static void GestionarProductos()
        {
            var context = new NeoShopingDataContext();
            List<Producto> productos = context.Productos.ToList();

            bool back = false;
            int intentos = 0;

            MenuGestionarProductos();

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
                                ProductoLogic.AgregarProducto();
                                break;
                            case 2:
                                Console.Clear();
                                ProductoLogic.VerOBuscarProductos();
                                break;
                            case 3:
                                Console.Clear();
                                ProductoLogic.EditarProducto();
                                break;
                            case 4:
                                Console.Clear();
                                ProductoLogic.EliminarProducto();
                                break;
                            case 5:
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
                            MenuGestionarProductos("simple");
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

        public static void MenuGestionarProductos()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════ GESTIONAR PRODUCTOS ═══════╗");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("║ 1- Agregar Producto               ║");
            Console.WriteLine("║ 2- Ver/Buscar Productos           ║");
            Console.WriteLine("║ 3- Editar Producto                ║");
            Console.WriteLine("║ 4- Eliminar Producto              ║");
            Console.WriteLine("║ 5- Volver al Menu Principal       ║");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuGestionarProductos(string estilo)
        {
            if (estilo == "simple")
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n╔══════════ OPCIONES VALIDAS ══════════╗");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("║ 1- Agregar Producto                  ║");
                Console.WriteLine("║ 2- Ver/Buscar Productos              ║");
                Console.WriteLine("║ 3- Editar Producto                   ║");
                Console.WriteLine("║ 4- Eliminar Producto                 ║");
                Console.WriteLine("║ 5- Volver al Menu Principal          ║");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("╚══════════════════════════════════════╝\n");
                Console.ResetColor();
            }
        }

        public static void MenuVerOBuscarProductos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════ VER/BUSCAR PRODUCTOS ═══════╗");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║ 1- Ver Todos los Productos         ║");
            Console.WriteLine("║ 2- Buscar Producto                 ║");
            Console.WriteLine("║ 3- Volver al Menu Anterior         ║");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("╚════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuDeSalida()
        {
            bool opcionValida = false;

            while (!opcionValida)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║ 1- Volver al menu anterior        ║");
                Console.WriteLine("║ 2- Salir                          ║");
                Console.WriteLine("╚═══════════════════════════════════╝\n");
                Console.ResetColor();

                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        opcionValida = true;
                        Console.Clear();
                        GestionarProductos();
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

        public static void Pausa()
        {
            Console.Write("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}