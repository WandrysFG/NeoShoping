//using NeoShoping.Entities;
//using NeoShoping.Helpers;

//namespace NeoShoping.Helpers.EntregaHelpers
//{
//    public static class EntregaInfoHelper
//    {
//        public static int LeerIdOrden()
//        {
//            return InputHelper.LeerEntero("ID de la orden: ");
//        }

//        public static DateTime LeerFechaEntrega()
//        {
//            return InputHelper.LeerFecha("Fecha de entrega (YYYY-MM-DD): ");
//        }

//        public static string LeerRecibidoPor()
//        {
//            return InputHelper.LeerTextoNoVacio("Recibido por: ");
//        }

//        public static string LeerObservaciones()
//        {
//            return InputHelper.LeerTextoOpcional("Observaciones (opcional): ");
//        }

//        public static Entrega ObtenerDatosEntrega()
//        {
//            int idOrden = LeerIdOrden();
//            DateTime fechaEntrega = LeerFechaEntrega();
//            string recibidoPor = LeerRecibidoPor();
//            string observaciones = LeerObservaciones();

//            return new Entrega(idOrden, fechaEntrega, recibidoPor, observaciones);
//        }
//    }
//}
