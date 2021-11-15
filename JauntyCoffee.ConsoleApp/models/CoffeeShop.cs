public class Coffee_Shop
{
    public int ShopID {get; set;}
    public string ShopName {get; set;}
    public string City {get; set;}
    public string State {get; set;}

    public Coffee_Shop(int shop_id, string shop_name, string city, string state)
    {
        ShopID = shop_id;
        ShopName = shop_name;
        City = city;
        State = state;

    }

     public override string ToString() 
     {
         return String.Format("CoffeeShop({0}, {1}, {2}, {3})", ShopID, ShopName, City, State);
     }
     

}