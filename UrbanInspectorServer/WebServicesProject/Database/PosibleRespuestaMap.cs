using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class PosibleRespuestaMap : ClassMapping<Models.PosibleRespuesta>
    {
        public PosibleRespuestaMap()
            : base()
        {
            Table("posiblerespuesta");

            Id<long>(x => x.PosibleRespuestaId, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("posiblerespuestaid");
            });
            Property(x => x.PreguntaId, x => x.Column("preguntaid"));
            Property(x => x.Texto, x => x.Column("texto"));

            //Set(x => x.Preguntas, cm =>
            //{
            //    cm.Lazy(CollectionLazy.Lazy);
            //    cm.Key(key => key.Column("formularioid"));
            //},
            //action => action.OneToMany()); 
                           
            //Property(x => x.Utilidad);
            //Property(x => x.PrecioUnitario);

            //ManyToOne(x => x.Prioridad, m =>
            //{
            //    m.Column("PrioridadId");
            //    m.Update(false);
            //});

            //ManyToOne(x => x.Usuario, m =>
            //{
            //    m.Column("UsuarioId");
            //    m.Lazy(LazyRelation.NoLazy);
            //    m.NotNullable(true);
            //});
        }
    }
}