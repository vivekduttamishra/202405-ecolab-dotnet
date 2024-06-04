namespace HelloWeb.Services
{

    public class GreetConfiguration
    {
        public string Prefix { get; set; } = "Hello"; //default value
        public string Suffix { get; set; } = "Welcome to our Service"; 

        public bool TimedPrefix { get; set; } = false; 
    }

    public class AdvancedConfigurableGreetService : IGreetService
    {
        IConfiguration config;

        TimeName time;

        public bool TimedGreet { get; set; }


        GreetConfiguration greet= new GreetConfiguration();
        public AdvancedConfigurableGreetService(IConfiguration config,TimeName time)
        {
            this.config = config;
            this.time = time;
            
            config.Bind("greeter", greet);
        }

        public string Prefix
        {
            get
            {
                if (greet.TimedPrefix)
                    return $"Good {time.Message}";
                else
                    return greet.Prefix;
            }
        }

        public string Greet(string name)
        {
            return $"{Prefix} {name}, {greet.Suffix}";
        }
    }
}
