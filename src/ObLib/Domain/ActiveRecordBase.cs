using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ObLib.Domain;

namespace ObLib.Domain
{
    // use of generics here in order to pass the child class in the CreateCriteria<>. Passing just this class name resulted to a list unable to be casted
    public class ActiveRecordBase<T>
    {
        public static IList All()
        {
            return NHibernateHelper.OpenSession().CreateCriteria<ActiveRecordBase<T>>().List();
        }

        public static T Find(Int32 id)
        {
            return NHibernateHelper.OpenSession().Get<T>(id);
        }

        public virtual void Save()
        {
            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(this);
                transaction.Commit();
            }
        }

        public virtual void Delete()
        {
            ISession session = NHibernateHelper.OpenSession();
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(this);
                transaction.Commit();
            }
        }
    }
}
