public static class FakeData
{
    public static List<Coffee_Shop> Shops = new List<Coffee_Shop>();
    public static List<Supplier> Suppliers = new List<Supplier>();
    public static Bogus.Faker<Employee> Employees = new Bogus.Faker<Employee>(locale: "en_US");

    public static Bogus.Faker<Coffee> Coffees = new Bogus.Faker<Coffee>(locale: "en_US");

    public static void Init(int count)
    {
        var shopID = 1;
        var CoffeeShopFaker = new Bogus.Faker<Coffee_Shop>(locale: "en_US")
        .RuleFor(c => c.Shop_ID, _ => shopID++)
        .RuleFor(c => c.Shop_Name, f => f.Company.CompanyName())
        .RuleFor(c => c.City, f => f.Address.City())
        .RuleFor(c => c.State, f => f.Address.StateAbbr());
        var CoffeeShops = CoffeeShopFaker.Generate(count);
        FakeData.Shops.AddRange(CoffeeShops);
        
        Employees.RuleFor(e => e.Employee_ID, f => f.Random.UShort())
        .RuleFor(e => e.First_Name, f => SecurityElement.Escape(f.Person.FirstName))
        .RuleFor(e => e.Last_Name, f =>SecurityElement.Escape(f.Person.LastName))
        .RuleFor(e => e.Date, f =>
        {
            var date = f.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now);
            return new DateOnly(date.Year, date.Month, date.Day);
        })
        .RuleFor(e => e.Job_Title, f => { 
            var job = f.Name.JobTitle();
            return job?.Substring(0, Math.Min(job.Length, 30));
        });
        
        var supplierID = 1;
        var SupplierFaker = new Bogus.Faker<Supplier>(locale: "en_US")
        .RuleFor(s => s.Supplier_ID, _ => supplierID++)
        .RuleFor(s => s.Company_Name, f => f.Company.CompanyName() + " " + f.Company.CompanySuffix() )
        .RuleFor(s => s.Country, f => f.Address.Country() )
        .RuleFor(s => s.Sales_Contact_Name, f => {
            var contract = String.Format("{0} Contract", f.Hacker.Verb());
            return contract;

        } )
        .RuleFor(s => s.Email, f => f.Internet.Email() );
        Suppliers.AddRange(SupplierFaker.Generate(count));

        
        Coffees.RuleFor(c => c.Coffee_ID, f => f.Random.UShort())
        .RuleFor(c => c.Coffee_Name, f => String.Format("{0} Coffee",f.Hacker.Noun() ))
        .RuleFor(c => c.Price_Per_Pound, f => Math.Round(f.Random.Decimal(1,35), 2));
    }



}