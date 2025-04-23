
namespace NeoShopping.Entities
{
    public abstract class DetalleOrdenBase
    {
        public virtual int IdDetalle { get; set; }
        public virtual int IdOrden { get; set; }
        public virtual int IdProducto { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual decimal PrecioUnitario { get; set; }

        public virtual decimal Subtotal => Cantidad * PrecioUnitario;

        public DetalleOrdenBase(int idOrden, int idProducto, int cantidad, decimal precioUnitario)
        {
            IdOrden = idOrden;
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public DetalleOrdenBase() { }

        public abstract string MostrarInformacion();
    }
}
