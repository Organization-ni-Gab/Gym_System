
public interface ISignupService
{
    Task<List<Signup>> GetAllSignupsAsync();
    Task<int> AddSignupAsync(Signup signup);
    Task<bool> DeleteMultipleSignUpAsync(string deleteCustomerIDs);
    Task<bool> AddSignupAndWalkinAsync(Signup signup);

    Task<Signup> getIdSignUpAsync(int id);
    Task<bool> updateSignUp(Signup signup);
}

