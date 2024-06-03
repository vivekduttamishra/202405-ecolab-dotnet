namespace HelloWeb.Services
{
    public class SimpleGreetService : IGreetService
    {
        static int lastId = 0;
        public int Id { get; set; }
        public SimpleGreetService()
        {
            Id = ++lastId;
            Console.WriteLine($"SimpleGreetService #{Id} created");
        }
        public string Greet(string name)
        {
            Console.WriteLine($"SimpleGreetService #{Id} greeting {name}");
            return $"Hello {name}, Welcome to ASP.NET Core Service";
        }
    }
}
