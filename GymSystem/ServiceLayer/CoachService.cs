    public class CoachService : ICoachService
    {
        private readonly ICoachRepository _coachRepository;
        public CoachService(ICoachRepository coachRepository)
            {
                 _coachRepository = coachRepository;
            }

         public async Task<IEnumerable<Coach>>GetAllCoachAsync()
            {
             return await _coachRepository.GetAllCoachAsync();
            }

         public async Task<bool> CreateCoachAsync(Coach coach)
            {
                return await _coachRepository.CreateCoachAsync(coach);
            }

        public async Task<Coach> GetCoachID(int id)
            {
            return await _coachRepository.GetCoachID(id);
            }

        public async Task<bool> UpdateCoachAsync(Coach coach)
        {
            return await _coachRepository.UpdateCoachAsync(coach);
        }

        public async Task<bool> DeleteCoachAsync(int id)
        {
             return await _coachRepository.DeleteCoachAsync(id);
        }
    }

