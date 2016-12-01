using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class TipoMap : ClassMapping<Models.Tipo>
    {
        public TipoMap()
            : base()
        {
            Table("formulario");

            Id<long>(x => x.TipoId, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("tipoid");
            });
            Property(x => x.Nombre, x => x.Column("name"));

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