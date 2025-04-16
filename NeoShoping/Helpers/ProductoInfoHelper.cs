using NeoShoping.Entities;

namespace NeoShoping.Helpers
{
    public static class ProductoInfoHelper
    {
        public static string LeerNombreProducto()
        {
            return ProductoInputHelper.LeerTextoNoVacio("Nombre del producto: ");
        }

        public static string LeerDescripcionProducto()
        {
            return ProductoInputHelper.LeerTextoNoVacio("Descripción del producto: ");
        }

        public static decimal LeerPrecioProducto()
        {
            return ProductoInputHelper.LeerDecimal("Precio del producto: ");
        }

        public static int LeerStockProducto()
        {
            return ProductoInputHelper.LeerEnteroNoNegativo("Stock del producto: ");
        }

        public static int LeerIdProveedor()
        {
            return ProductoInputHelper.LeerEntero("ID del proveedor: ");
        }

        public static Producto ObtenerDatosProducto()
        {
            string nombre = LeerNombreProducto();
            string descripcion = LeerDescripcionProducto();
            decimal precio = LeerPrecioProducto();
            int stock = LeerStockProducto();
            int idProveedor = LeerIdProveedor();

            return new Producto(nombre, precio, stock, descripcion)
            {
                IdProveedor = idProveedor
            };
        }

    }
}
