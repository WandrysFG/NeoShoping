﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;
using NeoShoping.Presentation;

namespace NeoShoping.Logic
{
    public class ProveedorLogic
    {
        public static void AgregarProveedor()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Agregar Proveedor ═════════════════════╝\n");
                Console.ResetColor();

                Proveedor nuevoProveedor = InfoHelpers.ObtenerDatosProveedor();

                GuardarProveedorEnBaseDeDatos(nuevoProveedor);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nProducto agregado correctamente.\n");
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
            InicioUI.Pausa();
        }

        private static void GuardarProveedorEnBaseDeDatos(Proveedor nuevoProveedor)
        {
            using (var context = new NeoShopingDataContext())
            {
                context.Proveedores.Add(nuevoProveedor);
                context.SaveChanges();
            }
        }

        public static void VerOBuscarProveedores()
        {
            bool back = false;

            while (!back)
            {
                try
                {
                    using (var context = new NeoShopingDataContext())
                    {
                        var proveedores = context.Proveedores.ToList();

                        Console.Clear();
                        FrmProveedores.MenuVerOBuscarProveedores();
                        Console.Write("Seleccione una opción: ");

                        int option;
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.Write("Entrada inválida. Debes ingresar un número.\n");
                            Console.Write("Seleccione una opción: ");
                        }

                        switch (option)
                        {
                            case 1:
                                MostrarListaProveedores(context);
                                FrmProveedores.MenuDeSalida();
                                break;

                            case 2:
                                BuscarProveedorPorId(context);
                                FrmProveedores.MenuDeSalida();
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmProveedores.MenuGestionarProveedores();
                                break;

                            default:
                                Console.WriteLine("Opción no válida. Intente nuevamente.");
                                InicioUI.Pausa();
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener proveedores: {ex.Message}");
                    InicioUI.Pausa();
                }
            }
        }

        public static void EditarProveedor()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Editar Proveedor ═════════════════════╝\n");
                Console.ResetColor();

                int id = InputHelper.LeerEntero("Ingrese el ID del proveedor que desea editar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var proveedor = ObtenerProveedorPorId(context, id);
                    if (proveedor == null) return;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nProveedor encontrado:\n");
                    Console.WriteLine(proveedor.MostrarInformacion());
                    Console.ResetColor();

                    InputHelper.LeerYActualizarDatosProveedor(proveedor);
                    GuardarCambios(context);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Datos actuales del proveedor:\n");
                    Console.WriteLine(proveedor.MostrarInformacion());
                    Console.ResetColor();

                    FrmProveedores.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError al actualizar el proveedor: {ex.Message}");
                Console.ResetColor();

                InicioUI.Pausa();
            }
        }

        private static Proveedor ObtenerProveedorPorId(NeoShopingDataContext context, int id)
        {
            var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == id);

            if (proveedor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProveedor no encontrado. Verifique que el ID sea correcto.\n");
                Console.ResetColor();
                FrmProveedores.MenuDeSalida();
            }

            return proveedor;
        }

        private static void GuardarCambios(NeoShopingDataContext context)
        {
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProveedor actualizado correctamente.\n");
            Console.ResetColor();
        }

        public static void EliminarProveedor()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Eliminar Proveedor ═════════════════════╝\n");
                Console.ResetColor();

                int idProveedor = InputHelper.LeerEntero("Ingrese el ID del proveedor a eliminar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var proveedor = ObtenerProveedorPorId(context, idProveedor);
                    if (proveedor == null) return;

                    MostrarDatosProveedorAEliminar(proveedor);
                    if (ConfirmarEliminacion())
                    {
                        EliminarProveedorDeBaseDeDatos(context, proveedor);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOperación cancelada por el usuario.\n");
                        Console.ResetColor();
                    }
                }

                FrmProveedores.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar el proveedor: {ex.InnerException?.Message ?? ex.Message}");
                InicioUI.Pausa();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                InicioUI.Pausa();
            }
        }

        private static void MostrarDatosProveedorAEliminar(Proveedor proveedor)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nDatos del proveedor a eliminar:\n");
            Console.WriteLine(proveedor.MostrarInformacion());
            Console.ResetColor();
        }

        private static bool ConfirmarEliminacion()
        {
            while (true)
            {
                Console.Write("\n¿Está seguro que desea eliminar este proveedor? (s/n): ");
                string confirmacion = Console.ReadLine()?.Trim().ToLower();

                if (confirmacion == "s")
                    return true;
                else if (confirmacion == "n")
                    return false;
                else
                    Console.WriteLine("Por favor, ingrese una opcion valida: 's' para continuar o 'n' para cancelar.");
            }
        }

        private static void EliminarProveedorDeBaseDeDatos(NeoShopingDataContext context, Proveedor proveedor)
        {
            context.Proveedores.Remove(proveedor);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nProveedor eliminado correctamente.\n");
            Console.ResetColor();
        }

        private static void MostrarListaProveedores(NeoShopingDataContext context)
        {
            Console.Clear();
            var proveedores = context.Proveedores.ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Lista de Proveedores ═════════════════════╝\n");
            Console.ResetColor();

            if (proveedores.Any())
            {
                Console.WriteLine($"{"ID",-5}  {"Nombre",-25} {"Telefono",-15}  {"Email",-30}  {"Direccion",-30} {"RNC",-10}");
                Console.WriteLine(new string('─', 120));

                foreach (var p in proveedores)
                {
                    Console.WriteLine($"{p.IdProveedor,-5}  {p.Nombre,-25} {p.Telefono,-15} {p.Email,-30} {p.Direccion,-30}  {p.RNC,-10}");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay proveedores registrados.\n");
            }
        }

        private static void BuscarProveedorPorId(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Buscar Proveedor ═════════════════════╝\n");
            Console.ResetColor();

            int id = InputHelper.LeerEntero("Ingrese el ID del proveedor: ");
            var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == id);

            if (proveedor != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nProveedor encontrado:\n");
                Console.WriteLine(proveedor.MostrarInformacion());
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nProveedor no encontrado. Verifique que el ID sea correcto.\n");
                Console.ResetColor();
            }
        }
    }
}


