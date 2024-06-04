namespace HelloWeb.Services
{
    public class TimeName
    {
        public string Message
        {
            get
            {
                var hour = DateTime.Now.Hour;
                if (hour < 12)
                    return "Morning";
                else if (hour < 18)
                    return "Afternoon";
                else
                    return "Evening";
            }
        }

       
    }
}
