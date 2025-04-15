//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NeoShoping.Data;
//using NeoShoping.Entities;

//namespace NeoShoping.Logic.Repositories
//{
//    public class ProveedorRepository
//    {
//        private readonly DataContext _context = new DataContext();

//        public void AgregarProveedor(Proveedor proveedor)
//        {
//            _context.Proveedores.Add(proveedor);
//            _context.SaveChanges();
//        }

//        public List<Proveedor> ObtenerProveedores()
//        {
//            return _context.Proveedores.ToList();
//        }

//        public Proveedor ObtenerProveedorPorId(int id)
//        {
//            return _context.Proveedores.Find(id);
//        }

//        public void ActualizarProveedor(Proveedor proveedor)
//        {
//            _context.Proveedores.Update(proveedor);
//            _context.SaveChanges();
//        }

//        public void EliminarProveedor(int id)
//        {
//            var proveedor = _context.Proveedores.Find(id);
//            if (proveedor != null)
//            {
//_context.Proveedores.Remove(proveedor);
//                _context.SaveChanges();
//            }
//        }
//    }

//}
