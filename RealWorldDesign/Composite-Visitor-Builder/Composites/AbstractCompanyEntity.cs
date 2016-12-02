using System.Collections.Generic;
using System.Linq;
using CompositeVisitorBuilder.Visitors;

namespace CompositeVisitorBuilder.Composites
{
    abstract class AbstractCompanyEntity
    {
        // Map of entity name to full entity
        protected readonly IDictionary<string, AbstractCompanyEntity> _children = new Dictionary<string, AbstractCompanyEntity>();

        public string Name { get; private set; }

        public abstract double Utilization { get; }

        protected AbstractCompanyEntity(string name)
        {
            Name = name;
        }

        public abstract void AcceptVisitor(AbstractCompanyVisitor visitor);
    }
}
