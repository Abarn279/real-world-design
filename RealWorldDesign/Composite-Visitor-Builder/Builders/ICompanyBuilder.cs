namespace Builders
{
    interface ICompanyBuilder
    {
        void BuildEmployee(string name, double salary, string title, string parentGroup);

        void BuildGroup(string name, string parentGroup);
    }
}
