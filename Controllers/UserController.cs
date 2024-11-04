using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Data.Interfaces;
using Test.DTOs;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
       private readonly IUserService _userService;
       private readonly IAuthService _authService;
       
       public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet("{searchString}")]
  
        public async Task<ActionResult<IEnumerable<AllUserbyStringDTO>>> Get(string searchString)
        {
           

            try
            {
                var usersSearch = await _userService.GetUsersByString(searchString);
                return Ok(usersSearch);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<NewUserDTO>> Post([FromBody]NewUserDTO newUserDTO)
        {
          

            try
            {
                await _userService.NewUser(newUserDTO);
                return CreatedAtAction( nameof(Post),new {email=newUserDTO.Email},newUserDTO);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Put([FromQuery] Guid Id,[FromBody]UpdateUserDTO updateUserDTO)
        {

            try
            {
                await _userService.UpdateUser(Id, updateUserDTO);
                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]UserLoginDTO userLoginDTO)
        {
            try
            {
                var token = await _authService.Login(userLoginDTO);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex) 
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        
        }
    }
}
