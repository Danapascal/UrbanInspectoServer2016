namespace WebServicesProject.Models
{
    public class Respuesta
    {
        public virtual long RespuestaId { get; set; }

        public virtual long FormularioRespondidoId { get; set; }

        public virtual long PosibleRespuestaId { get; set; }

        public virtual string Texto { get; set; }

       public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}