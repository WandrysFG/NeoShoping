namespace NeoShopping.Entities
{
    public abstract class ProductoBase
    {
        public virtual int IdProducto { get; set; }
        public virtual string Nombre { get; set; }
        public virtual decimal Precio { get; set; }
        public virtual int Stock { get; set; }

        public ProductoBase(string nombre, decimal precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public abstract string MostrarInformacion();
    }
}
