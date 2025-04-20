//using NeoShoping.Entities;
//using NeoShoping.Helpers;

//namespace NeoShoping.Helpers.DetalleOrdenHelpers
//{
//    public static class DetalleOrdenInfoHelper
//    {
//        public static int LeerIdOrden()
//        {
//            return InputHelper.LeerEntero("Ingrese el ID de la orden: ");
//        }

//        public static int LeerIdProducto()
//        {
//            return InputHelper.LeerEntero("Ingrese el ID del producto: ");
//        }

//        public static int LeerCantidad()
//        {
//            return InputHelper.LeerEntero("Ingrese la Cantidad: ");
//        }

//        public static decimal LeerPrecioUnitario()
//        {
//            return InputHelper.LeerDecimal("Ingrese el Precio unitario: ");
//        }

//        public static decimal LeerSubTotal()
//        {
//            return InputHelper.LeerDecimal("Ingrese el subtotal: ");
//        }

//        public static DetalleOrden ObtenerDatosDetalleOrden()
//        {
//            int idOrden = LeerIdOrden();
//            int idProducto = LeerIdProducto();
//            int cantidad = LeerCantidad();
//            decimal precioUnitario = LeerPrecioUnitario();
//            decimal Subtotal = LeerSubTotal();

//            return new DetalleOrden(idOrden, idProducto, cantidad, precioUnitario);
//        }
//    }
//}
