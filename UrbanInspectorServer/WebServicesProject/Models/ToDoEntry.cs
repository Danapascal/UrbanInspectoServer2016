namespace WebServicesProject.Models
{
    public class ToDoEntry
    {
        public virtual long Id { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual Prioridad Prioridad { get; set; }

        public virtual Usuario Usuario { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}