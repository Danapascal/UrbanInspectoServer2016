using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class PreguntaMap : ClassMapping<Models.Pregunta>
    {
        public PreguntaMap()
            : base()
        {
            Table("pregunta");

            Id<long>(x => x.PreguntaId, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("preguntaid");
            });

            Property(x => x.Texto, x => x.Column("texto"));
            
            Set(x => x.PosibleRespuesta, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(key => key.Column("preguntaid"));
            },
            action => action.OneToMany());

            ManyToOne(x => x.Tipo, m =>
            {
                m.Column("tipoid");
                m.Update(false);
            });

            ManyToOne(x => x.Formulario, m =>
            {
                m.Column("formularioid");
                m.Update(false);
            });

        }
    }
}