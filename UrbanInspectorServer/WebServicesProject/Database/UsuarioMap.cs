using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
            : base()
        {
            Table("usuario");

            Id<int>(x => x.UsuarioId, x =>
            {
                x.Generator(Generators.Identity);
            });
            //Property(x => x.UsuarioId);
            Property(x => x.Nombre);
            Property(x => x.Apellido);
            Property(x => x.Password);
            Property(x => x.Login);
            Property(x => x.Activo);
            Property(x => x.UltimoLogin);

            /*Set(x => x.ToDos, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(key => key.Column("UsuarioId"));
            },
            action => action.OneToMany());*/
        }
    }
}