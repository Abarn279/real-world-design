using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    class CompanyGroupSearch : CompanySearch
    {
        public override void VisitEmployee(Employee employee)
        {
            // No Action
        }
    }
}
