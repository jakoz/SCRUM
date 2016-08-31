using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SCRUM.Models;
using FluentNHibernate.Mapping;

namespace SCRUM.Mappings
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Id(x => x.ID);
            Map(x => x.WhoMadePost);
            Map(x => x.WhatIHaveDone);
            Map(x => x.WhatIWillDo);
            Map(x => x.WhatProblemsIgot);
            Map(x => x.DateOfPost);
        }
    }
}