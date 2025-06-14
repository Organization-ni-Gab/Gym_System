
public class SignUpService: ISignUpService
{
    private readonly ISignUpRepository _signUpRepository;
    public SignUpService(ISignUpRepository signUpRepository)
    {
        _signUpRepository = signUpRepository;
    }

    public async Task<IEnumerable<SignUp>> getAllSignUpAsyn()
    {
        return await  _signUpRepository.getAllSignUpAsyn();
    }
    public async Task<bool> InsertSignUpAsync(SignUp signUp)
    {
        return await _signUpRepository.InsertSignUpAsync(signUp);
    }
    public async Task<SignUp> GetIdSignUpAsync(int id)
    {
        return await _signUpRepository.GetIdSignUpAsync(id);
    }
    public async Task<bool> UpdateSignUpAsync(SignUp signUp)
    {
        return await _signUpRepository.UpdateSignUpAsync(signUp);
    }
    public async Task<bool> DeleteSignUpAsync(int id)
    {
        return await _signUpRepository.DeleteSignUpAsync(id);    
    }
}



