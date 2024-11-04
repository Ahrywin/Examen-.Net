using Test.DTOs;

namespace Test.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AllUserbyStringDTO>> GetUsersByString(string searchString);
        Task NewUser(NewUserDTO newUser);
        Task UpdateUser(Guid Id, UpdateUserDTO updateUser);
    }
}
