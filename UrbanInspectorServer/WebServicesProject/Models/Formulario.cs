using System.Collections.Generic;

namespace WebServicesProject.Models
{
    public class Formulario
    {
        public virtual long FormularioId { get; set; }

       public virtual string Nombre { get; set; }

        public virtual System.DateTime FechaAlta{ get; set; }

        public virtual ICollection<Pregunta> Preguntas { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}