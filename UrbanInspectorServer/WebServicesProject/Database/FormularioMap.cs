using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class FormularioMap : ClassMapping<Models.Formulario>
    {
        public FormularioMap()
            : base()
        {
            Table("formulario");

            Id<long>(x => x.FormularioId, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("formularioid");
            });
            Property(x => x.Nombre, x => x.Column("name"));
            Property(x => x.FechaAlta, x => x.Column("fechaalta"));

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