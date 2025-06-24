using BindrAPI.Models.Auth;
using BindrAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Supabase.Interfaces;

namespace BindrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ApplicationDbContext context, Supabase.Client client) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;
        private readonly Supabase.Client _client = client;

        // POST api/User/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser([FromBody] LoginRequest request, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // create in Firebase Auth here (was using supabase for now)
            /*try
            {
                var response = await _client.Auth.SignUp(request.Email, request.Password);

                if (response.User != null)
                {
                    return Ok(new { Message = "User registered successfully. Check email for confirmation.", UserId = response.User.Id });
                }
                else
                {
                    return BadRequest(new { Message = response.ErrorMessage ?? "Registration failed." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred during registration." });
            }*/

            // once in Firebase Auth, get the ID and use it in Supabase's DB
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("User: ", user);
        }

        // POST api/User/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // 1. Model Validation
            // ASP.NET Core automatically performs model validation based on Data Annotations
            // If validation fails, ModelState.IsValid will be false
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // returns a 400 bad request with validation errors
            }

            // 2. Perform Auth Logic (replace this with Firebase, was just using supabase for now)
            /*try
            {
                var response = await _client.Auth.SignIn(request.Email, request.Password);

                if (response.User != null && !string.IsNullOrEmpty(response.AccessToken))
                {
                    // Authentication successful
                    // Return the access token or user information
                    return Ok(new { AccessToken = response.AccessToken, User = response.User });
                }
                else
                {
                    // Authentication failed (e.g., bad credentials)
                    return Unauthorized(new { Message = response.ErrorMessage ?? "Invalid credentials." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                // _logger.LogError(ex, "Login failed for email: {Email}", request.Email);
                return StatusCode(500, new { Message = "An unexpected error occurred during login." });
            }*/

            return NoContent();
        }
        

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUserInfo(Guid id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            user.firstName = updatedUser.firstName;
            user.lastName = updatedUser.lastName;

            await _context.SaveChangesAsync();

            return NoContent();


        }
    }
}