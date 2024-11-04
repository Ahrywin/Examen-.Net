using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Test.Data.ExamenModels;
using Test.Data.Interfaces;
using Test.DTOs;

namespace Test.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly DbAad4f5ExamenContext _context;
        
        public UserRepository (DbAad4f5ExamenContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AllUserbyStringDTO>> GetUsersByString (string searchString)
        {
            try
            {
                if (searchString == null) { throw new ArgumentException(nameof(searchString), "El searchString no puede ser nulo."); }

                var query = _context.Usuarios.AsQueryable();
                if (!string.IsNullOrEmpty(searchString))
                {
                    query = query.Where(p => p.Name.Contains(searchString));


                }
                return await query.Select(u => new AllUserbyStringDTO
                {
                    Id = u.Id,
                    DisplayName = u.DisplayName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    EmailVerified = u.EmailVerified,
                    PhoneVerified = u.PhoneVerified,
                    CreateAt = u.CreateAt,
                    LastLogin = u.LastLogin

                }).ToListAsync();



              
              
            }
            catch (Exception ex) 
            {
                throw new Exception("El formato de busqueda no es valido.",ex);

            }
        }

        public async Task NewUser (NewUserDTO newUser)
        {
            try
            {
                if(newUser == null) { throw new ArgumentException(nameof(newUser),"El usuario no puede ser nulo."); }
                if(newUser.Password == null) { throw new ArgumentException(nameof(newUser.Password), "la contraseña no puede ser nula."); }
                if (newUser.Email == null) { throw new ArgumentException(nameof(newUser.Email), "El correo no puede ser nulo."); }
                if (newUser.LastName== null) { throw new ArgumentException(nameof(newUser.LastName), "El apellido no puede ser nulo."); }
                if (newUser.PhoneNumber == null) { throw new ArgumentException(nameof(newUser.PhoneNumber), "El numero telefonico no puede ser nulo."); }

                var newUserDB = new Usuario
                {
                    Token = newUser.Token,
                    Password = newUser.Password,
                    Brithday = newUser.Brithday,
                    Name = newUser.Name,
                    Name2 = newUser.Name2,
                    LastName = newUser.LastName,
                    DisplayName = newUser.DisplayName,
                    Email = newUser.Email,
                    PhoneNumber = newUser.PhoneNumber,
                    PhotoUrl = newUser.PhotoUrl,
                    Country = newUser.Country,
                    Estado = newUser.Estado,
                    UserRol = (int)newUser.UserRol,
                    EmailVerified = newUser.EmailVerified,
                    PhoneVerified = newUser.PhoneVerified,
                    CreateAt = newUser.CreateAt,
                    LastLogin = newUser.LastLogin,
                    Origin = newUser.Origin,
                    CreatedBy = newUser.CreatedBy

                };

                await _context.Usuarios.AddAsync(newUserDB);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("El objeto usuario no es valido.", ex);

            }
        }
        
        public async Task UpdateUser (Guid Id, UpdateUserDTO updateUserDTO)
        {
            try
            {
                if (updateUserDTO == null) { throw new ArgumentException(nameof(updateUserDTO), "El usuario no puede ser nulo."); }
                if (updateUserDTO.Name == null) { throw new ArgumentException(nameof(updateUserDTO.Name), "El primer nombre no puede ser nula."); }
                if (updateUserDTO.Name2 == null) { throw new ArgumentException(nameof(updateUserDTO.Name2), "El segundo nombre no puede ser nulo."); }
                if (updateUserDTO.LastName == null) { throw new ArgumentException(nameof(updateUserDTO.LastName), "El apellido no puede ser nulo."); }
                if (updateUserDTO.Email== null) { throw new ArgumentException(nameof(updateUserDTO.Email), "El correo no puede ser nulo."); }
                if (updateUserDTO.Country== null) { throw new ArgumentException(nameof(updateUserDTO.Country), "El pais no puede ser nulo."); }

                var existUser =  await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == Id);
                if (existUser==null) { throw new KeyNotFoundException($"No existe el usuario con ID {Id}"); };

                existUser.Name = updateUserDTO.Name;
                existUser.Name2 = updateUserDTO.Name2;
                existUser.LastName = updateUserDTO.LastName;
                existUser.Email = updateUserDTO.Email;
                existUser.PhoneNumber = updateUserDTO.PhoneNumber;
                existUser.Country = updateUserDTO.Country;

                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception("El objeto usuario no es valido.", ex);

            }
        }
    }
}
