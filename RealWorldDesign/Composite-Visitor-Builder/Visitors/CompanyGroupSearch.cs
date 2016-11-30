using Composites;

namespace Visitors
{
    class CompanyGroupSearch : CompanySearch
    {
        public override void VisitEmployee(Employee employee)
        {
            // No Action
        }
    }
}
