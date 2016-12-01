using NHibernate.Id;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class PrioridadMap : ClassMapping<Prioridad>
    {
        public PrioridadMap()
            : base()
        {
            Table("Prioridades");

            Id<long>(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
            });
            Property(x => x.Nombre);

            Property(x => x.CantidadToDos, map =>
            {
                map.Formula("(select count(*) FROM todos t WHERE t.PrioridadId = id)");
            });
        }
    }
}