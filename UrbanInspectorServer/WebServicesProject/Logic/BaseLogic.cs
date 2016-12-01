using NHibernate;
using System;

namespace WebServicesProject.Logic
{
    public class BaseLogic
    {
        private ISessionFactory sessionFactory;
        public BaseLogic(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null) throw new ArgumentNullException("sessionFactory no puede ser nulo");

            this.sessionFactory = sessionFactory;
        }

        protected ISession Session
        {
            get
            {
                return sessionFactory.GetCurrentSession();
            }
        }
    }
}