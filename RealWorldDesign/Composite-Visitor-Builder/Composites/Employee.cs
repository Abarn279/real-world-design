using System;
using Visitors;

namespace Composites
{
    class Employee: AbstractCompanyEntity
    {
        private double _salary;

        public double Salary
        {
            get { return _salary; }
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _salary = value;
            }
        }

        public string Title { get; private set; }

        public Employee(string name, double salary, string title) : base(name)
        {
            Salary = salary;
            Title = title;
        }

        public override void AddChild(AbstractCompanyEntity ent)
        {
            throw new Exception("Employees cannot have subordinates!");
        }

        public override void AcceptVisitor(AbstractCompanyVisitor visitor)
        {
            visitor.VisitEmployee(this);
        }
    }
}
