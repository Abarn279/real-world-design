using System;
using System.Collections.Generic;
using CompositePattern.Composites;

namespace CompositePattern.Visitors
{
    class CompanySearch : AbstractCompanyVisitor
    {
        public string Query { get; set; }

        private readonly IList<AbstractCompanyEntity> _results  = new List<AbstractCompanyEntity>();

        public override void VisitEmployee(Employee employee)
        {
            if (employee.Name.Contains(Query)) _results.Add(employee);
        }

        public override void VisitGroup(Group group)
        { 
            if (group.Name.Contains(Query)) _results.Add(group);

            foreach (var child in group.GetChildren())
            {
                child.AcceptVisitor(this);
            }
        }

        public IList<AbstractCompanyEntity> GetResults()
        {
            return _results;
        }
    }
}
