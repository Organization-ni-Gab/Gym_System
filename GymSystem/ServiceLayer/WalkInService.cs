
public class WalkInService : IWalkInService
{
    private readonly IWalkInRepository _WalkInRepository;
    public WalkInService(IWalkInRepository WalkInRepository)
    {
        _WalkInRepository = WalkInRepository;
    }

    public async Task<IEnumerable<WalkIn>> getAllWalkInAsyn()
    {
        return await _WalkInRepository.getAllWalkInAsyn();
    }
    public async Task<bool> InsertWalkInAsync(WalkIn WalkIn)
    {
        return await _WalkInRepository.InsertWalkInAsync(WalkIn);
    }
    public async Task<WalkIn> GetIdWalkInAsync(int id)
    {
        return await _WalkInRepository.GetIdWalkInAsync(id);
    }
    public async Task<bool> UpdateWalkInAsync(WalkIn WalkIn)
    {
        return await _WalkInRepository.UpdateWalkInAsync(WalkIn);
    }
    public async Task<bool> DeleteWalkInAsync(int id)
    {
        return await _WalkInRepository.DeleteWalkInAsync(id);    
    }
}



