
public interface IWalkInRepository
{
    Task<IEnumerable<WalkIn>> getAllWalkInAsyn();
    Task<bool> InsertWalkInAsync(WalkIn walkIn);
    Task<WalkIn> GetIdWalkInAsync(int id);
    Task<bool> UpdateWalkInAsync(WalkIn walkIn);
    Task<bool> DeleteWalkInAsync(int id);
}

