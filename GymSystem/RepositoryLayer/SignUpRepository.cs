using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
public class SignUpRepository: ISignUpRepository
{
    private readonly IConfiguration _configuration;
    private string _connectionString;
    public SignUpRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("GymSystemConnection");
    }

    public async Task<IEnumerable<SignUp>> getAllSignUpAsyn()
    {
        using(var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<SignUp>("sp_getAllSignUp", commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<bool> InsertSignUpAsync(SignUp signUp)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.ExecuteAsync(
             "sp_insertSignUp",
             new
             {
                 @customerId = signUp.CustomerId,
                 @firstName = signUp.FirstName,
                 @middleName = signUp.MiddleName,
                 @lastName = signUp.LastName,
                 @contactNumber = signUp.ContactNumber,
                 @gender =  signUp.Gender,
                 @PlanId = signUp.PlanId,
                 @JoinDate = signUp.JoinDate,
                 @ExpiryDate = signUp.ExpiryDate,
                 @isMember =  signUp.isMember

             },
             commandType: CommandType.StoredProcedure
             );
            return result > 0;
        }

    }
    public async Task<SignUp> GetIdSignUpAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<SignUp>(
            "sp_getIdSignUp",
            new
            {
                id = id,

            },
            commandType: CommandType.StoredProcedure
            );

        }
    }
    public async Task<bool> UpdateSignUpAsync(SignUp signUp)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync(
            "sp_updateSignUp",
            new
            {
                @customerId = signUp.CustomerId,
                @firstName = signUp.FirstName,
                @middleName = signUp.MiddleName,
                @lastName = signUp.LastName,
                @contactNumber = signUp.ContactNumber,
                @gender = signUp.Gender,
                @PlanId = signUp.PlanId,
                @JoinDate = signUp.JoinDate,
                @ExpiryDate = signUp.ExpiryDate,
                @isMember = signUp.isMember


            },
            commandType: CommandType.StoredProcedure);


            return result > 0;
        }

    }
    public async Task<bool> DeleteSignUpAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync(
            "sp_deleteSignUp",
            new
            {
                id = id
            },
            commandType: CommandType.StoredProcedure);


            return result > 0;
        }

    }

}

