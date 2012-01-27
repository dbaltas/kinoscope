using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
	public class Researcher : ActiveRecordBase<Researcher>
	{
		public virtual int Id { get; set; }
		public virtual string Username { get; set; }
		public virtual string Password { get; set; }
		public virtual DateTime Tm { get; set; }
        public virtual IList<Project> Projects { get; set; }

        public Researcher()
        {
            Projects = new List<Project>();
        }

        public virtual void AddProject(Project project)
        {
            project.Researcher = this;
            Projects.Add(project);
        }
	}
}
