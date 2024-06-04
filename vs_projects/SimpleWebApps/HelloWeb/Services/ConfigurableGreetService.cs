namespace HelloWeb.Services
{
    public class ConfigurableGreetService : IGreetService
    {
        IConfiguration config;
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        private TimeName time;

        public bool TimedGreet { get; set; }

        public ConfigurableGreetService(IConfiguration config,TimeName time)
        {
            this.config = config;
            Prefix = config["greeter:Prefix"];
            Suffix = config["greeter:Suffix"];
            this.time = time;
            var x = config["greeter:TimedGreet"];
            if(!string.IsNullOrEmpty(x) )
                TimedGreet = bool.Parse(x);
        }

        public string Greet(string name)
        {
            if (TimedGreet)
                Prefix = $"Good {time.Message}";

            return $"{Prefix} {name}, {Suffix}";
        }
    }
}
