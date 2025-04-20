namespace NeoShopping.Entities
{
    public abstract class EntregaBase
    {
        public virtual int IdEntrega { get; set; }
        public virtual int IdOrden { get; set; }
        public virtual DateTime FechaEntrega { get; set; }
        public virtual string RecibidoPor { get; set; }

        public EntregaBase(int idOrden, DateTime fechaEntrega, string recibidoPor)
        {
            IdOrden = idOrden;
            FechaEntrega = fechaEntrega;
            RecibidoPor = recibidoPor;
        }

        public abstract string MostrarInformacion();
    }
}
