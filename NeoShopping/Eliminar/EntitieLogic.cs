//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using NeoShoping.Data;
//using NeoShoping.Entities;
//using NeoShoping.Helpers;
//using NeoShoping.Presentation;

//namespace NeoShoping.Logic
//{
//    public class EntityLogic<T> where T : class
//    {
//        private static void GuardarEntidadEnBaseDeDatos(T entidad)
//        {
//            using (var context = new NeoShopingDataContext())
//            {
//                context.Set<T>().Add(entidad);
//                context.SaveChanges();
//            }
//        }

//        public static void AgregarEntidad(string entidadNombre)
//        {
//            try
//            {
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine($"╚═════════════════════ Agregar {entidadNombre} ═════════════════════╝\n");
//                Console.ResetColor();

//                T nuevaEntidad = InfoHelper<T>.ObtenerDatosEntidad();

//                GuardarEntidadEnBaseDeDatos(nuevaEntidad);

//                MensajesConsola.MostrarMensajeDeExito();
//            }
//            catch (DbUpdateException ex)
//            {
//                Console.WriteLine($"Error al guardar en la base de datos: {ex}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error inesperado: {ex}");
//            }
//            FrmProductos.Pausa();
//        }

//        public static void VerOBuscarEntidades(string entidadNombre)
//        {
//            bool back = false;

//            while (!back)
//            {
//                try
//                {
//                    using (var context = new NeoShopingDataContext())
//                    {
//                        var entidades = context.Set<T>().ToList();

//                        Console.Clear();
//                        FrmProductos.MenuVerOBuscarEntidades(entidadNombre);
//                        Console.Write("Seleccione una opción: ");

//                        int option;
//                        while (!int.TryParse(Console.ReadLine(), out option))
//                        {
//                            Console.Write("Entrada inválida. Debes ingresar un número.\n");
//                            Console.Write("Seleccione una opción: ");
//                        }

//                        switch (option)
//                        {
//                            case 1:
//                                MostrarListaEntidades(context);
//                                FrmProductos.MenuDeSalida();
//                                break;

//                            case 2:
//                                BuscarEntidadPorId(context);
//                                FrmProductos.MenuDeSalida();
//                                break;

//                            case 3:
//                                back = true;
//                                Console.Clear();
//                                FrmProductos.MenuGestionarEntidades();
//                                break;

//                            default:
//                                Console.WriteLine("Opción no válida. Intente nuevamente.");
//                                FrmProductos.Pausa();
//                                break;
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error inesperado al obtener {entidadNombre}: {ex.Message}");
//                    FrmProductos.Pausa();
//                }
//            }
//        }

//        public static void EditarEntidad(string entidadNombre)
//        {
//            try
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine($"╚═════════════════════ Editar {entidadNombre} ═════════════════════╝\n");
//                Console.ResetColor();

//                int id = EntityInputHelper.LeerEntero($"Ingrese el ID del {entidadNombre} que desea editar: ");

//                using (var context = new NeoShopingDataContext())
//                {
//                    var entidad = ObtenerEntidadPorId(context, id);
//                    if (entidad == null) return;

//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine($"\n{entidadNombre} encontrado:\n");
//                    Console.WriteLine(entidad.ToString());
//                    Console.ResetColor();

//                    EntityInputHelper.LeerYActualizarDatosEntidad(entidad);
//                    GuardarCambios(context);

//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine("Datos actuales de la entidad:\n");
//                    Console.WriteLine(entidad.ToString());
//                    Console.ResetColor();

//                    FrmProductos.MenuDeSalida();
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"\nError al actualizar la entidad: {ex.Message}");
//                Console.ResetColor();

//                FrmProductos.Pausa();
//            }
//        }

//        private static T ObtenerEntidadPorId(NeoShopingDataContext context, int id)
//        {
//            var entidad = context.Set<T>().Find(id);

//            if (entidad == null)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"\nEntidad no encontrada. Verifique que el ID sea correcto.\n");
//                Console.ResetColor();
//                FrmProductos.MenuDeSalida();
//            }

