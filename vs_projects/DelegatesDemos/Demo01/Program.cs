namespace Demo01
{
    internal class Program
    {
        delegate void GreeterDelegate(string name);
        static void Main(string[] args)
        {
            Greet("Vivek");

            //GreeterDelegate gd = new GreeterDelegate(Greet);

            GreeterDelegate gd = Greet; //autoboxed



            gd.Invoke("Ecolab"); //invokes Greet function

            gd("Ecolab Trainees 2024"); //implicit invoke
            
        }

        static void Greet(string name)
        {
            Console.WriteLine($"Hello {name}, Welcome to Delegates");
        }
    }
}
