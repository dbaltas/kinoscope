using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObLib.Domain
{
	public class Project
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual Researcher Researcher { get; set; }
		public virtual DateTime Tm { get; set; }
	}
}
