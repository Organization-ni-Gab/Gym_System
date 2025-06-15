
public class SignupService : ISignupService
{
    private readonly ISignupRepository _signupRepository;

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
}

