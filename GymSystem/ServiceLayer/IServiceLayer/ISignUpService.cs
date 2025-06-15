
    public interface ISignupService
    {
    Task<List<Signup>> GetAllSignupsAsync();
    Task<int> AddSignupAsync(Signup signup);
    }

