using System;
using Microsoft.EntityFrameworkCore;
using NeoShopping.Data;
using NeoShopping.Entities;
using NeoShopping.Logic;

namespace NeoShopping.Presentation
{
    public class FrmEntregas
    {
        public static void GestionarEntregas()
        {
            var context = new NeoShoppingDataContext();
            List<Entrega> entregas = context.Entregas.ToList();

            bool back = false;
            int intentos = 0;

            MenuGestionarEntregas();

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
                                EntregaLogic.AgregarEntrega();
                                break;
                            case 2:
                                Console.Clear();
                                EntregaLogic.VerOBuscarEntregas();
                                break;
                            case 3:
                                Console.Clear();
                                EntregaLogic.EditarEntrega();
                                break;
                            case 4:
                                Console.Clear();
                                EntregaLogic.EliminarEntrega();
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
                            MenuGestionarEntregas("simple");
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

        public static void MenuGestionarEntregas()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════ GESTIONAR ENTREGAS ═══════╗");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("║ 1- Agregar Entrega               ║");
            Console.WriteLine("║ 2- Ver/Buscar Entregas           ║");
            Console.WriteLine("║ 3- Editar Entrega                ║");
            Console.WriteLine("║ 4- Eliminar Entrega              ║");
            Console.WriteLine("║ 5- Volver atrás                  ║");
            Console.WriteLine("║                                  ║");
            Console.WriteLine("╚══════════════════════════════════╝\n");
            Console.ResetColor();
        }

        public static void MenuGestionarEntregas(string estilo)
        {
            if (estilo == "simple")
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔═══════ OPCIONES VALIDAS ═══════╗");
                Console.WriteLine("║                                ║");
                Console.WriteLine("║ 1- Agregar Entrega             ║");
                Console.WriteLine("║ 2- Ver/Buscar Entregas         ║");
                Console.WriteLine("║ 3- Editar Entrega              ║");
                Console.WriteLine("║ 4- Eliminar Entrega            ║");
                Console.WriteLine("║ 5- Volver atrás                ║");
                Console.WriteLine("║                                ║");
                Console.WriteLine("╚════════════════════════════════╝\n");
                Console.ResetColor();
            }
        }

        public static void MenuVerOBuscarEntregas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════ VER/BUSCAR ENTREGAS ═══════╗");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("║ 1- Ver Todos los Entregas         ║");
            Console.WriteLine("║ 2- Buscar Entregas                ║");
            Console.WriteLine("║ 3- Volver atrás                   ║");
            Console.WriteLine("║                                   ║");
            Console.WriteLine("╚═══════════════════════════════════╝\n");
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
                        GestionarEntregas();
                        break;
                    case "2":
                        opcionValida = true;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nGracias por usar NeoShopping. ¡Hasta pronto!");
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