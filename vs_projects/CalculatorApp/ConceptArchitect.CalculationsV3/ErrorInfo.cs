namespace ConceptArchitect.CalculationsV3
{
    public class ErrorInfo
    {
        string error;
        public ErrorInfo(string error)
        {
            this.error= error;
        }

        public override string ToString()
        {
            return $"Error: {error}";
        }
    }
}