using System;
using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    class CompanyPrinterVisitor : AbstractCompanyVisitor
    {
        private string _indentation = "";

        public override void VisitEmployee(Employee employee)
        {
            Console.WriteLine(_indentation + employee.Title + ": " + employee.Name);
        }

        public override void VisitGroup(Group group)
        {
            Console.WriteLine(_indentation + "Group: " + group.Name);

            var indented = false;
            var children = group.GetChildren();
            foreach (var child in children)
            {
                if (!indented)
                {
                    _indentation += "\t";
                    indented = true;
                }

                child.AcceptVisitor(this);
            }

            if (indented) _indentation = _indentation.Remove(_indentation.Length - 1);
        }
    }
}
