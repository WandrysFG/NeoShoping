namespace NeoShoping.Entities
{
    public abstract class ClienteBase
    {
        public virtual int IdCliente { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Email { get; set; }
        public virtual string Direccion { get; set; }

        public ClienteBase(string nombre, string apellido, string telefono, string email, string direccion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }

        public abstract string MostrarInformacion();
    }
}
