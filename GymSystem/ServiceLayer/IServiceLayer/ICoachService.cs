
    public interface ICoachService
    {
        Task<IEnumerable<Coach>> GetAllCoachAsync();
        Task<bool> CreateCoachAsync(Coach coach);
        Task<Coach> GetCoachID(int id);
        Task<bool> UpdateCoachAsync(Coach coach);
        Task<bool> DeleteCoachAsync(int id);
    }

