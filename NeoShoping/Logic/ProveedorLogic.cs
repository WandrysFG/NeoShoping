using System;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╚═════════════════════ Agregar Proveedor ═════════════════════╝\n");
                Console.ResetColor();

                string nombre = ProveedorHelper.LeerNombreProveedor();
                string telefono = ProveedorHelper.LeerTelefonoProveedor();
                string email = ProveedorHelper.LeerEmailProveedor();
                string direccion = ProveedorHelper.LeerDireccionProveedor();
                string rnc = ProveedorHelper.LeerRNCProveedor();

                Proveedor nuevoProveedor = new Proveedor(nombre, telefono, email, direccion, rnc);

                using (var context = new NeoShopingDataContext())
                {
                    context.Proveedores.Add(nuevoProveedor);
                    context.SaveChanges();
                }

                Console.WriteLine("\nProveedor agregado correctamente.\n");
                FrmProveedores.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"\nError al guardar en la base de datos: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado: {ex.Message}");
            }
            ProveedorHelper.Pausa();
        }

        public static void VerOBuscarProveedor()
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
                        FrmProveedores.MenuVerOBuscarProveedor();
                        Console.Write("Seleccione una opción: ");

                        int option;
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.Write("Opción no válida, intente nuevamente: ");
                        }

                        switch (option)
                        {
                            case 1:
                                MostrarListaProveedores(context);
                                break;

                            case 2:
                                BuscarProveedorPorId(context);
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmProveedores.MenuGestionarProveedores();
                                break;

                            default:
                                Console.WriteLine("Opción no válida. Intente nuevamente.");
                                ProveedorHelper.Pausa();
                                break;
                        }

                        FrmProveedores.MenuDeSalida();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener proveedores: {ex.Message}");
                    ProveedorHelper.Pausa();
                }
            }
        }

        public static void EditarProveedor()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╚═════════════════════ Editar Proveedor ═════════════════════╝\n");
                Console.ResetColor();

                int id = ProveedorHelper.LeerEntero("Ingrese el ID del proveedor que desea editar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == id);

                    if (proveedor == null)
                    {
                        Console.WriteLine("Proveedor no encontrado. Verifique que el ID sea correcto.");
                        ProveedorHelper.Pausa();
                        FrmProveedores.MenuDeSalida();
                    }

                    Console.WriteLine("\nDatos actuales del proveedor:\n");
                    Console.WriteLine($"Nombre: {proveedor.Nombre} ║ Teléfono: {proveedor.Telefono} ║ Email: {proveedor.Email}");
                    Console.WriteLine($"Dirección: {proveedor.Direccion} ║ RNC: {proveedor.RNC}\n");

                    Console.WriteLine("Ingrese los nuevos datos (deje vacío para mantener el valor actual):\n");

                    string nuevoNombre = ProveedorHelper.LeerNombreProveedorOpcional(proveedor.Nombre);
                    string nuevoTelefono = ProveedorHelper.LeerTelefonoProveedorOpcional(proveedor.Telefono);
                    string nuevoEmail = ProveedorHelper.LeerEmailProveedorOpcional(proveedor.Email);
                    string nuevaDireccion = ProveedorHelper.LeerDireccionProveedorOpcional(proveedor.Direccion);
                    string nuevoRNC = ProveedorHelper.LeerRNCProveedorOpcional(proveedor.RNC);

                    proveedor.Nombre = nuevoNombre;
                    proveedor.Telefono = nuevoTelefono;
                    proveedor.Email = nuevoEmail;
                    proveedor.Direccion = nuevaDireccion;
                    proveedor.RNC = nuevoRNC;

                    context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProveedor actualizado correctamente.");
                    Console.ResetColor();

                    Console.WriteLine("\nDatos actualizados del proveedor:\n");
                    Console.WriteLine($"Nombre: {proveedor.Nombre} ║ Teléfono: {proveedor.Telefono} ║ Email: {proveedor.Email}");
                    Console.WriteLine($"Dirección: {proveedor.Direccion} ║ RNC: {proveedor.RNC}\n");

                    FrmProveedores.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al actualizar el proveedor: {ex.Message}");
                ProveedorHelper.Pausa();
            }
        }

        public static void EliminarProveedor()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╚═════════════════════ Eliminar Proveedor ═════════════════════╝\n");
                Console.ResetColor();

                int idProveedor = ProveedorHelper.LeerEntero("Ingrese el ID del proveedor a eliminar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == idProveedor);

                    if (proveedor != null)
                    {
                        Console.WriteLine("\nDatos del proveedor a eliminar:\n");
                        Console.WriteLine($"ID: {proveedor.IdProveedor} ║ Nombre: {proveedor.Nombre} ║ Teléfono: {proveedor.Telefono}");
                        Console.WriteLine($"Email: {proveedor.Email} ║ Dirección: {proveedor.Direccion} ║ RNC: {proveedor.RNC}\n");

                        Console.Write("\n¿Está seguro que desea eliminar este proveedor? (s/n): ");
                        string confirmacion = Console.ReadLine()?.Trim().ToLower();

                        if (confirmacion == "s" || confirmacion == "S")
                        {
                            context.Proveedores.Remove(proveedor);
                            context.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nProveedor eliminado correctamente.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine("\nOperación cancelada por el usuario.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Proveedor no encontrado.");
                        Console.ResetColor();
                    }
                }

                FrmProveedores.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar el proveedor: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            ProveedorHelper.Pausa();
        }

        private static void MostrarListaProveedores(NeoShopingDataContext context)
        {
            Console.Clear();
            var proveedores = context.Proveedores.ToList();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╚═════════════════════ Lista de Proveedores ═════════════════════╝\n");
            Console.ResetColor();

            if (proveedores.Any())
            {
                foreach (var p in proveedores)
                {
                    Console.WriteLine($"ID: {p.IdProveedor} ║ Nombre: {p.Nombre} ║ Teléfono: {p.Telefono} ║ Email: {p.Email} ║ Dirección: {p.Direccion} ║ RNC: {p.RNC}");
                }
            }
            else
            {
                Console.WriteLine("No hay proveedores registrados.");
            }

            ProveedorHelper.Pausa();
        }

        private static void BuscarProveedorPorId(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╚═════════════════════ Buscar Proveedor ═════════════════════╝\n");
            Console.ResetColor();

            int id = ProveedorHelper.LeerEntero("Ingrese el ID del proveedor: ");
            var proveedor = context.Proveedores.FirstOrDefault(p => p.IdProveedor == id);

            if (proveedor != null)
            {
                Console.WriteLine($"\n║ ID: {proveedor.IdProveedor}");
                Console.WriteLine($"║ Nombre: {proveedor.Nombre}");
                Console.WriteLine($"║ Teléfono: {proveedor.Telefono}");
                Console.WriteLine($"║ Email: {proveedor.Email}");
                Console.WriteLine($"║ Dirección: {proveedor.Direccion}");
                Console.WriteLine($"║ RNC: {proveedor.RNC}");
            }
            else
            {
                Console.WriteLine("\nProveedor no encontrado. Verifique que el ID sea correcto.");
            }

            ProveedorHelper.Pausa();
        }
    }
}
