using Microsoft.Data.SqlClient;
using NeoShoping.Data;
using NeoShoping.Entities;

namespace NeoShoping.Presentation
{
    class InicioUI
    {
        static void Main(string[] args)
        {
            bool running = true;
            int intentosInvalidos = 0;
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════╗");
            Console.WriteLine("║     Bienvenida/o a NeoShoping     ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
            Console.ResetColor();

            try
            {
                MostrarMenu();

                while (running)
                {
                    Console.Write("Seleccione una opción: ");
                    string input = Console.ReadLine();
                    int option;

                    if (!int.TryParse(input, out option))
                    {
                        intentosInvalidos++;
                        Console.WriteLine("Entrada inválida. Debes ingresar un número.\n");
                    }
                    else
                    {
                        try
                        {
                            switch (option)
                            {
                                case 1:
                                    Console.Clear();
                                    FrmProductos.GestionarProductos();
                                    break;
                                case 2:
                                    Console.Clear();
                                    FrmProveedores.GestionarProveedores();
                                    break;
                                case 3:
                                    Console.Clear();
                                    //ordenes de compras
                                    break;
                                case 4:
                                    Console.Clear();
                                    //gestionar entregas
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\nGracias por usar NeoShoping. ¡Hasta luego!");
                                    Console.ResetColor();
                                    running = false;
                                    break;
                                default:
                                    intentosInvalidos++;
                                    Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                                    break;
                            }

                            if (intentosInvalidos >= 3)
                            {
                                MostrarMenu("simple");
                                intentosInvalidos = 0;
                            }
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine($"Error: Se encontró una referencia nula.\nDetalles: {ex.Message}\n");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Operación inválida: {ex.Message}\n");
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine($"Error de base de datos: {ex.Message}\n");
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Formato incorrecto: {ex.Message}\n");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex}\n");
                        }
                    }
                }
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════ MENU INICIO ═══════════╗");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("║ 1- Gestionar Productos            ║");
            Console.WriteLine("║ 2- Gestionar Proveedores          ║");
            Console.WriteLine("║ 3- Gestionar Ordenes de Compras   ║");
            Console.WriteLine("║ 4- Gestionar Entregas             ║");
            Console.WriteLine("║ 5- Salir                          ║");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
            Console.ResetColor();

        }

        public static void MostrarMenu(string estilo)
        {
            if (estilo == "simple")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("║");
                Console.WriteLine("║ OPCIONES VALIDAS:");
                Console.WriteLine("║");
                Console.WriteLine("║ 1- Gestionar Productos");
                Console.WriteLine("║ 2- Gestionar Proveedores");
                Console.WriteLine("║ 3- Gestionar Ordenes de Compras");
                Console.WriteLine("║ 4- Gestionar Entregas");
                Console.WriteLine("║ 5- Salir");
                Console.WriteLine("║\n");
                Console.ResetColor();
            }
        }
    }
}