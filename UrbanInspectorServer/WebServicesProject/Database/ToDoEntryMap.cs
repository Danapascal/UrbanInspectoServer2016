using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class ToDoEntryMap : ClassMapping<ToDoEntry>
    {
        public ToDoEntryMap()
            : base()
        {
            Table("ToDos");

            Id<long>(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("Id_Todo");
            });


            Property(x => x.Titulo);
            Property(x => x.Descripcion);

            ManyToOne(x => x.Prioridad, m =>
            {
                m.Column("PrioridadId");
                m.Update(false);
            });
            
            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("UsuarioId");
                m.Lazy(LazyRelation.NoLazy);
                m.NotNullable(true);
            });
        }
    }
}