using ERPSystem.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ERP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ErpContext _context;
        private readonly IConfiguration _configuration;

        public AdminsController(ErpContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login(CreateAdmin createAdmin)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Email == createAdmin.Email);

            if (admin == null)
            {
                return Unauthorized(); // Invalid Email
            }

            if (!VerifyPasswordHash(createAdmin.Password, admin.Password, admin.SaltKey))
            {
                return Unauthorized(); // Invalid Password 
            }

            var token = GenerateJwtToken(admin.Email);

            return Ok(new { token });
        }

        private string GenerateJwtToken(string email)
        {
            //Generate Token
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData, email ?? string.Empty),
            };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenItem = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(10), //temprarly for now
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var AccessToken = new JwtSecurityTokenHandler().WriteToken(tokenItem);
            return AccessToken;
        }

        //Hashing method
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) // Algortithm Hash based message authentication code 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //verify password
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        [HttpPost]
        [Route("register")]
        public async Task<string> Register(CreateAdmin admin)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(admin.Password, out passwordHash, out passwordSalt);

            try
            {
                await _context.Admins.AddAsync(new Admin()
                {
                    Email = admin.Email,
                    SaltKey = passwordSalt,
                    Password = passwordHash
                });

                await _context.SaveChangesAsync();

                return "User is Created Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
