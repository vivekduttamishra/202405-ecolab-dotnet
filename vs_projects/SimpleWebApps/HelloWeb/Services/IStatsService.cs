namespace HelloWeb.Services
{
    public interface IStatsService
    {
        Task AddUrl(string url);
        Task<Dictionary<string, int>> GetStats();
    }
}
