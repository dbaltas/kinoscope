using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ObLib.Repositories;
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

        public virtual void Save()
        {
            NHibernateHelper.OpenSession().Save(this);
        }

    }
}
