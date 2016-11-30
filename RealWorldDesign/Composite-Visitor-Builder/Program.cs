using System;
using Composites;
using Visitors;

class Program
{
    static void Main(string[] args)
    {
        // Create Company and leadership
        Group appleCompany = new Group("Apple");
        Employee ceo = new Employee("Tim Cook", 10200000, "CEO");
        Group vicePresidents = new Group("Vice Presidents");
        Employee vpEng = new Employee("Craig Federighi", 1000000, "Vice President Of Engineering");
        Employee vpDes = new Employee("Jonathan Ive", 1000000, "Vice President of Design");
        Employee vpMark = new Employee("Phillip Schiller", 1000000, "Vice President of Marketing");

        // Add Leadership as Child of the company
        appleCompany.AddChild(ceo);
        appleCompany.AddChild(vicePresidents);

        // Add the specific VPs as children of the VP group
        vicePresidents.AddChild(vpEng);
        vicePresidents.AddChild(vpDes);
        vicePresidents.AddChild(vpMark);

        // Create specific product groups
        Group iPadGroup = new Group("iPad");
        Group iWatchGroup = new Group("Smartwatch");
        Group iPhoneGroup = new Group("iPhone");

        // Create a designer employee for one of the groups
        Employee iPadDesigner = new Employee("Phillip", 150000, "iPad Designer");

        // Add the product groups as a subsidiery of the VPs
        vicePresidents.AddChild(iPadGroup);
        vicePresidents.AddChild(iWatchGroup);
        vicePresidents.AddChild(iPhoneGroup);

        // Add the iPad designer as a member of the iphone group
        iPhoneGroup.AddChild(iPadDesigner);

        // Search whole company for any group or employee with an "A"
        CompanySearch cs = new CompanySearch
        {
            Query = "a"
        };

        appleCompany.AcceptVisitor(cs);

        foreach (var x in cs.GetResults())
        {
            Console.WriteLine(x.Name);
        }
        return;
    }
}