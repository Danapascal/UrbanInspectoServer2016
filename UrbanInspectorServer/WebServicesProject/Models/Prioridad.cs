namespace WebServicesProject.Models
{
    public class Prioridad
    {
        public virtual long Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual long CantidadToDos { get; set; }
    }
}