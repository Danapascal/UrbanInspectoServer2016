using Microsoft.Owin;
using System;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Mapping.ByCode;
using Microsoft.Practices.Unity;
using System.Configuration;
using NHibernate.Context;

namespace WebServicesProject.App_Start
{
    public class NhibernateMiddleware : OwinMiddleware
    {
        private const string vet = "vet";
        ISessionFactory SessionFactory { get; set; }
        public NhibernateMiddleware(OwinMiddleware next, IUnityContainer unityContainer)
            : base(next)
        {
            var mappingsAssembly = typeof(Startup).Assembly;

            //Crear los mapeos de acuerdo a las clases definidas
            var mapper = new ModelMapper();
            mapper.AddMappings(mappingsAssembly.GetExportedTypes());
            var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            //Terminar configuracion
            var nhibernateConfiguration = new NHibernate.Cfg.Configuration().Configure();
            nhibernateConfiguration.AddMapping(domainMapping);
            var settingValue = ConfigurationManager.ConnectionStrings[vet];
            nhibernateConfiguration.SetProperty("connection.connection_string", settingValue.ConnectionString);
            //Crear sessionFactory
            SessionFactory = nhibernateConfiguration.BuildSessionFactory();

            //Generacion de la base de datos
            //new NHibernate.Tool.hbm2ddl.SchemaExport(nhibernateConfiguration).Execute(false, true, false);

            unityContainer.RegisterInstance<ISessionFactory>(SessionFactory);
        }

        public override async Task Invoke(IOwinContext context)
        {
            BindSession();

            bool exception = false;
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception)
            {
                exception = true;
            }

            UnbindSession(exception);
        }

        private void UnbindSession(bool exception)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            var transaction = session.Transaction;

            if (transaction.WasCommitted || transaction.WasRolledBack) return;

            if (exception)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }
        }

        private void BindSession()
        {
            var session = SessionFactory.OpenSession();
            session.BeginTransaction();
            CurrentSessionContext.Bind(session);
        }
    }
}