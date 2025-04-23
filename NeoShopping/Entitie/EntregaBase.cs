namespace NeoShopping.Entities
{
    public abstract class EntregaBase
    {
        public virtual int IdEntrega { get; set; }
        public virtual int IdOrden { get; set; }
        public virtual DateTime FechaEntrega { get; set; }
        public virtual string RecibidoPor { get; set; }
        public virtual string Observaciones { get; set; }

        public EntregaBase(int idOrden, DateTime fechaEntrega, string recibidoPor, string observaciones = "")
        {
            IdOrden = idOrden;
            FechaEntrega = fechaEntrega;
            RecibidoPor = recibidoPor ?? throw new ArgumentNullException(nameof(recibidoPor));
            Observaciones = observaciones ?? string.Empty;
        }

        public EntregaBase() { }

        public abstract string MostrarInformacion();
    }
}
