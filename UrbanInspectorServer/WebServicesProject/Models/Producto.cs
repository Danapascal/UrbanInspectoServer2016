namespace WebServicesProject.Models
{
    public class Producto
    {
        public virtual long Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual int PrecioUnitario { get; set; }

        public virtual int Utilidad { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}