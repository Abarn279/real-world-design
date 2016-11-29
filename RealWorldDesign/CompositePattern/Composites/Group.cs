using CompositePattern.Visitors;

namespace CompositePattern.Composites
{
    class Group : AbstractCompanyEntity
    {
        public Group(string name) : base(name) { }

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
