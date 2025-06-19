
public class SignupService : ISignupService
{
    private readonly ISignupRepository _signupRepository;

    public async Task<Signup> getIdSignUpAsync(int id)
    {
        return await _signupRepository.getIdSignUpAsync(id);
    }
    public SignupService(ISignupRepository signupRepository)
    {
        _signupRepository = signupRepository;
    }

    public async Task<List<Signup>> GetAllSignupsAsync()
    {
        return await _signupRepository.GetAllSignupsAsync();
    }

    public async Task<int> AddSignupAsync(Signup signup)
    {
        return await _signupRepository.AddSignupAsync(signup);
    }

    public async Task<bool> DeleteMultipleSignUpAsync(string deleteCustomerIDs)
    {
        return await _signupRepository.DeleteMultipleSignUpAsync(deleteCustomerIDs);
    }
    public async Task<bool> AddSignupAndWalkinAsync(Signup signup)
    {
        return await _signupRepository.AddSignupAndWalkinAsync(signup);
    }

    public async Task<bool> updateSignUp(Signup signup)
    {
        return await _signupRepository.updateSignUp(signup);
    }
}

