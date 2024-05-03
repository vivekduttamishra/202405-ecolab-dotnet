class Program
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Furniture Shop");
        Chair c=new Chair();
        System.Console.WriteLine($"The price of {c} is {c.Price}");
    }
}