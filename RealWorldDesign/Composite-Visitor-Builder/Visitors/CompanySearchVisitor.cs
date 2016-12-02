using System.Collections.Generic;
using System.Linq;
using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    class CompanySearchVisitor : AbstractCompanyVisitor
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
            var ret = _results.Select(x => x).ToList();
            _results.Clear();
            return ret;
        }
    }
}
