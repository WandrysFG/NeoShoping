namespace NeoShopping.Entities
{
    public abstract class ProveedorBase
    {
        public virtual int IdProveedor { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Email { get; set; }
        public virtual string Direccion { get; set; }
        public virtual string RNC { get; set; }

        protected ProveedorBase(string nombre, string telefono, string email, string direccion, string rnc)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            RNC = rnc;
        }

        protected ProveedorBase() { }

        public abstract string MostrarInformacion();
    }
}

