namespace API;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser> GetUserById(int id);
    Task<AppUser> GetUserByUsername(string username);
    Task<IEnumerable<MemberDto>> GetMembersAync();
    Task<MemberDto> GetMemberByUsername(string username);
}
