// See https://aka.ms/new-console-template for more information
var firstshop = new Coffee_Shop(1, "test", "spr", "MA");

var cs = "Host=localhost;Username=postgres;Password=Oquendo01!@#;Database=Jaunty Coffee Co";
using var con = new NpgsqlConnection(cs);

var sql = "SELECT * from Coffee_Shop";
var output= con.Query<Coffee_Shop>(sql).SingleOrDefault();
Console.WriteLine($"CoffeeShops: {output}");



