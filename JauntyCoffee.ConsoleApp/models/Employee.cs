public class Employee
{
    public int Employee_ID {get; set;}
    public string First_Name {get; set;}
    public string Last_Name {get; set;}
    public DateOnly Date {get; set;}

    public String Job_Title {get; set;}

    public int Shop_ID {get; set;}


  
    public string ToFullString()
    {
        return String.Format("({0}, {1}, {2}, {3}, {4}, {5})", Employee_ID, First_Name, Last_Name,  Date.ToString("yyyy/MM/dd"), Job_Title, Shop_ID);
    }

    public override string ToString() 
    {
         
         return String.Format("('{0}', '{1}', '{2}', '{3}', '{4}')", First_Name, Last_Name, Date.ToString("yyyy/MM/dd"), Job_Title, Shop_ID);
    }
}