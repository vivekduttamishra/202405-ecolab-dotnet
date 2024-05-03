class Program
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Furniture Shop");
        Chair c=new Chair();
        List l=new List();
        System.Console.WriteLine($"The price of {c} is {c.Price}");
        for(int i=0; i<5;i++)
        {
            l.Add();
        }

        Table table=new Table();
        System.Console.WriteLine($"The price of {table} is {table.Price}");
        
    }
}