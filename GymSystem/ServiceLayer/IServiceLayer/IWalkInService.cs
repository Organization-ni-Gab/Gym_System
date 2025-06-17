
public interface IWalkInService
{
    Task<IEnumerable<WalkIn>> getAllWalkInAsyn();
    Task<bool> InsertWalkInAsync(WalkIn walk);
    Task<WalkIn> GetIdWalkInAsync(int id);
    Task<bool> UpdateWalkInAsync(WalkIn walk);
    Task<bool> DeleteWalkInAsync(int id);
}