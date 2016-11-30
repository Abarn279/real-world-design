using System;
using System.Linq;
using Composites;
using Visitors;

namespace Builders
{
    class CompanyBuilder : ICompanyBuilder
    {
        private readonly AbstractCompanyEntity _company;

        public CompanyBuilder(string name)
        {
            _company = new Group(name);
        }

        public ICompanyBuilder BuildEmployee(string name, double salary, string title, string parentGroup)
        {
            var companySearch = new CompanyGroupSearch()
            {
                Query = parentGroup
            };

            _company.AcceptVisitor(companySearch);

            var results = companySearch.GetResults();

            if (!results.Any())
                Console.WriteLine("No group contains the search term \"" + parentGroup + "\".");

            else if (results.Count > 1)
                Console.WriteLine("More than one group contains the search term \"" + parentGroup +
                                  "\". Please refine your search.");

            else
                results[0].AddChild(new Employee(name, salary, title));

            return this;
        }

        public ICompanyBuilder BuildGroup(string name, string parentGroup)
        {
            var companySearch = new CompanyGroupSearch()
            {
                Query = parentGroup
            };

            _company.AcceptVisitor(companySearch);

            var results = companySearch.GetResults();

            if (!results.Any())
                Console.WriteLine("No group contains the search term \"" + parentGroup + "\".");

            else if (results.Count > 1)
                Console.WriteLine("More than one group contains the search term \"" + parentGroup +
                                  "\". Please refine your search.");

            else
                results[0].AddChild(new Group(name));

            return this;
        }

        public AbstractCompanyEntity GetResult()
        {
            return _company;
        }
    }
}
