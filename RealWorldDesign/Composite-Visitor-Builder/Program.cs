using System;
using CompositeVisitorBuilder.Builders;
using CompositeVisitorBuilder.Composites;
using CompositeVisitorBuilder.Visitors;

namespace CompositeVisitorBuilder
{
    class Program
    {
        static void Main()
        {
            // TODO: Decorators: Manual vs interception

            // Manual Company
            var apple1 = GetCompanyManually();
            ;
            TestVisitors(apple1);

            var apple2 = GetCompanyFromBuilder();
            ;
            TestVisitors(apple2);

            var apple3 = GetCompanyFromDecoratedBuilder();
            ;
            TestVisitors(apple3);

            return;
        }

        private static void TestVisitors(AbstractCompanyEntity company)
        {
            // Test Company Search
            // Search whole company for any group or employee with an "a" in its name
            CompanySearch client = new CompanySearch(company);
            var results = client.Search("a");

            foreach (var x in results)
            {
                Console.WriteLine(x.Name);
            }

            Console.WriteLine();

            // Test Printer
            CompanyPrinter.Print(company);
            
            Console.WriteLine();
        }

        private static AbstractCompanyEntity GetCompanyManually()
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

            //Create specific product groups
            Group iPadGroup = new Group("iPad");
            Group iWatchGroup = new Group("iWatch");
            Group iPhoneGroup = new Group("iPhone");

            //Create a designer employee for one of the groups

            Employee iPadDesigner = new Employee("Phillip", 150000, "iPad Designer");
            Employee iWatchDesigner = new Employee("Todd Jones", 200000, "iWatch Designer");

            //Add the product groups as a subsidiery of the VPs
            vicePresidents.AddChild(iPadGroup);
            vicePresidents.AddChild(iWatchGroup);
            vicePresidents.AddChild(iPhoneGroup);

            //Add the iPad designer as a member of the iphone group
            iPadGroup.AddChild(iPadDesigner);
            iWatchGroup.AddChild(iWatchDesigner);

            return appleCompany;
        }

        private static AbstractCompanyEntity GetCompanyFromBuilder()
        {
            // Construct company. Company builder allows you to search for the parent of the new
            // entity and will place it automatically.
            var appleCompany = new CompanyBuilder("Apple")
                .BuildEmployee("Tim Cook", 10200000, "CEO", "appl")
                .BuildGroup("Vice Presidents", "ppl")
                .BuildEmployee("Craig Federighi", 1000000, "Vice President of Engineering", "Vice")
                .BuildEmployee("Jonathan Ive", 1000000, "Vice President of Design", " Presidents")
                .BuildEmployee("Phillip Schiller", 1000000, "Vice President of Marketing", "Vice Pres")
                .BuildGroup("iPad", "Vice Presidents")
                .BuildGroup("iWatch", "Vice Presidents")
                .BuildGroup("iPhone", "Vice Presidents")
                .BuildEmployee("Phillip", 150000, "iPad Designer", "ipad")
                .BuildEmployee("Todd Jones", 200000, "iWatch Designer", "IWATCH")
                .GetResult();

            return appleCompany;
        }

        private static AbstractCompanyEntity GetCompanyFromDecoratedBuilder()
        {
            var builder = new CompanyBuilder("Apple");
            var appleCompany = new LoggingCompanyBuilder(builder)
                .BuildEmployee("Tim Cook", 10200000, "CEO", "appl")
                .BuildGroup("Vice Presidents", "ppl")
                .BuildEmployee("Craig Federighi", 1000000, "Vice President of Engineering", "Vice")
                .BuildEmployee("Jonathan Ive", 1000000, "Vice President of Design", " Presidents")
                .BuildEmployee("Phillip Schiller", 1000000, "Vice President of Marketing", "Vice Pres")
                .BuildGroup("iPad", "Vice Presidents")
                .BuildGroup("iWatch", "Vice Presidents")
                .BuildGroup("iPhone", "Vice Presidents")
                .BuildEmployee("Phillip", 150000, "iPad Designer", "ipad")
                .BuildEmployee("Todd Jones", 200000, "iWatch Designer", "IWATCH")
                .GetResult();

            return appleCompany;
        }
    }
}