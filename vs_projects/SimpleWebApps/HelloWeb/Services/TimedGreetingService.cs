namespace HelloWeb.Services
{
    public class TimedGreetingService: IGreetService
    {
        TimeName timeName;

        //dependency injection
        public TimedGreetingService(TimeName timeName)
        {
            this.timeName = timeName;
        }

        public string Greet(string name)
        {
            return $"Good {timeName.Message} {name}, Welcome to our Service";
        }
    }
}
