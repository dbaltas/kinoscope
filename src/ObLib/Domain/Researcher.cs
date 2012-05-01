using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Criterion;

namespace ObLib.Domain
{
    public class Researcher : ActiveRecordBase<Researcher>
    {
        private IList<Project> _projects;

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<ResearcherBehaviorKeyStroke> ResearcherBehaviorKeyStrokes { get; set; }

        public virtual IList<Project> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                if (this == Researcher.Current)
                {
                    ActiveProject = Projects.Count == 0 ? null : Projects[0];
                }
            }
        }

        private Project _ActiveProject;
        public virtual Project ActiveProject {
            get
            {
                if (_ActiveProject == null && Projects.Count > 0)
                {
                    _ActiveProject = Projects[0];
                }
                return _ActiveProject;
            }
            set
            {
                _ActiveProject = value;
                NHibernateHelper.OnActiveProjectChanged(_ActiveProject, new EventArgs());
            }
        }
        public virtual bool IsAdmin
        {
            get
            {
                return Username == "admin";
            }
        }

        public virtual int ProjectCount { get { return Projects.Count; } }

        public static Researcher Current { get; set; }

        public Researcher()
        {
            Projects = new List<Project>();
            ResearcherBehaviorKeyStrokes = new List<ResearcherBehaviorKeyStroke>();
        }

        public virtual void AddProject(Project project)
        {
            project.Researcher = this;
            Projects.Add(project);

            if (ActiveProject == null)
            {
                ActiveProject = project;
            }
        }

        public virtual void AddResearcherBehaviorKeyStroke(ResearcherBehaviorKeyStroke researcherBehaviorKeyStroke)
        {
            researcherBehaviorKeyStroke.Researcher = this;
            ResearcherBehaviorKeyStrokes.Add(researcherBehaviorKeyStroke);
        }

        public virtual void RemoveProject(Project project)
        {
            Projects.Remove(project);

            if (ActiveProject == project)
            {
                ActiveProject = Projects.Count == 0 ? null : Projects[0];
            }
        }

        public static Researcher Authenticate(String username, String password)
        {
            Researcher researcher = NHibernateHelper.OpenSession()
                    .CreateCriteria(typeof(Researcher))
                    .Add(Restrictions.Eq("Username", username))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<Researcher>();
            if (researcher != null)
            {
                Current = researcher;
                Settings.lastLoggedInResearcher = researcher;
            }
            return researcher;
        }

        public static Researcher Find(string username)
        {
            return NHibernateHelper.OpenSession()
                                   .CreateCriteria(typeof(Researcher))
                                   .Add(Restrictions.Eq("Username", username))
                                   .UniqueResult<Researcher>();
        }

        public override string ToString()
        {
            return Username;
        }

        public override void Delete()
        {
            if (IsAdmin)
            {
                throw new InvalidOperationException("User admin cannot be deleted.");
            }
            base.Delete();
        }
    }
}
