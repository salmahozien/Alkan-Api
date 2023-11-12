using flutterApi.DTOs.Register;
using flutterApi.DTOs.User;
using flutterApi.Interfaces;
using flutterApi.Models;
using login.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace flutterApi.Controllers
{
    [Route("Auth/[action]")]
    public class AuthController : ControllerBase
    {
       private readonly IAuthService _authService;
        private readonly UserManager<User> _userManager;
        public AuthController(IAuthService authService, UserManager<User> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result= await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.Login(model);
            
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            //cookies
            if (!string.IsNullOrEmpty(result.RefreshToken))
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] AddRoleModelDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(model);
        }
        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _authService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                //Expires= expires.UtcNow.AddSeconds,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };
           

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
        [HttpPost]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenDto model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authService.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> signout()
        {
             await _authService.Logout();
            
            return Ok();
        }


        // [HttpGet]

        // public async Task<IActionResult> GetAllUsers()
        //  {
        //   var users = await _authService..GetAll();
        //    if (Certification != null || !Certification.Any())
        //    {
        //        var result = Certification.Adapt<IEnumerable<UpdateCertificationDto>>().ToList(); ;


        //        return Ok(result);
        //    }
        //    var NewCertification = new List<IEnumerable<CreateCertificationDto>>();
        //    return NotFound(NewCertification);

        //}
       

    }
}

