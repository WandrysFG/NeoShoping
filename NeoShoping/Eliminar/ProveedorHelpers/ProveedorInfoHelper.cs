//using NeoShoping.Entities;
//using NeoShoping.Helpers;

//namespace NeoShoping.Helpers.ProveedorHelpers
//{
//    public static class ProveedorInfoHelper
//    {
//        public static string LeerNombreProveedor()
//        {
//            return InputHelper.LeerTextoNoVacio("Nombre del proveedor: ", 50);
//        }

//        public static string LeerTelefonoProveedor()
//        {
//            return InputHelper.LeerTextoNoVacio("Teléfono del proveedor: ", 20);
//        }

//        public static string LeerEmailProveedor()
//        {
//            return InputHelper.LeerTextoNoVacio("Email del proveedor: ", 100);
//        }

//        public static string LeerDireccionProveedor()
//        {
//            return InputHelper.LeerTextoNoVacio("Dirección del proveedor: ", 200);
//        }

//        public static string LeerRNCProveedor()
//        {
//            return InputHelper.LeerTextoNoVacio("RNC del proveedor: ", 15);
//        }

//        public static Proveedor ObtenerDatosProveedor()
//        {
//            string nombre = LeerNombreProveedor();
//            string telefono = LeerTelefonoProveedor();
//            string email = LeerEmailProveedor();
//            string direccion = LeerDireccionProveedor();
//            string rnc = LeerRNCProveedor();

//            return new Proveedor(nombre, telefono, email, direccion, rnc);
//        }
//    }
//}


////using NeoShoping.Entities;

////namespace NeoShoping.Helpers.ProveedorHelpers
////{
////    public static class ProveedorInfoHelper
////    {
////        public static string LeerNombreProveedor()
////        {
////            return ProveedorInputHelper.LeerTextoNoVacio("Nombre del proveedor: ", 50);
////        }

////        public static string LeerTelefonoProveedor()
////        {
////            return ProveedorInputHelper.LeerTextoNoVacio("Teléfono del proveedor: ", 20);
////        }

////        public static string LeerEmailProveedor()
////        {
////            return ProveedorInputHelper.LeerTextoNoVacio("Email del proveedor: ", 100);
////        }

////        public static string LeerDireccionProveedor()
////        {
////            return ProveedorInputHelper.LeerTextoNoVacio("Dirección del proveedor: ", 200);
////        }

////        public static string LeerRNCProveedor()
////        {
////            return ProveedorInputHelper.LeerTextoNoVacio("RNC del proveedor: ", 15);
////        }

////        public static Proveedor ObtenerDatosProveedor()
////        {
////            string nombre = LeerNombreProveedor();
////            string telefono = LeerTelefonoProveedor();
////            string email = LeerEmailProveedor();
////            string direccion = LeerDireccionProveedor();
////            string rnc = LeerRNCProveedor();

////            return new Proveedor(nombre, telefono, email, direccion, rnc);
////        }
////    }
////}
