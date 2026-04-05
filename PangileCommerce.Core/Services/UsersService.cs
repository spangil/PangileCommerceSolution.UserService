
using AutoMapper;
using PangileCommerce.Core.DTO;
using PangileCommerce.Core.Entities;
using PangileCommerce.Core.RepositoryContracts;
using PangileCommerce.Core.ServiceContracts;

namespace PangileCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user is null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token"};

        //return new AuthenticationResponse(
        //    user.UserID,
        //    user.Email,
        //    user.PersonName,
        //    user.Gender,
        //    "token",
        //    true);

    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        ApplicationUser test = new ApplicationUser()
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString()
        };

        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);

        ApplicationUser? registerdUser =  await _usersRepository.AddUser(user);
        if (registerdUser is null) {
            return null;
        }

        //return new AuthenticationResponse(
        //    registerdUser.UserID,
        //    registerdUser.Email,
        //    registerdUser.PersonName,
        //    registerdUser.Gender,
        //    "token",
        //    true);

        return _mapper.Map<AuthenticationResponse>(registerdUser) with { Success = true, Token = "token" };

    }

}
