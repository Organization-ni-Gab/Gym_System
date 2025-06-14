
public interface IMemberRepository
{
    Task<IEnumerable<Member>> getAllMemberAsyn();
    Task<bool> InsertMemberAsync(Member member);
    Task<Member> GetIdMemberAsync(int id);
    Task<bool> UpdateMemberAsync(Member member);
    Task<bool> DeleteMemberAsync(int id);
}

