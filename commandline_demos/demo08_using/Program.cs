using Furnitures; //get names from this namespace
using Data; //get names from this namespace
using Table = Furnitures.Table; 
using DTable = Data.Table; //We use Data.Table as DTable

class Program
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Furniture Shop");
        var c=new Chair();
        var bed=new Bed();
        var sofa=new Sofa();

        var table1=new Table(); //Furnitures.Table because of Line 3

        System.Console.WriteLine($"The price of {c} is {c.Price}");
        System.Console.WriteLine($"The price of {bed} is {bed.Price}");
        System.Console.WriteLine($"The price of {sofa} is {sofa.Price}");
        System.Console.WriteLine($"The price of {table1} is {table1.Price}");

        var l=new List();
        //var table2=new Data.Table();  //qualified name. NO conflict
        var table2= new DTable(); //Data.Table because of Line 4
        var s=new Set();
        var tree=new Tree();

        for(int i=0; i<5;i++)
        {
            l.Add();
            table2.Add();
            s.Add();
            tree.Add();
            System.Console.WriteLine();
        }

       
        
    }
}