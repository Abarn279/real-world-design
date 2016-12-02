using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    abstract class AbstractCompanyVisitor
    {
        public abstract void VisitEmployee(Employee employee);

        public abstract void VisitGroup(Group group);
    }
}
