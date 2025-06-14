using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
public class MemberRepository : IMemberRepository
{
    private readonly IConfiguration _configuration;
    private string _connectionString;
    public MemberRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("GymSystemConnection"); 
    }

    public async Task<IEnumerable<Member>> getAllMemberAsyn()
    {
        using(var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<Member>("sp_getAllMember", commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<bool> InsertMemberAsync(Member member)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var result = await connection.ExecuteAsync(
             "sp_insertMember",
             new
             {
                 @customerId = member.CustomerId,
                 @firstName = member.FirstName,
                 @middleName = member.MiddleName,
                 @lastName = member.LastName,
                 @contactNumber = member.ContactNumber,
                 @gender = member.Gender,
                 @PlanId = member.PlanId,
                 @JoinDate = member.JoinDate,
                 @ExpiryDate = member.ExpiryDate,
                 @isMember = member.isMember

             },
             commandType: CommandType.StoredProcedure
             );
            return result > 0;
        }

    }
    public async Task<Member> GetIdMemberAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<Member>(
            "sp_getIdMember",
            new
            {
                id = id,

            },
            commandType: CommandType.StoredProcedure
            );

        }
    }
    public async Task<bool> UpdateMemberAsync(Member member)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync(
            "sp_updateMember",
            new
            {
                @customerId = member.CustomerId,
                @firstName = member.FirstName,
                @middleName = member.MiddleName,
                @lastName = member.LastName,
                @contactNumber = member.ContactNumber,
                @gender = member.Gender,
                @PlanId = member.PlanId,
                @JoinDate = member.JoinDate,
                @ExpiryDate = member.ExpiryDate,
                @isMember = member.isMember


            },
            commandType: CommandType.StoredProcedure);


            return result > 0;
        }

    }
    public async Task<bool> DeleteMemberAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync(
            "sp_deleteMember",
            new
            {
                id = id
            },
            commandType: CommandType.StoredProcedure);


            return result > 0;
        }

    }

}

