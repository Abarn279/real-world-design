using System.Collections;
using System.Collections.Generic;
using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    class CompanySearch
    {
        private readonly Group _company;
        private readonly CompanySearchVisitor _visitor = new CompanySearchVisitor();

        public CompanySearch(Group company)
        {
            _company = company;
        }

        public IList<AbstractCompanyEntity> Search(string query)
        {
            _visitor.Query = query;
            _company.AcceptVisitor(_visitor);
            return _visitor.GetResults();
        }
    }
}
