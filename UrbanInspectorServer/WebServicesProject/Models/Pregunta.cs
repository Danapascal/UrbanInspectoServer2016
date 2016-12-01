using System.Collections.Generic;

namespace WebServicesProject.Models
{
    public class Pregunta
    {
        public virtual long PreguntaId { get; set; }

        public virtual Tipo Tipo { get; set; }

        public virtual Formulario Formulario { get; set; }

        public virtual string Texto { get; set; }

        public virtual ICollection<PosibleRespuesta> PosibleRespuesta { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}