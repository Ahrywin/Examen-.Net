using Microsoft.EntityFrameworkCore;
using Test.Data.ExamenModels;
using Test.Data.Interfaces;
using Test.DTOs;

namespace Test.Data.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly DbAad4f5ExamenContext _context;

        public AuthRepository (DbAad4f5ExamenContext context)
        {
            _context = context;
        }
        public async Task<Usuario> GetUser (string email,string password)
        {

            try
            {
                if (email == null) { throw new ArgumentException(nameof(email), "El correo electronico no puede ser nulo."); }
                if (password == null) { throw new ArgumentException(nameof(password), "La contraseña no puede ser nula."); }


                var existUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

                if (existUser == null) { throw new KeyNotFoundException($"No existe el usuario  {email}"); };

                return existUser;
                


            }
            catch (Exception ex)
            {
                throw new Exception("Datos de acceso incorrectos o no existe el usuario.", ex);

            }

             
        }
    }
}
