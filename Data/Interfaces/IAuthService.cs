using Test.DTOs;

namespace Test.Data.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(UserLoginDTO loginDTO);
    }
}