//            return entidad;
//        }

//        private static void GuardarCambios(NeoShopingDataContext context)
//        {
//            context.SaveChanges();
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nEntidad actualizada correctamente.\n");
//            Console.ResetColor();
//        }

//        public static void EliminarEntidad(string entidadNombre)
//        {
//            try
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine($"╚═════════════════════ Eliminar {entidadNombre} ═════════════════════╝\n");
//                Console.ResetColor();

//                int idEntidad = EntityInputHelper.LeerEntero($"Ingrese el ID de la {entidadNombre} a eliminar: ");

//                using (var context = new NeoShopingDataContext())
//                {
//                    var entidad = ObtenerEntidadPorId(context, idEntidad);
//                    if (entidad == null) return;

//                    MostrarDatosEntidadAEliminar(entidad);
//                    if (ConfirmarEliminacion())
//                    {
//                        EliminarEntidadDeBaseDeDatos(context, entidad);
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\nOperación cancelada por el usuario.\n");
//                        Console.ResetColor();
//                    }
//                }

//                FrmProductos.MenuDeSalida();
//            }
//            catch (DbUpdateException ex)
//            {
//                Console.WriteLine($"Error al eliminar la entidad: {ex.InnerException?.Message ?? ex.Message}");
//                FrmProductos.Pausa();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error inesperado: {ex.Message}");
//                FrmProductos.Pausa();
//            }
//        }

//        private static void MostrarDatosEntidadAEliminar(T entidad)
//        {
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("\nDatos de la entidad a eliminar:\n");
//            Console.WriteLine(entidad.ToString());
//            Console.ResetColor();
//        }

//        private static bool ConfirmarEliminacion()
//        {
//            while (true)
//            {
//                Console.Write("\n¿Está seguro que desea eliminar esta entidad? (s/n): ");
//                string confirmacion = Console.ReadLine()?.Trim().ToLower();

//                if (confirmacion == "s")
//                    return true;
//                else if (confirmacion == "n")
//                    return false;
//                else
//                    Console.WriteLine("Por favor, ingrese una opción válida: 's' para continuar o 'n' para cancelar.");
//            }
//        }

//        private static void EliminarEntidadDeBaseDeDatos(NeoShopingDataContext context, T entidad)
//        {
//            context.Set<T>().Remove(entidad);
//            context.SaveChanges();
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nEntidad eliminada correctamente.\n");
//            Console.ResetColor();
//        }

//        private static void MostrarListaEntidades(NeoShopingDataContext context)
//        {
//            Console.Clear();
//            var entidades = context.Set<T>().ToList();

//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine($"╚═════════════════════ Lista de Entidades ═════════════════════╝\n");
//            Console.ResetColor();

//            if (entidades.Any())
//            {
//                Console.WriteLine($"{"ID",-5}  {"Nombre",-25} {"Descripción",-30}  {"Precio",-10}  {"Stock",-10}  {"ID Proveedor",-18}");
//                Console.WriteLine(new string('─', 100));

//                foreach (var e in entidades)
//                {
//                    Console.WriteLine($"{e.ToString()}");
//                }

//                Console.WriteLine("");
//            }
//            else
//            {
//                Console.WriteLine("No hay entidades registradas.\n");
//            }
//        }

//        private static void BuscarEntidadPorId(NeoShopingDataContext context)
//        {
//            Console.Clear();
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine($"╚═════════════════════ Buscar Entidad ═════════════════════╝\n");
//            Console.ResetColor();

//            int id = EntityInputHelper.LeerEntero("Ingrese el ID de la entidad: ");
//            var entidad = context.Set<T>().Find(id);

//            if (entidad != null)
//            {
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("\nEntidad encontrada:\n");
//                Console.WriteLine(entidad.ToString());
//                Console.ResetColor();
//            }
//            else
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nEntidad no encontrada. Verifique que el ID sea correcto.\n");
//                Console.ResetColor();
//            }
//        }
//    }
//}
