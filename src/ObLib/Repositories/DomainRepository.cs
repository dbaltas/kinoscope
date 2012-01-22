using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObLib.Domain;

using NHibernate;
using NHibernate.Criterion;

namespace ObLib.Repositories
{
	public class DomainRepository<T> : IDomainRepository<T>
	{
		public void Add(T researcher)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			using (ITransaction transaction = session.BeginTransaction())
			{
				session.Save(researcher);
				transaction.Commit();
			}
		}

		public void Update(T researcher)
		{
			using (ISession session = NHibernateHelper.OpenSession()) {
				using (ITransaction transaction = session.BeginTransaction()) {
					session.Update(researcher);
					transaction.Commit();
				}
			}
		}
		
		public int Count()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				ICriteria criteria = session.CreateCriteria(typeof(T));
				Int32 rowCount = criteria.SetProjection(NHibernate.Criterion.Projections.RowCount()).UniqueResult<int>();
				return rowCount;
			}
		}	
		
		public void Remove(T researcher)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					session.Delete(researcher);
					transaction.Commit();
				}
			}
		}

		public T GetByID(long Id)
		{
			using (ISession session = NHibernateHelper.OpenSession())
				return session.Get<T>(Id);
		}
	
/*
		public T GetByName(string name)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				T researcher = session
					.CreateCriteria(typeof(T))
					.Add(Restrictions.Eq("Name", name))
					.UniqueResult<T>();
				return researcher;
			}
		}

		public ICollection<T> GetByCategory(string category)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var researchers = session.
					CreateCriteria(typeof(T)).
					Add(Restrictions.Eq("Category", category)).List<T>();

				return researchers;
			}
		}
		*/
	}
}

