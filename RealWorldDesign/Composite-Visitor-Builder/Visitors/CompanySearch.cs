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

        public void Search(string query)
        {
            _visitor.Query = query;
            _company.AcceptVisitor(_visitor);
            var x = _visitor.GetResults();
        }
    }
}
