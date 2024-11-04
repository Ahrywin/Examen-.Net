using Test.Data.Interfaces;
using Test.DTOs;

namespace Test.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _repository;
        
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AllUserbyStringDTO>> GetUsersByString(string searchString)
        {
            return await _repository.GetUsersByString(searchString);
        }

        public async Task NewUser(NewUserDTO newUser)
        {
             await _repository.NewUser(newUser);
        }

        public async Task UpdateUser(Guid Id, UpdateUserDTO updateUserDTO)
        {
            await _repository.UpdateUser(Id, updateUserDTO);
        }

    }
}
