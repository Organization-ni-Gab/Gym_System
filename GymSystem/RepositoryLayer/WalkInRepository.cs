using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
public class WalkInRepository : IWalkInRepository
{
    private readonly IConfiguration _configuration;
    private string _connectionString;
    public WalkInRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("GymSystemConnection");
    }

    public async Task<IEnumerable<WalkIn>> getAllWalkInAsyn()
    {
        using(var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<WalkIn>("sp_getAllWalkIn", commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<bool> InsertWalkInAsync(WalkIn WalkIn)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.ExecuteAsync(
             "sp_insertWalkIn",
             new
             {
                 @customerId = WalkIn.CustomerId,
                 @firstName = WalkIn.FirstName,
                 @middleName = WalkIn.MiddleName,
                 @lastName = WalkIn.LastName,
                 @contactNumber = WalkIn.ContactNumber,
                 @gender = WalkIn.Gender,
                 @PlanId = WalkIn.PlanId,
                 @JoinDate = WalkIn.JoinDate,
                 @ExpiryDate = WalkIn.ExpiryDate,
                 @isMember = WalkIn.isMember

             },
             commandType: CommandType.StoredProcedure
             );
            return result > 0;
        }

    }
    public async Task<WalkIn> GetIdWalkInAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<WalkIn>(
            "sp_getIdWalkIn",
            new
            {
                id = id,

            },
            commandType: CommandType.StoredProcedure
            );

        }
    }
    public async Task<bool> UpdateWalkInAsync(WalkIn WalkIn)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync(
            "sp_updateWalkIn",
            new
            {
                @customerId = WalkIn.CustomerId,
                @firstName = WalkIn.FirstName,
                @middleName = WalkIn.MiddleName,
                @lastName = WalkIn.LastName,
                @contactNumber = WalkIn.ContactNumber,
                @gender = WalkIn.Gender,
                @PlanId = WalkIn.PlanId,
                @JoinDate = WalkIn.JoinDate,
                @ExpiryDate = WalkIn.ExpiryDate,
                @isWalkIn = WalkIn.isMember


            },
            commandType: CommandType.StoredProcedure);


            return result > 0;
        }

    }
    public async Task<bool> DeleteWalkInAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync(
            "sp_deleteWalkIn",
            new
            {
                id = id
            },
            commandType: CommandType.StoredProcedure);


            return result > 0;
        }

    }

}

