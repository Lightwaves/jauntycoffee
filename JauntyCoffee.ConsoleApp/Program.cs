// See https://aka.ms/new-console-template for more information
//var firstshop = new Coffee_Shop(1, "test", "spr", "MA");
//var secondshop = new Coffee_Shop(2,"Regretti Coffee Shop", "Springfield", "MA");
//var test = new List<Coffee_Shop>();
//test.Add(firstshop);
//test.Add(secondshop);



var cs = "Host=localhost;Username=postgres;Password=Oquendo01!@#;Database=Jaunty Coffee Co"; //Use a certificate or init file instead of hardcoding connection string.
using var con = new NpgsqlConnection(cs);


FakeData.Init(10);
var coffeeshop_sql = "SELECT * from Coffee_Shop";
var coffeeshop_output= con.Query<Coffee_Shop>(coffeeshop_sql);
FakeData.Employees.RuleFor(e => e.Shop_ID, f=> {
    var randCoffeeShop = f.PickRandom<Coffee_Shop>(coffeeshop_output);
    return randCoffeeShop.Shop_ID;
});

var supplier_sql = "SELECT * from Supplier";
var supplier_output= con.Query<Supplier>(supplier_sql);

FakeData.Coffees.RuleFor(e => e.Shop_ID, f=> {
    var randCoffeeShop = f.PickRandom<Coffee_Shop>(coffeeshop_output);
    return randCoffeeShop.Shop_ID;
});

FakeData.Coffees.RuleFor(e => e.Supplier_ID, f=> {
    var randSupplier = f.PickRandom<Supplier>(supplier_output);
    return randSupplier.Supplier_ID;
});

//var result = CreateSQLInsert<Coffee_Shop>("Insert into Coffee_Shop (shop_name, city, state) Values ", FakeData.Shops);

//var EmployeesMock = FakeData.Employees.Generate(50);

//var CoffeeMock = FakeData.Coffees.Generate(50);




//File.WriteAllText(".\\sql\\Insert\\InsertEmployees.sql", CreateSQLInsert("insert into Employee (first_name, last_name, hire_date, job_title, shop_id) Values ", EmployeesMock));

//File.WriteAllText(".\\sql\\Insert\\InsertSuppliers.sql", CreateSQLInsert("insert into Supplier (company_name, country, sales_contract_name, email) Values ", FakeData.Suppliers));

//File.WriteAllText(".\\sql\\Insert\\InsertCoffees.sql", CreateSQLInsert("insert into Coffee (shop_id, supplier_id, coffee_name, price_per_pound) Values ", CoffeeMock));





//Note this will pose a SQL injection hazard, only use with trusted data you've generated.
string CreateSQLInsert<t>(String insertsql, List<t> objects)
{
    
    
    
    //var valuesToInsert = objects.Select(u => u.ToString());
    var valuesToInsert = new List<string>();
    for(int i = 0; i<objects.Count-1; i++)
    {
        //valuesToInsert.Add(objects[i].ToString() + ",");
        if(i % 2 == 0){
            valuesToInsert.Add(objects[i].ToString() + ",\n");
        }
        else{
             valuesToInsert.Add(objects[i].ToString() + ",");
        }
    }
    valuesToInsert.Add(objects[objects.Count-1].ToString());
    
    return insertsql + string.Join("", valuesToInsert);
}