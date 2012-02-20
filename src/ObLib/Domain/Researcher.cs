using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Criterion;

namespace ObLib.Domain
{
    public class Researcher : ActiveRecordBase<Researcher>
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime Tm { get; set; }
        public virtual IList<Project> Projects { get; set; }

        public virtual int ProjectCount { get { return Projects.Count; } }

        public static Researcher Current { get; set; }

        public Researcher()
        {
            Projects = new List<Project>();
        }

        public virtual void AddProject(Project project)
        {
            project.Researcher = this;
            Projects.Add(project);
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
            }
            return researcher;
        }
    }
}
