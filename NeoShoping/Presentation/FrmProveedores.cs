using System;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Logic;

namespace NeoShoping.Presentation
{
    public class FrmProveedores
    {
        public static void GestionarProveedores()
        {
            var context = new NeoShopingDataContext();
            List<Proveedor> proveedores = context.Proveedores.ToList();

            bool back = false;
            int intentos = 0;

            MenuGestionarProveedores();

            while (!back)
            {
                Console.Write("Seleccione una opción: ");

                try
                {
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
                                ProveedorLogic.AgregarProveedor();
                                break;
                            case 2:
                                Console.Clear();
                                ProveedorLogic.VerOBuscarProveedor();
                                break;
                            case 3:
                                Console.Clear();
                                ProveedorLogic.EditarProveedor();
                                break;
                            case 4:
                                Console.Clear();
                                ProveedorLogic.EliminarProveedor();
                                break;
                            case 5:
                                back = true;
                                Console.Clear();
                                InicioUI.MostrarMenu();
                                break;
                            default:
                                Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                                intentos++;
                                break;
                        }

                        if (intentos >= 3)
                        {
                            MenuGestionarProveedor("simple");
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

        public static void MenuGestionarProveedores()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════ GESTIONAR PROVEEDORES ═══════╗");
            Console.WriteLine("║                                     ║");
            Console.WriteLine("║ 1- Agregar Proveedor                ║");
            Console.WriteLine("║ 2- Ver/Buscar Proveedores           ║");
            Console.WriteLine("║ 3- Editar Proveedor                 ║");
            Console.WriteLine("║ 4- Eliminar Proveedor               ║");
            Console.WriteLine("║ 5- Volver al Menu Principal         ║");
            Console.WriteLine("║                                     ║");
            Console.WriteLine("╚═════════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuGestionarProveedor(string estilo)
        {
            if (estilo == "simple")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("║");
                Console.WriteLine("║ OPCIONES VALIDAS:");
                Console.WriteLine("║");
                Console.WriteLine("║ 1- Agregar Proveedor");
                Console.WriteLine("║ 2- Ver/Buscar Proveedores");
                Console.WriteLine("║ 3- Editar Proveedor");
                Console.WriteLine("║ 4- Eliminar Proveedor");
                Console.WriteLine("║ 5- Volver al Menu Principal");
                Console.WriteLine("║\n");
                Console.ResetColor();
            }
        }

        public static void MenuVerOBuscarProveedor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════ VER/BUSCAR PROVEEDORES ══════╗");
            Console.WriteLine("║                                    ║");
            Console.WriteLine("║ 1- Ver Todos los Proveedores       ║");
            Console.WriteLine("║ 2- Buscar Proveedor                ║");
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
                Console.ForegroundColor = ConsoleColor.Red;
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
                        GestionarProveedores();
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
