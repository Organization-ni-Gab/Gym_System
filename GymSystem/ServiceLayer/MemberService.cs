
public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<IEnumerable<Member>> getAllMemberAsyn()
    {
        return await _memberRepository.getAllMemberAsyn();
    }
    public async Task<bool> InsertMemberAsync(Member member)
    {
        return await _memberRepository.InsertMemberAsync(member);
    }
    public async Task<Member> GetIdMemberAsync(int id)
    {
        return await _memberRepository.GetIdMemberAsync(id);
    }
    public async Task<bool> UpdateMemberAsync(Member member)
    {
        return await _memberRepository.UpdateMemberAsync(member);
    }
    public async Task<bool> DeleteMemberAsync(int id)
    {
        return await _memberRepository.DeleteMemberAsync(id);    
    }
}



