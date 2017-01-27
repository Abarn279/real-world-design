using System.Collections.Generic;
using System.Linq;
using CompositeVisitorBuilder.Visitors;

namespace CompositeVisitorBuilder.Composites
{
    abstract class AbstractCompanyEntity
    {
        public string Name { get; private set; }

        public abstract double? Utilization { get; }

        protected AbstractCompanyEntity(string name)
        {
            Name = name;
        }

        public abstract void AcceptVisitor(AbstractCompanyVisitor visitor);
    }
}
