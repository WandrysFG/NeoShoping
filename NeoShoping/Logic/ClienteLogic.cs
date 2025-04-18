﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;
using NeoShoping.Presentation;

namespace NeoShoping.Logic
{
    public class ClienteLogic
    {
        public static void AgregarCliente()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Agregar Cliente ═════════════════════╝\n");
                Console.ResetColor();

                Cliente nuevoCliente = InfoHelpers.ObtenerDatosCliente();

                GuardarClienteEnBaseDeDatos(nuevoCliente);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCliente agregado correctamente.\n");
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

            FrmClientes.MenuDeSalida();
        }

        private static void GuardarClienteEnBaseDeDatos(Cliente nuevoCliente)
        {
            using (var context = new NeoShopingDataContext())
            {
                context.Clientes.Add(nuevoCliente);
                context.SaveChanges();
            }
        }

        public static void VerOBuscarClientes()
        {
            bool back = false;

            while (!back)
            {
                try
                {
                    using (var context = new NeoShopingDataContext())
                    {
                        var clientes = context.Clientes.ToList();

                        Console.Clear();
                        FrmClientes.MenuVerOBuscarClientes();
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
                                MostrarListaClientes(context);
                                FrmClientes.MenuDeSalida();
                                break;

                            case 2:
                                BuscarClientePorId(context);
                                FrmClientes.MenuDeSalida();
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmClientes.MenuGestionarClientes();
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
                    Console.WriteLine($"Error inesperado al obtener clientes: {ex.Message}");
                    InicioUI.Pausa();
                }
            }
        }

        public static void EditarCliente()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Editar Cliente ═════════════════════╝\n");
                Console.ResetColor();

                int id = InputHelper.LeerEntero("Ingrese el ID del cliente que desea editar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var cliente = ObtenerClientePorId(context, id);
                    if (cliente == null) return;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nCliente encontrado:\n");
                    Console.WriteLine(cliente.MostrarInformacion());
                    Console.ResetColor();

                    InputHelper.LeerYActualizarDatosCliente(cliente);
                    GuardarCambios(context);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Datos actuales del cliente:\n");
                    Console.WriteLine(cliente.MostrarInformacion());
                    Console.ResetColor();

                    FrmClientes.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError al actualizar el cliente: {ex.Message}");
                Console.ResetColor();

                InicioUI.Pausa();
            }
        }

        private static Cliente ObtenerClientePorId(NeoShopingDataContext context, int id)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (cliente == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCliente no encontrado. Verifique que el ID sea correcto.\n");
                Console.ResetColor();
                FrmClientes.MenuDeSalida();
            }

            return cliente;
        }

        private static void GuardarCambios(NeoShopingDataContext context)
        {
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCliente actualizado correctamente.\n");
            Console.ResetColor();
        }

        public static void EliminarCliente()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╚═════════════════════ Eliminar Cliente ═════════════════════╝\n");
                Console.ResetColor();

                int idCliente = InputHelper.LeerEntero("Ingrese el ID del cliente a eliminar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var cliente = ObtenerClientePorId(context, idCliente);
                    if (cliente == null) return;

                    MostrarDatosClienteAEliminar(cliente);
                    if (ConfirmarEliminacion())
                    {
                        EliminarClienteDeBaseDeDatos(context, cliente);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOperación cancelada por el usuario.\n");
                        Console.ResetColor();
                    }
                }

                FrmClientes.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar el cliente: {ex.InnerException?.Message ?? ex.Message}");
                InicioUI.Pausa();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                InicioUI.Pausa();
            }
        }

        private static void MostrarDatosClienteAEliminar(Cliente cliente)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nDatos del cliente a eliminar:\n");
            Console.WriteLine(cliente.MostrarInformacion());
            Console.ResetColor();
        }

        private static bool ConfirmarEliminacion()
        {
            while (true)
            {
                Console.Write("\n¿Está seguro que desea eliminar este cliente? (s/n): ");
                string confirmacion = Console.ReadLine()?.Trim().ToLower();

                if (confirmacion == "s")
                    return true;
                else if (confirmacion == "n")
                    return false;
                else
                    Console.WriteLine("Por favor, ingrese una opcion valida: 's' para continuar o 'n' para cancelar.");
            }
        }

        private static void EliminarClienteDeBaseDeDatos(NeoShopingDataContext context, Cliente cliente)
        {
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCliente eliminado correctamente.\n");
            Console.ResetColor();
        }

        private static void MostrarListaClientes(NeoShopingDataContext context)
        {
            Console.Clear();
            var clientes = context.Clientes.ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Lista de Clientes ═════════════════════╝\n");
            Console.ResetColor();

            if (clientes.Any())
            {
                Console.WriteLine($"{"ID",-5}  {"Nombre",-25} {"Telefono",-15}  {"Email",-30}  {"Direccion",-30}");
                Console.WriteLine(new string('─', 105));

                foreach (var c in clientes)
                {
                    Console.WriteLine($"{c.IdCliente,-5}  {c.Nombre,-25} {c.Telefono,-15} {c.Email,-30} {c.Direccion,-30}");
                }

                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.\n");
            }
        }

        private static void BuscarClientePorId(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚═════════════════════ Buscar Cliente ═════════════════════╝\n");
            Console.ResetColor();

            int id = InputHelper.LeerEntero("Ingrese el ID del cliente: ");
            var cliente = context.Clientes.FirstOrDefault(c => c.IdCliente == id);

            if (cliente != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCliente encontrado:\n");
                Console.WriteLine(cliente.MostrarInformacion());
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCliente no encontrado. Verifique que el ID sea correcto.\n");
                Console.ResetColor();
            }
        }
    }
}
