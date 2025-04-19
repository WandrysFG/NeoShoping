//using NeoShoping.Entities;
//using NeoShoping.Helpers;

//namespace NeoShoping.Helpers.OrdenHelpers
//{
//    public static class OrdenInfoHelper
//    {
//        public static int LeerIdCliente()
//        {
//            return InputHelper.LeerEntero("ID del cliente: ");
//        }

//        public static DateTime LeerFechaOrden()
//        {
//            return InputHelper.LeerFecha("Fecha de la orden (yyyy-mm-dd): ");
//        }

//        public static decimal LeerTotalOrden()
//        {
//            return InputHelper.LeerDecimal("Total de la orden: ");
//        }

//        public static string LeerEstadoOrden()
//        {
//            return InputHelper.LeerTextoNoVacio("Estado de la orden: ");
//        }

//        public static int LeerIdProveedor()
//        {
//            return InputHelper.LeerEntero("ID del proveedor: ");
//        }

//        public static Orden ObtenerDatosOrden()
//        {
//            int idCliente = LeerIdCliente();
//            int idProveedor = LeerIdProveedor();
//            DateTime fecha = LeerFechaOrden();
//            decimal total = LeerTotalOrden();
//            string estado = LeerEstadoOrden();

//            return new Orden(idCliente, idProveedor, fecha, total, estado);
//        }
//    }
//}


////using NeoShoping.Entities;

////namespace NeoShoping.Helpers.OrdenHelpers
////{
////    public static class OrdenInfoHelper
////    {
////        public static int LeerIdCliente()
////        {
////            return OrdenInputHelper.LeerEntero("ID del cliente: ");
////        }

////        public static DateTime LeerFechaOrden()
////        {
////            return OrdenInputHelper.LeerFecha("Fecha de la orden (yyyy-mm-dd): ");
////        }

////        public static decimal LeerTotalOrden()
////        {
////            return OrdenInputHelper.LeerDecimal("Total de la orden: ");
////        }

////        public static string LeerEstadoOrden()
////        {
////            return OrdenInputHelper.LeerTextoNoVacio("Estado de la orden: ");
////        }

////        public static int LeerIdProveedor()
////        {
////            return OrdenInputHelper.LeerEntero("ID del proveedor: ");
////        }

////        public static Orden ObtenerDatosOrden()
////        {
////            int idCliente = LeerIdCliente();
////            int idProveedor = LeerIdProveedor();
////            DateTime fecha = LeerFechaOrden();
////            decimal total = LeerTotalOrden();
////            string estado = LeerEstadoOrden();

////            return new Orden(idCliente, idProveedor, fecha, total, estado);

////        }
////    }
////}
