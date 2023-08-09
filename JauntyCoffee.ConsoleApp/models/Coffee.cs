public class Coffee
{
    public int Coffee_ID {get; set;}

    public int Shop_ID {get; set;}
    public int Supplier_ID {get; set;}
    public string Coffee_Name {get; set;}
    public decimal Price_Per_Pound {get; set;}
    


    public string ToFullString()
    {
        return String.Format("({0}, {1}, {2}, {3}, {4})", Coffee_ID, Shop_ID, Supplier_ID, Coffee_Name, Price_Per_Pound);
    }

     public override string ToString() 
     {
         
         return String.Format("('{0}', '{1}', '{2}', '{3}')", Shop_ID, Supplier_ID, Coffee_Name, Price_Per_Pound);
     }
     

}