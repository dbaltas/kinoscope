using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObLib.Domain;

using NHibernate;
using NHibernate.Criterion;

namespace ObLib.Repositories
{
	public class ResearcherRepository : DomainRepository<Researcher>
	{
		public Researcher GetByUsername(string username)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				Researcher researcher = session
					.CreateCriteria(typeof(Researcher))
					.Add(Restrictions.Eq("Username", username))
					.UniqueResult<Researcher>();
					var foo = researcher.Username;
			foreach (var project in researcher.Projects)
			{
			}
				return researcher;
			}
		}
	}
}

