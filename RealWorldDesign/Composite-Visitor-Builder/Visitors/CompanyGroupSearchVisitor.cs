using System.Collections.Generic;
using System.Linq;
using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    class CompanyGroupSearchVisitor : AbstractCompanyVisitor
    {
        public string Query { get; set; }

        private readonly IList<Group> _results = new List<Group>();

        public override void VisitEmployee(Employee employee)
        {
        }

        public override void VisitGroup(Group group)
        {
            if (group.Name.ToLower().Contains(Query.ToLower())) _results.Add(group);

            foreach (var child in group.GetChildren())
            {
                child.AcceptVisitor(this);
            }
        }

        public IList<Group> GetResults()
        {
            var ret = _results.Select(x => x).ToList();
            _results.Clear();
            return ret;
        }
    }
}