//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using NeoShoping.Data;
//using NeoShoping.Entities;
//using NeoShoping.Helpers.ProveedorHelpers;
//using NeoShoping.Presentation;

//namespace NeoShoping.Logic
//{
//    public class ProveedorLogic
//    {
//        public static void AgregarProveedor()
//        {
//            try
//            {
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("╚═════════════════════ Agregar Proveedor ═════════════════════╝\n");
//                Console.ResetColor();

//                Proveedor nuevoProveedor = ProveedorInfoHelper.ObtenerDatosProveedor();

//                GuardarProveedorEnBaseDeDatos(nuevoProveedor);

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
//            FrmProveedores.Pausa();
//        }

//        private static void GuardarProveedorEnBaseDeDatos(Proveedor nuevoProveedor)
//        {
//            using (var context = new NeoShopingDataContext())
//            {
//                context.Proveedores.Add(nuevoProveedor);
//                context.SaveChanges();
//            }
//        }

//        public static void VerOBuscarProveedores()
//        {
//            bool back = false;

//            while (!back)
//            {
//                try
//                {
//                    using (var context = new NeoShopingDataContext())
//                    {
//                        var proveedores = context.Proveedores.ToList();

//                        Console.Clear();
//                        FrmProveedores.MenuVerOBuscarProveedores();
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
//                                MostrarListaProveedores(context);
//                                FrmProveedores.MenuDeSalida();
//                                break;

//                            case 2:
//                                BuscarProveedorPorId(context);
//                                FrmProveedores.MenuDeSalida();
//                                break;

//                            case 3:
//                                back = true;
//                                Console.Clear();
//                                FrmProveedores.MenuGestionarProveedores();
//                                break;

//                            default:
//                                Console.WriteLine("Opción no válida. Intente nuevamente.");
//                                FrmProveedores.Pausa();
//                                break;
//                        }

//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error inesperado al obtener proveedores: {ex.Message}");
//                    FrmProveedores.Pausa();
//                }
//            }
//        }

//        public static void EditarProveedor()
//        {
//            try
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("╚═════════════════════ Editar Proveedor ═════════════════════╝\n");
//                Console.ResetColor();

//                int id = ProveedorInputHelper.LeerEntero("Ingrese el ID del proveedor que desea editar: ");

//                using (var context = new NeoShopingDataContext())
//                {
//                    var proveedor = ObtenerProveedorPorId(context, id);
//                    if (proveedor == null) return;

//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine("\nProveedor encontrado:\n");
//                    Console.WriteLine(proveedor.MostrarInformacion());
//                    Console.ResetColor();

//                    ProveedorInputHelper.LeerYActualizarDatosProveedor(proveedor);
//                    GuardarCambios(context);

//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    Console.WriteLine("Datos actuales del proveedor:\n");
//                    Console.WriteLine(proveedor.MostrarInformacion());
//                    Console.ResetColor();

//                    FrmProveedores.MenuDeSalida();
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine($"\nError al actualizar el proveedor: {ex.Message}");
//                Console.ResetColor();

//                FrmProveedores.Pausa();
//            }
//        }

