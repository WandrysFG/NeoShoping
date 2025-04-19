using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;
using NeoShoping.Presentation;

namespace NeoShoping.Logic
{
    public class DetallesOrdenLogic
    {
        public static void AgregarDetalleOrden()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Agregar Detalle de Orden ═════════════════════╝\n");
                Console.ResetColor();

                DetalleOrden nuevoDetalle = InfoHelpers.ObtenerDatosDetalleOrden();

                GuardarDetalleEnBaseDeDatos(nuevoDetalle);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDetalle de orden agregado correctamente.");
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

            FrmDetalleOrden.MenuDeSalida();
        }

        private static void GuardarDetalleEnBaseDeDatos(DetalleOrden nuevoDetalle)
        {
            using (var context = new NeoShopingDataContext())
            {
                context.DetallesOrden.Add(nuevoDetalle);
                context.SaveChanges();
            }
        }

        public static void VerOBuscarDetallesOrden()
        {
            bool back = false;

            while (!back)
            {
                try
                {
                    using (var context = new NeoShopingDataContext())
                    {
                        var detalles = context.DetallesOrden.ToList();

                        Console.Clear();
                        FrmDetalleOrden.MenuVerOBuscarDetalleOrden();
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
                                MostrarListaDetallesOrden(context);
                                FrmDetalleOrden.MenuDeSalida();
                                break;

                            case 2:
                                BuscarDetalleOrdenPorId(context);
                                FrmDetalleOrden.MenuDeSalida();
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmDetalleOrden.MenuGestionarDetalleOrden();
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
                    Console.WriteLine($"Error inesperado al obtener detalles de orden: {ex.Message}");
                    InicioUI.Pausa();
                }
            }
        }

        public static void EditarDetalleOrden()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Editar Detalle de Orden ═════════════════════╝\n");
                Console.ResetColor();

                int id = InputHelper.LeerEntero("Ingrese el ID del detalle de orden que desea editar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var detalle = ObtenerDetalleOrdenPorId(context, id);
                    if (detalle == null) return;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nDetalle de orden encontrado:\n");
                    Console.WriteLine(detalle.MostrarInformacion());
                    Console.ResetColor();

                    InputHelper.LeerYActualizarDatosDetalleOrden(detalle);
                    GuardarCambios(context);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Datos actuales del detalle de orden:\n");
                    Console.WriteLine(detalle.MostrarInformacion());
                    Console.ResetColor();

                    FrmDetalleOrden.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError al actualizar el detalle de orden: {ex.Message}");
                Console.ResetColor();

                InicioUI.Pausa();
            }
        }

        private static DetalleOrden ObtenerDetalleOrdenPorId(NeoShopingDataContext context, int id)
        {
            var detalle = context.DetallesOrden.FirstOrDefault(d => d.IdDetalle == id);

            if (detalle == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDetalle de orden no encontrado. Verifique que el ID sea correcto.");
                Console.ResetColor();
                FrmDetalleOrden.MenuDeSalida();
            }

            return detalle;
        }

        private static void GuardarCambios(NeoShopingDataContext context)
        {
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDetalle de orden actualizado correctamente.\n");
            Console.ResetColor();
        }

        public static void EliminarDetalleOrden()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Eliminar Detalle de Orden ═════════════════════╝\n");
                Console.ResetColor();

                int id = InputHelper.LeerEntero("Ingrese el ID del detalle de orden a eliminar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var detalle = ObtenerDetalleOrdenPorId(context, id);
                    if (detalle == null) return;

                    MostrarDatosDetalleAEliminar(detalle);
                    if (ConfirmarEliminacion())
                    {
                        EliminarDetalleDeBaseDeDatos(context, detalle);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOperación cancelada por el usuario.\n");
                        Console.ResetColor();
                    }
                }

                FrmDetalleOrden.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar el detalle de orden: {ex.InnerException?.Message ?? ex.Message}");
                InicioUI.Pausa();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                InicioUI.Pausa();
            }
        }

        private static void MostrarDatosDetalleAEliminar(DetalleOrden detalle)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nDatos del detalle de orden a eliminar:\n");
            Console.WriteLine(detalle.MostrarInformacion());
            Console.ResetColor();
        }

        private static bool ConfirmarEliminacion()
        {
            while (true)
            {
                Console.Write("\n¿Está seguro que desea eliminar este detalle de orden? (s/n): ");
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

        private static void EliminarDetalleDeBaseDeDatos(NeoShopingDataContext context, DetalleOrden detalle)
        {
            context.DetallesOrden.Remove(detalle);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDetalle de orden eliminado correctamente.\n");
            Console.ResetColor();
        }

        private static void MostrarListaDetallesOrden(NeoShopingDataContext context)
        {
            Console.Clear();
            var detalles = context.DetallesOrden.ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Lista de Detalles de Orden ═════════════════════╝\n");
            Console.ResetColor();

            if (detalles.Any())
            {
                Console.WriteLine($"{"ID",-5}  {"ID Orden",-10}  {"ID Producto",-12}  {"Cantidad",-10}  {"Precio Unitario",-16}");
                Console.WriteLine(new string('─', 60));

                foreach (var d in detalles)
                {
                    Console.WriteLine($"{d.IdDetalle,-5}  {d.IdOrden,-10}  {d.IdProducto,-12}  {d.Cantidad,-10}  {d.PrecioUnitario,-16:c}");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay detalles de orden registrados.");
            }
        }

        private static void BuscarDetalleOrdenPorId(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Buscar Detalle de Orden ═════════════════════╝\n");
            Console.ResetColor();

            int id = InputHelper.LeerEntero("Ingrese el ID del detalle de orden: ");
            var detalle = context.DetallesOrden.FirstOrDefault(d => d.IdDetalle == id);

            if (detalle != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDetalle de orden encontrado:\n");
                Console.ResetColor();
                Console.WriteLine(detalle.MostrarInformacion());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDetalle de orden no encontrado. Verifique que el ID sea correcto.\n");
                Console.ResetColor();
            }
        }
    }
}
