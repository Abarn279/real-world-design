using System;
using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Builders
{
    class LoggingCompanyBuilder : ICompanyBuilder
    {
        private readonly ICompanyBuilder _builder;

        public LoggingCompanyBuilder(ICompanyBuilder builder)
        {
            _builder = builder;
        }

        public ICompanyBuilder BuildEmployee(string name, double salary, string title, string parentGroup)
        {
            Console.WriteLine("Building employee " + name + " with a parent group search term of " + parentGroup);
            _builder.BuildEmployee(name, salary, title, parentGroup);
            return this;
        }

        public ICompanyBuilder BuildGroup(string name, string parentGroup)
        {
            Console.WriteLine("Building group " + name + " with a parent group search term of " + parentGroup);
            _builder.BuildGroup(name, parentGroup);
            return this;
        }

        public AbstractCompanyEntity GetResult()
        {
            Console.WriteLine("Getting final result");
            return _builder.GetResult();
        }
    }
}
