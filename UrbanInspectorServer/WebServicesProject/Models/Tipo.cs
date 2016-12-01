namespace WebServicesProject.Models
{
    public class Tipo
    {
        public virtual long TipoId { get; set; }

       public virtual string Nombre { get; set; }

       public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}