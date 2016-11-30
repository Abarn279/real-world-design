using Composites;

namespace Builders
{
    interface ICompanyBuilder
    {
        ICompanyBuilder BuildEmployee(string name, double salary, string title, string parentGroup);

        ICompanyBuilder BuildGroup(string name, string parentGroup);

        AbstractCompanyEntity GetResult();
    }
}
