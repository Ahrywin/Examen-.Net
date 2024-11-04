using Test.Data.ExamenModels;
using Test.DTOs;

namespace Test.Data.Interfaces
{
    public interface IAuthRepository
    {
        Task <Usuario> GetUser (string email, string password);
    }
}
