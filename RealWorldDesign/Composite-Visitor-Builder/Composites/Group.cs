using System.Collections.Generic;
using System.Linq;
using CompositeVisitorBuilder.Visitors;

namespace CompositeVisitorBuilder.Composites
{
    class Group : AbstractCompanyEntity
    {
        public Group(string name) : base(name) { }

        public override double Utilization => _children.Any()
            ? GetChildren()
                .Where(x => x.Utilization > 0)
                .Average(x => x.Utilization)
            : -1;

        public IEnumerable<AbstractCompanyEntity> GetChildren()
        {
            return _children.Keys.Select(x => _children[x]);
        }

        public void AddChild(AbstractCompanyEntity ent)
        {
            _children[ent.Name] = ent;
        }

        public AbstractCompanyEntity GetDirectChildByName(string name)
        {
            return _children[name];
        }

        public override void AcceptVisitor(AbstractCompanyVisitor visitor)
        {
            visitor.VisitGroup(this);
        }
    }
}
