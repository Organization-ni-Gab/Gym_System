
public interface ISignUpService
{
    Task<IEnumerable<SignUp>> getAllSignUpAsyn();
    Task<bool> InsertSignUpAsync(SignUp signUp);
    Task<SignUp> GetIdSignUpAsync(int id);
    Task<bool> UpdateSignUpAsync(SignUp signUp);
    Task<bool> DeleteSignUpAsync(int id);
}

