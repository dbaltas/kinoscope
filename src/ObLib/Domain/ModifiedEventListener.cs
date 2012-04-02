using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Event.Default;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ObLib.Domain;

namespace ObLib.Domain
{
    // use of generics here in order to pass the child class in the CreateCriteria<>. Passing just this class name resulted to a list unable to be casted
    public class ModifiedEventListener : DefaultSaveEventListener
    {

        protected override object PerformSaveOrUpdate(NHibernate.Event.SaveOrUpdateEvent @event)
        {
            object _object = base.PerformSaveOrUpdate(@event);
            if (@event.Entity == Researcher.Current.ActiveProject )
            {
                NHibernateHelper.OnActiveProjectModified(this, new EventArgs());
            }
//            if (@event.Entity is Project)

            return _object;
        }
    }
}
