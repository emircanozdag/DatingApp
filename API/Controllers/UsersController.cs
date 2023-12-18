using API.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAync();

        return Ok(users);

    }

    [HttpGet("user/{id}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        var user = await _userRepository.GetUserById(id);
        return _mapper.Map<MemberDto>(user);
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberByUsername(username);

    }
}
