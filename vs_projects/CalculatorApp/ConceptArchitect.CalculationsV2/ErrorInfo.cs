namespace ConceptArchitect.CalculationsV2
{
    public class ErrorInfo
    {
        string message;
        public ErrorInfo(string message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            return $"Error:{message}";
        }
    }
}