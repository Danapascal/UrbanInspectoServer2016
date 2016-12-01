using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class RespuestaMap : ClassMapping<Models.Respuesta>
    {
        public RespuestaMap()
            : base()
        {
            Table("respuesta");

            Id<long>(x => x.RespuestaId, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("respuestaid");
            });
            Property(x => x.Texto, x => x.Column("texto"));
            Property(x => x.PosibleRespuestaId, x => x.Column("posiblerespuestaid"));
            Property(x => x.FormularioRespondidoId, x => x.Column("formulariorespondidoid"));
            
        }
    }
}