namespace WebServicesProject.DTOs
{
    public class UsuarioDto
    {
        public virtual long UsuarioId { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual System.Boolean Activo { get; set; }

        public virtual System.DateTime UltimoLogin { get; set; }

    }
}