using System;
using System.Collections.Generic;

namespace WebServicesProject.Models
{
    public class FormularioRespondido
    {
        public virtual long FormularioRespondidoId { get; set; }

        public virtual long UsuarioId { get; set; }

        public virtual long FormularioId { get; set; }

        public virtual DateTime FechaRespondido { get; set; }

        public virtual ICollection<Respuesta> Respuestas { get; set; }

        public virtual long Latitud { get; set; }

        public virtual long Longitud { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}