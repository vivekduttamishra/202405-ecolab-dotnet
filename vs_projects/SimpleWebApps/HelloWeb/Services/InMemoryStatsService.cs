
namespace HelloWeb.Services
{
    public class InMemoryStatsService : IStatsService
    {
        

        Dictionary<string, int> stats=new Dictionary<string, int>();

        public async Task AddUrl(string url)
        {
            await Task.Yield(); //a small sleep in favour of other task
            url =url.ToLower();
            if (stats.ContainsKey(url))
            {
                stats[url]++;
            }
            else
            {
                stats[url] = 1;
            }
        }

        public async Task<Dictionary<string, int>> GetStats()
        {
            await Task.CompletedTask;
            return stats;
        }
    }
}
