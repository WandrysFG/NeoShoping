using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;
using NeoShoping.Presentation;

namespace NeoShoping.Logic
{
    public class EntregaLogic
    {
        public static void AgregarEntrega()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Agregar Entrega ═════════════════════╝\n");
                Console.ResetColor();

                Entrega nuevaEntrega = InfoHelpers.ObtenerDatosEntrega();

                GuardarEntregaEnBaseDeDatos(nuevaEntrega);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEntrega agregada correctamente.");
                Console.ResetColor();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al guardar en la base de datos: {ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex}");
            }

            FrmEntregas.MenuDeSalida();
        }

        private static void GuardarEntregaEnBaseDeDatos(Entrega nuevaEntrega)
        {
            using (var context = new NeoShopingDataContext())
            {
                context.Entregas.Add(nuevaEntrega);
                context.SaveChanges();
            }
        }

        public static void VerOBuscarEntregas()
        {
            bool back = false;

            while (!back)
            {
                try
                {
                    using (var context = new NeoShopingDataContext())
                    {
                        var entregas = context.Entregas.ToList();

                        Console.Clear();
                        FrmEntregas.MenuVerOBuscarEntregas();
                        Console.Write("Seleccione una opción: ");

                        int option;
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Entrada inválida. Debes ingresar un número.\n");
                            Console.ResetColor();
                            
                            Console.Write("Seleccione una opción: ");
                        }

                        switch (option)
                        {
                            case 1:
                                MostrarListaEntregas(context);
                                FrmEntregas.MenuDeSalida();
                                break;

                            case 2:
                                BuscarEntregaPorId(context);
                                FrmEntregas.MenuDeSalida();
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmEntregas.MenuGestionarEntregas();
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                                Console.ResetColor();
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener entregas: {ex.Message}");
                    InicioUI.Pausa();
                }
            }
        }

        public static void EditarEntrega()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Editar Entrega ═════════════════════╝\n");
                Console.ResetColor();

                int id = InputHelper.LeerEntero("Ingrese el ID de la entrega que desea editar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var entrega = ObtenerEntregaPorId(context, id);
                    if (entrega == null) return;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nEntrega encontrada:\n");
                    Console.WriteLine(entrega.MostrarInformacion());
                    Console.ResetColor();

                    InputHelper.LeerYActualizarDatosEntrega(entrega);
                    GuardarCambios(context);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Datos actuales de la entrega:\n");
                    Console.WriteLine(entrega.MostrarInformacion());
                    Console.ResetColor();

                    FrmEntregas.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError al actualizar la entrega: {ex.Message}");
                Console.ResetColor();

                InicioUI.Pausa();
            }
        }

        private static Entrega ObtenerEntregaPorId(NeoShopingDataContext context, int id)
        {
            var entrega = context.Entregas.FirstOrDefault(e => e.IdEntrega == id);

            if (entrega == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntrega no encontrada. Verifique que el ID sea correcto.");
                Console.ResetColor();
                FrmEntregas.MenuDeSalida();
            }

            return entrega;
        }

        private static void GuardarCambios(NeoShopingDataContext context)
        {
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEntrega actualizada correctamente.\n");
            Console.ResetColor();
        }

        public static void EliminarEntrega()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Eliminar Entrega ═════════════════════╝\n");
                Console.ResetColor();

                int idEntrega = InputHelper.LeerEntero("Ingrese el ID de la entrega a eliminar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var entrega = ObtenerEntregaPorId(context, idEntrega);
                    if (entrega == null) return;

                    MostrarDatosEntregaAEliminar(entrega);
                    if (ConfirmarEliminacion())
                    {
                        EliminarEntregaDeBaseDeDatos(context, entrega);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOperación cancelada por el usuario.\n");
                        Console.ResetColor();
                    }
                }

                FrmEntregas.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar la entrega: {ex.InnerException?.Message ?? ex.Message}");
                InicioUI.Pausa();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                InicioUI.Pausa();
            }
        }

        private static void MostrarDatosEntregaAEliminar(Entrega entrega)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nDatos de la entrega a eliminar:\n");
            Console.WriteLine(entrega.MostrarInformacion());
            Console.ResetColor();
        }

        private static bool ConfirmarEliminacion()
        {
            while (true)
            {
                Console.Write("\n¿Está seguro que desea eliminar esta entrega? (s/n): ");
                string confirmacion = Console.ReadLine()?.Trim().ToLower();

                if (confirmacion == "s")
                    return true;
                else if (confirmacion == "n")
                    return false;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor, ingrese una opcion valida: 's' para continuar o 'n' para cancelar.");
                    Console.ResetColor();
            }
        }

        private static void EliminarEntregaDeBaseDeDatos(NeoShopingDataContext context, Entrega entrega)
        {
            context.Entregas.Remove(entrega);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEntrega eliminada correctamente.\n");
            Console.ResetColor();
        }

        private static void MostrarListaEntregas(NeoShopingDataContext context)
        {
            Console.Clear();
            var entregas = context.Entregas.ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Lista de Entregas ═════════════════════╝\n");
            Console.ResetColor();

            if (entregas.Any())
            {
                Console.WriteLine($"{"ID",-5}  {"ID Orden",-10} {"Fecha Entrega",-20}  {"Recibido Por",-25}  {"Observaciones",-30}");
                Console.WriteLine(new string('─', 110));

                foreach (var e in entregas)
                {
                    Console.WriteLine($"{e.IdEntrega,-5}  {e.IdOrden,-10} {e.FechaEntrega.ToString("yyyy-MM-dd"),-20}  {e.RecibidoPor,-25}  {e.Observaciones,-30}");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay entregas registradas.\n");
            }
        }

        private static void BuscarEntregaPorId(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Buscar Entrega ═════════════════════╝\n");
            Console.ResetColor();

            int id = InputHelper.LeerEntero("Ingrese el ID de la entrega: ");
            var entrega = context.Entregas.FirstOrDefault(e => e.IdEntrega == id);

            if (entrega != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEntrega encontrada:\n");
                Console.ResetColor();
                Console.WriteLine(entrega.MostrarInformacion());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEntrega no encontrada. Verifique que el ID sea correcto.\n");
                Console.ResetColor();
            }
        }
    }
}
