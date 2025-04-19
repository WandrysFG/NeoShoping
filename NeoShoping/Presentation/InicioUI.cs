using Microsoft.Data.SqlClient;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;
using System.Threading;

namespace NeoShoping.Presentation
{
    class InicioUI
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║     Bienvenida/o a NeoShoping     ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
            Console.ResetColor();

            try
            {
                MostrarMenuOpciones();

                MostrarMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error global: {ex.Message}\n");
            }
            finally
            {
                Console.WriteLine("Cerrando conexión con la base de datos...");
            }
        }

        public static void MostrarMenu()
        {
            bool running = true;
            int intentosInvalidos = 0;

            while (running)
            {
                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();
                int option;

                if (!int.TryParse(input, out option))
                {
                    intentosInvalidos++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entrada inválida. Debes ingresar un número.\n");
                    Console.ResetColor();
                }
                else
                {
                    try
                    {
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                FrmClientes.GestionarClientes();
                                break;
                            case 2:
                                Console.Clear();
                                FrmOrdenes.GestionarOrdenes();
                                break;
                            case 3:
                                Console.Clear();
                                FrmEntregas.GestionarEntregas();
                                break;
                            case 4:
                                Console.Clear();
                                FrmProductos.GestionarProductos();
                                break;
                            case 5:
                                Console.Clear();
                                FrmProveedores.GestionarProveedores();
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\nGracias por usar NeoShoping. ¡Hasta luego!");
                                Console.ResetColor();
                                Environment.Exit(0);
                                break;
                            default:
                                intentosInvalidos++;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                                Console.ResetColor();
                                break;
                        }

                        if (intentosInvalidos >= 3)
                        {
                            MostrarMenu("simple");
                            intentosInvalidos = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nError: {ex.Message}");
                        Pausa();
                    }
                }
            }
        }

        public static void MostrarMenuOpciones()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════ MENU INICIO ═══════════╗");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("║ 1- Gestionar Clientes             ║");
            Console.WriteLine("║ 2- Gestionar Ordenes              ║");
            Console.WriteLine("║ 3- Gestionar Entregas             ║");
            Console.WriteLine("║ 4- Gestionar Productos            ║");
            Console.WriteLine("║ 5- Gestionar Proveedores          ║");
            Console.WriteLine("║ 6- Salir                          ║");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MostrarMenu(string estilo)
        {
            if (estilo == "simple")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔══════════ OPCIONES VALIDAS ══════════╗");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("║ 1- Gestionar Clientes                ║");
                Console.WriteLine("║ 2- Gestionar Ordenes                 ║");
                Console.WriteLine("║ 3- Gestionar Entregas                ║");
                Console.WriteLine("║ 4- Gestionar Productos               ║");
                Console.WriteLine("║ 4- Gestionar Proveedores             ║");
                Console.WriteLine("║ 5- Salir                             ║");
                Console.WriteLine("║                                      ║");
                Console.WriteLine("╚══════════════════════════════════════╝\n");
                Console.ResetColor();
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