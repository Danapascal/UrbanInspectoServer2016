namespace WebServicesProject.Models
{
    public class PosibleRespuesta
    {
        public virtual long PosibleRespuestaId { get; set; }

        public virtual long PreguntaId { get; set; }

        public virtual string Texto { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}