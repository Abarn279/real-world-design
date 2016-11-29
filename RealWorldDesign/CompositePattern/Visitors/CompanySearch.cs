using System.Collections.Generic;
using CompositePattern.Composites;

namespace CompositePattern.Visitors
{
    class CompanySearch : AbstractCompanyVisitor
    {
        private string Query { get; set; }

        private IList<AbstractCompanyEntity> Results { get; set; }

        public override void VisitEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public override void VisitGroup(Group group)
        {
            throw new System.NotImplementedException();
        }
    }
}
