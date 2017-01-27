using System;
using CompositeVisitorBuilder.Visitors;

namespace CompositeVisitorBuilder.Composites
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

        public override double? Utilization { get; }

        public string Title { get; private set; }

        public Employee(string name, double salary, string title) : base(name)
        {
            Salary = salary;
            Title = title;
            Utilization = Math.Round(new Random().NextDouble(), 2);
        }

        public override void AcceptVisitor(AbstractCompanyVisitor visitor)
        {
            visitor.VisitEmployee(this);
        }
    }
}
