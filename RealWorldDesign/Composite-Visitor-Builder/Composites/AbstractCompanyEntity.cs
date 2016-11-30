using System.Collections.Generic;
using System.Linq;
using Visitors;

namespace Composites
{
    abstract class AbstractCompanyEntity
    {
        // Map of entity name to full entity
        protected readonly IDictionary<string, AbstractCompanyEntity> _children = new Dictionary<string, AbstractCompanyEntity>();

        public string Name { get; private set; }

        protected AbstractCompanyEntity(string name)
        {
            Name = name;
        }

        public IEnumerable<AbstractCompanyEntity> GetChildren()
        {
            return _children.Keys.Select(x => _children[x]);
        }

        public abstract void AcceptVisitor(AbstractCompanyVisitor visitor);
    }
}
