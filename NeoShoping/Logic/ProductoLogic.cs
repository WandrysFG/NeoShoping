using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NeoShoping.Data;
using NeoShoping.Entities;
using NeoShoping.Helpers;
using NeoShoping.Presentation;

namespace NeoShoping.Logic
{
    public class ProductoLogic
    {
        public static void AgregarProducto()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╚═════════════════════ Agregar Producto ═════════════════════╝\n");
                Console.ResetColor();

                string nombre = ProductoHelper.LeerNombreProducto();
                string descripcion = ProductoHelper.LeerDescripcionProducto();
                decimal precio = ProductoHelper.LeerPrecioProducto();
                int stock = ProductoHelper.LeerStockProducto();
                int idProveedor = ProductoHelper.LeerIdProveedor();


                Producto nuevoProducto = new Producto(nombre, precio, stock, descripcion)
                {
                    IdProveedor = idProveedor
                };

                using (var context = new NeoShopingDataContext())
                {
                    context.Productos.Add(nuevoProducto);
                    context.SaveChanges();
                }

                Console.WriteLine("\nProducto agregado correctamente.\n");
                FrmProductos.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"\nError al guardar en la base de datos: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado: {ex.Message}");
            }
            ProductoHelper.Pausa();
        }

        public static void VerOBuscarProductos()
        {
            bool back = false;

            while (!back)
            {
                try
                {
                    using (var context = new NeoShopingDataContext())
                    {
                        var productos = context.Productos.ToList();

                        Console.Clear();
                        FrmProductos.MenuVerOBuscarProductos();
                        Console.Write("Seleccione una opción: ");

                        int option;
                        while (!int.TryParse(Console.ReadLine(), out option))
                        {
                            Console.Write("Opción no válida, intente nuevamente: ");
                        }

                        switch (option)
                        {
                            case 1:
                                MostrarListaProductos(context);
                                FrmProductos.MenuDeSalida();
                                break;

                            case 2:
                                BuscarProductoPorId(context);
                                FrmProductos.MenuDeSalida();
                                break;

                            case 3:
                                back = true;
                                Console.Clear();
                                FrmProductos.MenuGestionarProductos();
                                break;

                            default:
                                Console.WriteLine("Opción no válida. Intente nuevamente.");
                                ProductoHelper.Pausa();
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener productos: {ex.Message}");
                    ProductoHelper.Pausa();
                }
            }
        }

        public static void EditarProducto()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╚═════════════════════ Editar Producto ═════════════════════╝\n");
                Console.ResetColor();

                int id = ProductoHelper.LeerEntero("Ingrese el ID del producto que desea editar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var producto = context.Productos.FirstOrDefault(p => p.IdProducto == id);

                    if (producto == null)
                    {
                        Console.WriteLine("Producto no encontrado. Verifique que el ID sea correcto.");
                        ProductoHelper.Pausa();
                        FrmProductos.MenuDeSalida();
                    }

                    Console.WriteLine("\nDatos actuales del producto:\n");
                    Console.WriteLine($"Nombre: {producto.Nombre} ║ Descripción: {producto.Descripcion} ║ Precio: {producto.Precio} ║ Stock: {producto.Stock} ║ ID Proveedor: {producto.IdProveedor}\n");

                    Console.WriteLine("Ingrese los nuevos datos (deje vacío para mantener el valor actual):\n");

                    string nuevoNombre = ProductoHelper.LeerTextoOpcional("Nuevo nombre: ", producto.Nombre);
                    string nuevaDescripcion = ProductoHelper.LeerTextoOpcional("Nueva descripción: ", producto.Descripcion);
                    decimal nuevoPrecio = ProductoHelper.LeerDecimalOpcional("Nuevo precio: ", producto.Precio);
                    int nuevoStock = ProductoHelper.LeerEnteroOpcional("Nuevo stock: ", producto.Stock);
                    int nuevoIdProveedor = ProductoHelper.LeerEnteroOpcional("Nuevo ID Proveedor: ", producto.IdProveedor);

                    producto.Nombre = nuevoNombre;
                    producto.Descripcion = nuevaDescripcion;
                    producto.Precio = nuevoPrecio;
                    producto.Stock = nuevoStock;
                    producto.IdProveedor = nuevoIdProveedor;

                    context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProducto actualizado correctamente.");
                    Console.ResetColor();

                    Console.WriteLine("\nDatos actualizados del producto:\n");
                    Console.WriteLine($"Nombre: {producto.Nombre} ║ Descripción: {producto.Descripcion} ║ Precio: {producto.Precio} ║ Stock: {producto.Stock} ║ ID Proveedor: {producto.IdProveedor}\n");

                    FrmProductos.MenuDeSalida();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al actualizar el producto: {ex.Message}");
                ProductoHelper.Pausa();
            }
        }

        public static void EliminarProducto()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╚═════════════════════ Eliminar Producto ═════════════════════╝\n");
                Console.ResetColor();

                int idProducto = ProductoHelper.LeerEntero("Ingrese el ID del producto a eliminar: ");

                using (var context = new NeoShopingDataContext())
                {
                    var producto = context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

                    if (producto != null)
                    {
                        Console.WriteLine("\nDatos del producto a eliminar:\n");
                        Console.WriteLine($"ID: {producto.IdProducto} ║ Nombre: {producto.Nombre} ║ Descripción: {producto.Descripcion} ║ Precio: {producto.Precio} ║ Stock: {producto.Stock} ║ ID Proveedor: {producto.IdProveedor}\n");

                        Console.Write("\n¿Está seguro que desea eliminar este producto? (s/n): ");
                        string confirmacion = Console.ReadLine()?.Trim().ToLower();

                        if (confirmacion == "s" || confirmacion == "S")
                        {
                            context.Productos.Remove(producto);
                            context.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nProducto eliminado correctamente.");
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
                        Console.WriteLine("Producto no encontrado.");
                        Console.ResetColor();
                    }
                }

                FrmProductos.MenuDeSalida();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error al eliminar el producto: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            ProductoHelper.Pausa();
        }

        private static void MostrarListaProductos(NeoShopingDataContext context)
        {
            Console.Clear();
            var productos = context.Productos.ToList();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╚═════════════════════ Lista de Productos ═════════════════════╝\n");
            Console.ResetColor();

            if (productos.Any())
            {
                foreach (var p in productos)
                {
                    Console.WriteLine($"ID: {p.IdProducto} ║ Nombre: {p.Nombre} ║ Precio: {p.Precio} ║ Stock: {p.Stock} ║ ID Proveedor: {p.IdProveedor}");
                }
            }
            else
            {
                Console.WriteLine("No hay productos registrados.");
            }

            ProductoHelper.Pausa();
        }

        private static void BuscarProductoPorId(NeoShopingDataContext context)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╚═════════════════════ Buscar Producto ═════════════════════╝\n");
            Console.ResetColor();

            int id = ProductoHelper.LeerEntero("Ingrese el ID del producto: ");
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == id);

            if (producto != null)
            {
                Console.WriteLine($"\n║ ID: {producto.IdProducto}");
                Console.WriteLine($"║ Nombre: {producto.Nombre}");
                Console.WriteLine($"║ Descripción: {producto.Descripcion}");
                Console.WriteLine($"║ Precio: {producto.Precio}");
                Console.WriteLine($"║ Stock: {producto.Stock}");
                Console.WriteLine($"║ ID Proveedor: {producto.IdProveedor}");
            }
            else
            {
                Console.WriteLine("\nProducto no encontrado. Verifique que el ID sea correcto.");
            }

            ProductoHelper.Pausa();
        }
    }
}
