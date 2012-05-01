using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Criterion;

namespace ObLib.Domain
{
    public class Settings : ActiveRecordBase<Settings>
    {
        public virtual String Name { get; set; }
        public virtual String Value { get; set; }

        private const string _NameLastLoggedInResearcherID = "last-logged-in-researcher-id";

        public Settings()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public static Researcher lastLoggedInResearcher
        {
            get
            {
                Settings settings = _findOneByName(_NameLastLoggedInResearcherID);
                if (settings != null)
                {
                    return Researcher.Find(Int32.Parse(settings.Value));
                }

                return null;
            }
            set
            {
                Settings settings = _findOneByName(_NameLastLoggedInResearcherID);
                if (settings == null)
                {
                    settings = new Settings() { Name = _NameLastLoggedInResearcherID};
                }
                settings.Value = value.Id.ToString();
                settings.Save();
            }
        }

        private static Settings _findOneByName(String name)
        {
            return NHibernateHelper.OpenSession()
                    .CreateCriteria(typeof(Settings))
                    .Add(Restrictions.Eq("Name", name))
                    .UniqueResult<Settings>();
        }
    }
}