//        private static Proveedor ObtenerProveedorPorId(NeoShopingDataContext context, int id)
//        {
//            var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == id);

//            if (proveedor == null)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nProveedor no encontrado. Verifique que el ID sea correcto.\n");
//                Console.ResetColor();
//                FrmProveedores.MenuDeSalida();
//            }

//            return proveedor;
//        }

//        private static void GuardarCambios(NeoShopingDataContext context)
//        {
//            context.SaveChanges();
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nProveedor actualizado correctamente.\n");
//            Console.ResetColor();
//        }

//        public static void EliminarProveedor()
//        {
//            try
//            {
//                Console.Clear();
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("╚═════════════════════ Eliminar Proveedor ═════════════════════╝\n");
//                Console.ResetColor();

//                int idProveedor = ProveedorInputHelper.LeerEntero("Ingrese el ID del proveedor a eliminar: ");

//                using (var context = new NeoShopingDataContext())
//                {
//                    var proveedor = ObtenerProveedorPorId(context, idProveedor);
//                    if (proveedor == null) return;

//                    MostrarDatosProveedorAEliminar(proveedor);
//                    if (ConfirmarEliminacion())
//                    {
//                        EliminarProveedorDeBaseDeDatos(context, proveedor);
//                    }
//                    else
//                    {
//                        Console.ForegroundColor = ConsoleColor.Red;
//                        Console.WriteLine("\nOperación cancelada por el usuario.\n");
//                        Console.ResetColor();
//                    }
//                }

//                FrmProveedores.MenuDeSalida();
//            }
//            catch (DbUpdateException ex)
//            {
//                Console.WriteLine($"Error al eliminar el proveedor: {ex.InnerException?.Message ?? ex.Message}");
//                FrmProveedores.Pausa();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error inesperado: {ex.Message}");
//                FrmProveedores.Pausa();
//            }
//        }

//        private static void MostrarDatosProveedorAEliminar(Proveedor proveedor)
//        {
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("\nDatos del proveedor a eliminar:\n");
//            Console.WriteLine(proveedor.MostrarInformacion());
//            Console.ResetColor();
//        }

//        private static bool ConfirmarEliminacion()
//        {
//            while (true)
//            {
//                Console.Write("\n¿Está seguro que desea eliminar este proveedor? (s/n): ");
//                string confirmacion = Console.ReadLine()?.Trim().ToLower();

//                if (confirmacion == "s")
//                    return true;
//                else if (confirmacion == "n")
//                    return false;
//                else
//                    Console.WriteLine("Por favor, ingrese una opcion valida: 's' para continuar o 'n' para cancelar.");
//            }
//        }

//        private static void EliminarProveedorDeBaseDeDatos(NeoShopingDataContext context, Proveedor proveedor)
//        {
//            context.Proveedores.Remove(proveedor);
//            context.SaveChanges();
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\nProveedor eliminado correctamente.\n");
//            Console.ResetColor();
//        }

//        private static void MostrarListaProveedores(NeoShopingDataContext context)
//        {
//            Console.Clear();
//            var proveedores = context.Proveedores.ToList();

//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("╚═════════════════════ Lista de Proveedores ═════════════════════╝\n");
//            Console.ResetColor();

//            if (proveedores.Any())
//            {
//                Console.WriteLine($"{"ID",-5}  {"Nombre",-25} {"Telefono",-15}  {"Email",-30}  {"Direccion",-30} {"RNC", -10}");
//                Console.WriteLine(new string('─', 120));

//                foreach (var p in proveedores)
//                {
//                    Console.WriteLine($"{p.IdProveedor,-5}  {p.Nombre,-25} {p.Telefono,-15} {p.Email,-30} {p.Direccion,-30}  {p.RNC,-10}");
//                }

//                Console.WriteLine("");
//            }
//            else
//            {
//                Console.WriteLine("No hay proveedores registrados.\n");
//            }
//        }

//        private static void BuscarProveedorPorId(NeoShopingDataContext context)
//        {
//            Console.Clear();
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("╚═════════════════════ Buscar Proveedor ═════════════════════╝\n");
//            Console.ResetColor();

//            int id = ProveedorInputHelper.LeerEntero("Ingrese el ID del proveedor: ");
//            var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == id);

//            if (proveedor != null)
//            {
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.WriteLine("\nProveedor encontrado:\n");
//                Console.WriteLine(proveedor.MostrarInformacion());
//                Console.ResetColor();
//            }
//            else
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nProveedor no encontrado. Verifique que el ID sea correcto.\n");
//                Console.ResetColor();
//            }
//        }
//    }
//}
