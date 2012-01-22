using System;
using System.Collections.Generic;

namespace ObLib.Domain
{

	public interface IDomainRepository<T>
	{
		void Add(T researcher);
		void Update(T researcher);
		void Remove(T researcher);
		int Count();
		T GetByID(long Id);
	}
}
