using JwtApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public ActionResult AdminsEndpoint() 
        {
            var currentUser = GetCurrentUser();
            return Ok($" Hi {currentUser.Username} You are an  {currentUser.Role}");
        }
        
        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public ActionResult SellerEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($" Hi {currentUser.Username} You are an  {currentUser.Role}");
        }


        [HttpGet("Public")]
        public ActionResult Public() 
        {
            return Ok("You are on public property");
        }


        private UserModel GetCurrentUser() 
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null) 
            {
            
                var userClaims = identity.Claims;
                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(s => s.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }
    }
}
