using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NeoShopping.Data;
using NeoShopping.Entities;
using NeoShopping.Helpers;
using NeoShopping.Presentation;

namespace NeoShopping.Logic
{
    public class OrdenLogic
    {
        public static void AgregarOrden()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Agregar Orden ═════════════════════╝\n");
                Console.ResetColor();

                Orden nuevaOrden = InfoHelpers.ObtenerDatosOrden();

                GuardarOrdenEnBaseDeDatos(nuevaOrden);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOrden agregada correctamente.");
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

            FrmOrdenes.MenuDeSalida();
        }

        private static void GuardarOrdenEnBaseDeDatos(Orden nuevaOrden)
        {
            using (var context = new NeoShoppingDataContext())
            {
                context.Ordenes.Add(nuevaOrden);
                context.SaveChanges();
            }
        }

        public static void VerOBuscarOrdenes()
        {
            bool back = false;

            while (!back)
            {
                try
                {
                    using (var context = new NeoShoppingDataContext())
                    {
                        var ordenes = context.Ordenes.ToList();

                        Console.Clear();
                        FrmOrdenes.MenuVerOBuscarOrdenes();
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
                                MostrarListaOrdenes(context);
                                FrmOrdenes.MenuDeSalida();
                                break;

                            case 2:
                                BuscarOrdenPorId(context);
                                FrmOrdenes.MenuDeSalida();
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmOrdenes.MenuGestionarOrdenes();
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
                    Console.WriteLine($"Error inesperado al obtener órdenes: {ex.Message}");
                    InicioUI.Pausa();
                }
            }
        }

        public static void EditarOrden()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Editar Orden ═════════════════════╝\n");
                Console.ResetColor();

                int id = InputHelper.LeerEntero("Ingrese el ID de la orden que desea editar: ");

                using (var context = new NeoShoppingDataContext())
                {
                    var orden = ObtenerOrdenPorId(context, id);
                    if (orden == null) return;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nOrden encontrada:\n");
                    Console.WriteLine(orden.MostrarInformacion());
                    Console.ResetColor();

                    InputHelper.LeerYActualizarDatosOrden(orden);
                    GuardarCambios(context);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Datos actuales de la orden:\n");
                    Console.WriteLine(orden.MostrarInformacion());
                    Console.ResetColor();

                    FrmOrdenes.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError al actualizar la orden: {ex.Message}");
                Console.ResetColor();

                InicioUI.Pausa();
            }
        }

        private static Orden ObtenerOrdenPorId(NeoShoppingDataContext context, int id)
        {
            var orden = context.Ordenes.FirstOrDefault(o => o.IdOrden == id);

            if (orden == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOrden no encontrada. Verifique que el ID sea correcto.");
                Console.ResetColor();
                FrmOrdenes.MenuDeSalida();
            }

            return orden;
        }

        private static void GuardarCambios(NeoShoppingDataContext context)
        {
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOrden actualizada correctamente.\n");
            Console.ResetColor();
        }

        public static void EliminarOrden()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Eliminar Orden ═════════════════════╝\n");
                Console.ResetColor();

                int idOrden = InputHelper.LeerEntero("Ingrese el ID de la orden a eliminar: ");

                using (var context = new NeoShoppingDataContext())
                {
                    var orden = ObtenerOrdenPorId(context, idOrden);
                    if (orden == null) return;

                    MostrarDatosOrdenAEliminar(orden);
                    if (ConfirmarEliminacion())
                    {
                        EliminarOrdenDeBaseDeDatos(context, orden);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOperación cancelada por el usuario.");
                        Console.ResetColor();
                    }
                }

                FrmOrdenes.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar la orden: {ex.InnerException?.Message ?? ex.Message}");
                InicioUI.Pausa();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                InicioUI.Pausa();
            }
        }

        private static void MostrarDatosOrdenAEliminar(Orden orden)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nDatos de la orden a eliminar:\n");
            Console.WriteLine(orden.MostrarInformacion());
            Console.ResetColor();
        }

        private static bool ConfirmarEliminacion()
        {
            while (true)
            {
                Console.Write("\n¿Está seguro que desea eliminar esta orden? (s/n): ");
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

        private static void EliminarOrdenDeBaseDeDatos(NeoShoppingDataContext context, Orden orden)
        {
            context.Ordenes.Remove(orden);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOrden eliminada correctamente.\n");
            Console.ResetColor();
        }

        private static void MostrarListaOrdenes(NeoShoppingDataContext context)
        {
            Console.Clear();
            var ordenes = context.Ordenes.ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Lista de Órdenes ═════════════════════╝\n");
            Console.ResetColor();

            if (ordenes.Any())
            {
                Console.WriteLine($"{"ID",-5}  {"Fecha",-30} {"Estado",-15} {"ID Cliente",-15} {"Total",-10}");
                Console.WriteLine(new string('─', 100));

                foreach (var o in ordenes)
                {
                    Console.WriteLine($"{o.IdOrden,-5}  {o.FechaOrden,-30} {o.Estado,-15} {o.IdCliente,-15} {o.Total,-10}");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay órdenes registradas.\n");
            }
        }

        private static void BuscarOrdenPorId(NeoShoppingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Buscar Orden ═════════════════════╝\n");
            Console.ResetColor();

            int id = InputHelper.LeerEntero("Ingrese el ID de la orden: ");
            var orden = context.Ordenes.FirstOrDefault(o => o.IdOrden == id);

            if (orden != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nOrden encontrada:\n");
                Console.ResetColor();
                Console.WriteLine(orden.MostrarInformacion());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOrden no encontrada. Verifique que el ID sea correcto.");
                Console.ResetColor();
            }
        }
    }
}
