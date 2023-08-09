public class Coffee_Shop
{
    public int Shop_ID {get; set;}
    public string Shop_Name {get; set;}
    public string City {get; set;}
    public string State {get; set;}

    public Coffee_Shop(){

    }
    public Coffee_Shop(int shop_id, string shop_name, string city, string state)
    {
        Shop_ID = shop_id;
        Shop_Name = shop_name;
        City = city;
        State = state;

    }
    public string ToFullString()
    {
        return String.Format("({0}, {1}, {2}, {3})", Shop_ID, Shop_Name, City, State);
    }

     public override string ToString() 
     {
         
         return String.Format("('{0}', '{1}', '{2}')", Shop_Name, City, State);
     }
     

}