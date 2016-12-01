using System;
using System.Collections.Generic;

namespace WebServicesProject.DTOs
{
    public class FormularioRespondidoDto
    {
        public virtual DateTime  FechaRespondido { get; set; }

        public virtual long FormularioId { get; set; }

        public virtual long UsuarioId { get; set; }

        public virtual string Foto { get; set; }
                
        public virtual ICollection<RespuestaDto> Respuestas { get; set; }

        public virtual long Latitud { get; set; }

        public virtual long Longitud { get; set; }
     
    }
}