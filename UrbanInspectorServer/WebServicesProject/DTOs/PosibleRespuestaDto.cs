using System.Collections.Generic;

namespace WebServicesProject.DTOs
{
    public class PosibleRespuestaDto
    {
        public virtual long PosibleRespuestaId { get; set; }

        public virtual long PreguntaId { get; set; }
                
        public virtual string Texto { get; set; }

       
    }
}