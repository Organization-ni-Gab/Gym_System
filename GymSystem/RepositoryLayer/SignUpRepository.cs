using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

public class SignupRepository : ISignupRepository
    {
        public readonly IConfiguration _configuration;
        public string _connectionString;
    public SignupRepository(IConfiguration configuration)
        {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("GymSystemConnection");
        }

       public async Task<List<Signup>> GetAllSignupsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
            var result = await connection.QueryAsync<Signup>("sp_GetAllSignups", commandType: CommandType.StoredProcedure);
            return result.ToList();
            }
       
        }

        public async Task<int> AddSignupAsync(Signup signup)
        {
                using(var connection = new SqlConnection(_connectionString))
             {
                    await connection.OpenAsync();
                var parameters = new
                {
                    signup.FirstName,
                    signup.MiddleName,
                    signup.LastName,
                    signup.ContactNumber,
                    signup.Gender
                };
            return await connection.ExecuteAsync("sp_AddSignup",parameters, commandType : CommandType.StoredProcedure);
            }

        }

    }

