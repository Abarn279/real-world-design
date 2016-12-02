using CompositeVisitorBuilder.Composites;

namespace CompositeVisitorBuilder.Visitors
{
    static class CompanyPrinter
    {
        private static readonly CompanyPrinterVisitor Visitor = new CompanyPrinterVisitor();

        public static void Print(AbstractCompanyEntity company)
        {
            company.AcceptVisitor(Visitor);
        }
    }
}
