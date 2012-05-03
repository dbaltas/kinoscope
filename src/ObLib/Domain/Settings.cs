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
        private const string _NameLastActiveProjectForResearcherFormat = "last-active-project-for-researcher-id-{0}";
        private const string _NameLastActiveTrialForProjectFormat = "last-active-trial-for-project-id-{0}";

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
                    settings = new Settings() { Name = _NameLastLoggedInResearcherID };
                }
                settings.Value = value.Id.ToString();
                settings.Save();
            }
        }

        public static Project getLastActiveProjectForResearcher(Researcher researcher)
        {
            string settingName = String.Format(_NameLastActiveProjectForResearcherFormat, researcher.Id);
            Settings settings = _findOneByName(settingName);
            if (settings != null && settings.Value != null)
            {
                return Project.Find(Int32.Parse(settings.Value));
            }

            return null;
        }

        public static void setLastActiveProjectForResearcher(Researcher researcher, Project project)
        {
            string settingName = String.Format(_NameLastActiveProjectForResearcherFormat, researcher.Id);
            Settings settings = _findOneByName(settingName);
            if (settings == null)
            {
                settings = new Settings() { Name = settingName };
            }
            settings.Value = project != null ? project.Id.ToString() : null;
            settings.Save();
        }

        public static Trial getLastActiveTrialForProject(Project project)
        {
            string settingName = String.Format(_NameLastActiveTrialForProjectFormat, project.Id);
            Settings settings = _findOneByName(settingName);
            if (settings != null && settings.Value != null)
            {
                return Trial.Find(Int32.Parse(settings.Value));
            }

            return null;
        }

        public static void setLastActiveTrialForProject(Trial trial)
        {
            Project project = trial.Session.BehavioralTest.Project;
            string settingName = String.Format(_NameLastActiveTrialForProjectFormat, project.Id);
            Settings settings = _findOneByName(settingName);
            if (settings == null)
            {
                settings = new Settings() { Name = settingName };
            }
            settings.Value = trial != null ? trial.Id.ToString() : null;
            settings.Save();
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
