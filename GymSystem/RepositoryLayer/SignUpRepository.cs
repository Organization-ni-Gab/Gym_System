using System.Data;
using Dapper;
using Microsoft.AspNetCore.Connections.Features;
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
            var result = await connection.QueryAsync<Signup>("sp_GetAllSignup", commandType: CommandType.StoredProcedure);
            return result.ToList();
            }
       
        }

    public async Task<bool> DeleteMultipleSignUpAsync(string deleteCustomerIDs)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.ExecuteAsync("deleteMultipleSignUp",
                new
                {
                    param = deleteCustomerIDs
                }, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
            
    }

        public async Task<int> AddSignupAsync(Signup signup)
        {
                using(var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
            //var parameters = new
            //{
            //    signup.FirstName,
            //    signup.MiddleName,
            //    signup.LastName,
            //    signup.ContactNumber,
            //    signup.Gender,
            //    signup.isMember
            //};


            return await connection.ExecuteAsync("sp_AddSignup",
                new
                {
                    fname = signup.FirstName,
                    mname = signup.MiddleName,
                    lname = signup.LastName,
                    contact = signup.ContactNumber,
                    gender = signup.Gender,
                    isMember = signup.isMember

                }, commandType: CommandType.StoredProcedure);

                }

        }

    }

