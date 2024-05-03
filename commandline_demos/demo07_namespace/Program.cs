class Program
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Furniture Shop");
        Furnitures.Chair c=new Furnitures.Chair();
        Furnitures.Bed bed=new Furnitures.Bed();
        Furnitures.Sofa sofa=new Furnitures.Sofa();
        Furnitures.Table table1=new Furnitures.Table();

        System.Console.WriteLine($"The price of {c} is {c.Price}");
        System.Console.WriteLine($"The price of {bed} is {bed.Price}");
        System.Console.WriteLine($"The price of {sofa} is {sofa.Price}");
        System.Console.WriteLine($"The price of {table1} is {table1.Price}");

        Data.List l=new Data.List();
        Data.Table table2=new Data.Table();
        Data.Set s=new Data.Set();

        for(int i=0; i<5;i++)
        {
            l.Add();
            table2.Add();
            s.Add();
            System.Console.WriteLine();
        }

       
        
    }
}