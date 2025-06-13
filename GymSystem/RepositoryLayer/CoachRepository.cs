using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class CoachRepository : ICoachRepository
    {
    private readonly IConfiguration _configuration;
    private string _connectionString;
    public CoachRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("GymSystemConnection");
    }

        public async Task<IEnumerable<Coach>> GetAllCoachAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Coach>("sp_GetAllCoach", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> CreateCoachAsync(Coach coach)
        {
        using (var connection = new SqlConnection(_connectionString))
            {
            await connection.OpenAsync();

            var result = await connection.ExecuteAsync("sp_InsertCoach", 
                new
                {
                    CoachName = coach.CoachName,
                    Email = coach.Email,
                    Specialty = coach.Specialty,
                    BranchID = coach.BranchID
                }, commandType : CommandType.StoredProcedure);
            return result > 0;
            }
        }

        public async Task<Coach> GetCoachID(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
             await connection.OpenAsync();

            return await connection.QueryFirstOrDefaultAsync<Coach>("sp_GetCoachID", new { CoachID = id }, commandType : CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateCoachAsync(Coach coach)
         {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync("sp_UpdateCoach", 
                    new
                {
                    CoachID = coach.CoachID,
                    CoachName = coach.CoachName,
                    Email = coach.Email,
                    Specialty = coach.Specialty,
                    BranchID = coach.BranchID

                }, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
         }
        
        public async Task<bool> DeleteCoachAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync("sp_DeleteCoach", new
                {
                    CoachID = id
                },commandType : CommandType.StoredProcedure);

            return result > 0;
            }
        }

    }

