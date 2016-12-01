using System.Collections.Generic;

namespace WebServicesProject.DTOs
{
    public class PreguntaDto
    {
        public virtual long PreguntaId { get; set; }

        public virtual long FormularioId { get; set; }

        public virtual long TipoId { get; set; }
        
        public virtual string Texto { get; set; }

        public virtual ICollection<PosibleRespuestaDto> PosiblesRespuestas { get; set; }
    }
}