public class Supplier
{
    public int Supplier_ID {get; set;}
    public string Company_Name {get; set;}
    public string Country {get; set;}
    public string Sales_Contact_Name {get; set;}

    public string Email {get; set;}

    


  
    public string ToFullString()
    {
        return String.Format("({0}, {1}, {2}, {3}, {4},)", Supplier_ID, Company_Name, Country, Sales_Contact_Name, Email);
    }

    public override string ToString() 
    {
         
         return String.Format("('{0}', '{1}', '{2}', '{3}')", Company_Name, Country, Sales_Contact_Name, Email);
    }
}