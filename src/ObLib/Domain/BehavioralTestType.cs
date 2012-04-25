using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Criterion;

namespace ObLib.Domain
{
    public class BehavioralTestType : ActiveRecordBase<BehavioralTestType>
	{
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        private static BehavioralTestType _fst;
        private static BehavioralTestType _epm;
        private static BehavioralTestType _objectRecognition;

        public static BehavioralTestType Fst
        {
            get
            {
                if (_fst == null)
                {
                    BehavioralTestType behavioralTestType = NHibernateHelper.OpenSession()
                            .CreateCriteria(typeof(BehavioralTestType))
                            .Add(Restrictions.Eq("Name", _FST))
                            .UniqueResult<BehavioralTestType>();

                    if (behavioralTestType == null)
                    {
                        Logger.logError("NO FST behavioral test type found");
                    }
                    _fst = behavioralTestType;
                }

                return _fst;
            }
        }

        public static BehavioralTestType Epm
        {
            get
            {
                if (_epm == null)
                {
                    BehavioralTestType behavioralTestType = NHibernateHelper.OpenSession()
                            .CreateCriteria(typeof(BehavioralTestType))
                            .Add(Restrictions.Eq("Name", _EPM))
                            .UniqueResult<BehavioralTestType>();

                    if (behavioralTestType == null)
                    {
                        Logger.logError("NO EPM behavioral test type found");
                    }
                    _epm = behavioralTestType;
                }

                return _epm;
            }
        }

        public static BehavioralTestType ObjectRecognition
        {
            get
            {
                if (_objectRecognition == null)
                {
                    BehavioralTestType behavioralTestType = NHibernateHelper.OpenSession()
                            .CreateCriteria(typeof(BehavioralTestType))
                            .Add(Restrictions.Eq("Name", _OBJECT_RECOGNITION))
                            .UniqueResult<BehavioralTestType>();

                    if (behavioralTestType == null)
                    {
                        Logger.logError("NO Object Recognition behavioral test type found");
                    }
                    _objectRecognition = behavioralTestType;
                }

                return _objectRecognition;
            }
        }

        private const string _FST = "FST";
        private const string _EPM = "EPM";
        private const string _OBJECT_RECOGNITION = "Object Recognition";

        public override string ToString()
        {
            return Name;
        }

    }
}
