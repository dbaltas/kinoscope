using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Criterion;

namespace ObLib.Domain
{
    public class BehavioralTestType : ActiveRecordBase<BehavioralTestType>
	{
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Tm { get; set; }

        public static BehavioralTestType Fst
        {
            get
            {
                BehavioralTestType behavioralTestType = NHibernateHelper.OpenSession()
                        .CreateCriteria(typeof(BehavioralTestType))
                        .Add(Restrictions.Eq("Name", _FST))
                        .UniqueResult<BehavioralTestType>();

                if (behavioralTestType == null)
                {
                    Logger.logError("NO FST behavioral test type found");
                }
                return behavioralTestType;
            }
        }

        private const string _FST = "FST";
    }
}
