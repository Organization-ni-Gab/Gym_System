
    public interface ISignupRepository 
    {
        Task<List<Signup>> GetAllSignupsAsync();
        Task<int> AddSignupAsync(Signup signup);
    Task<bool> DeleteMultipleSignUpAsync(string deleteCustomerIDs);
    }

