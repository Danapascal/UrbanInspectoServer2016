using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using WebServicesProject.Models;

namespace WebServicesProject.Database
{
    public class FormularioRespondidoMap : ClassMapping<Models.FormularioRespondido>
    {
        public FormularioRespondidoMap()
            : base()
        {
            Table("formularioRespondido");

            Id<long>(x => x.FormularioRespondidoId, x =>
            {
                x.Generator(Generators.Identity);
                x.Column("formulariorespondidoid");
            });

            Property(x => x.FechaRespondido, x => x.Column("fechaalta"));
            
            Property(x => x.Latitud, x => x.Column("latitud"));

            Property(x => x.Longitud, x => x.Column("longitud"));
            
            Set(x => x.Respuestas, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Cascade(Cascade.All);
                cm.Key(key => key.Column("formulariorespondidoid"));

            },
            action => action.OneToMany());

            Property(x => x.UsuarioId, x => x.Column("usuarioid"));
            /*
            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("usuarioid");
                m.Update(false);
            });
            */
            Property(x => x.FormularioId, x => x.Column("formularioid"));
            /*
            ManyToOne(x => x.Formulario, m =>
            {
                m.Column("formularioid");
                m.Update(false);
            });
            */
        }
    }
}