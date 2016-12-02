using System.Collections.Generic;
using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    class CompanySearch : AbstractCompanyVisitor
    {
        public string Query { get; set; }

        private readonly IList<AbstractCompanyEntity> _results  = new List<AbstractCompanyEntity>();

        public override void VisitEmployee(Employee employee)
        {
            if (employee.Name.ToLower().Contains(Query.ToLower())) _results.Add(employee);
        }

        public override void VisitGroup(Group group)
        { 
            if (group.Name.ToLower().Contains(Query.ToLower())) _results.Add(group);

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
