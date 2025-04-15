//using NeoShoping.Entities;
//using NeoShoping.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace NeoShoping.Logic
//{
//    public class ProductoRepository : IProductoRepository
//    {
//        private readonly NeoShopingDataContext _context;

//        public ProductoRepository(NeoShopingDataContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//        }

//        public void AgregarProducto(Producto producto)
//        {
//            try
//            {
//                _context.Productos.Add(producto);
//                _context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al agregar el producto: {ex.Message}");
//            }
//        }
//        public IEnumerable<Producto> ObtenerProductos()
//        {
//            try
//            {
//                return _context.Productos.ToList();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al obtener productos: {ex.Message}");
//                return new List<Producto>();
//            }
//        }

//        public Producto ObtenerProductoPorId(int id)
//        {
//            try
//            {
//                return _context.Productos.Find(id);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al buscar el producto: {ex.Message}");
//                return null;
//            }
//        }

//        public void ActualizarProducto(Producto producto)
//        {
//            try
//            {
//                _context.Productos.Update(producto);
//                _context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
//            }
//        }

//        public void EliminarProducto(int id)
//        {
//            try
//            {
//                var producto = _context.Productos.Find(id);
//                if (producto != null)
//                {
//                    _context.Productos.Remove(producto);
//                    _context.SaveChanges();
//                }
//                else
//                {
//                    Console.WriteLine("Producto no encontrado.");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
//            }
//        }
//    }
//}