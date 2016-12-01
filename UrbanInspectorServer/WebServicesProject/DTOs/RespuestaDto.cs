using System.Collections.Generic;

namespace WebServicesProject.DTOs
{
    public class RespuestaDto
    {
        public virtual long PreguntaId { get; set; }

        public virtual long PosibleResputaId { get; set; }
                
        public virtual string Texto { get; set; }
       
    }
}