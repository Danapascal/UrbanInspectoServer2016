namespace WebServicesProject.DTOs
{
    public class ToDoDto
    {
        public virtual long Id { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual string Prioridad { get; set; }

        public virtual UsuarioDto Usuario { get; set; }
    }
}