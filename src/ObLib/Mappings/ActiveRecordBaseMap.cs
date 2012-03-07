using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Mapping;

namespace ObLib.Domain
{
    public class ActiveRecordBaseMap<T> : ClassMap<T> where T : ActiveRecordBase<T>
    {
        public ActiveRecordBaseMap()
        {
            Id(x => x.Id);
            Map(x => x.TmCreated);
            Map(x => x.TmModified);
        }
    }
}
