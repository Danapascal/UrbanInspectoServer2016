namespace WebServicesProject.DTOs
{
    public class ToDoCreationDto
    {
        public virtual string Titulo { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual long PrioridadId { get; set; }

        public virtual long UsuarioId { get; set; }
    }
}