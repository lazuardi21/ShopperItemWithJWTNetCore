using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Antiforgery;


namespace WNTS_V1._0._2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;

        private IUser _data;
        private IAntiforgery _antiForgery;

        public UserController(IConfiguration config, IUser data, IAntiforgery antiForgery)
        {
            _config = config;
            _data = data;
            _antiForgery = antiForgery;
        }

        //private readonly IUser _dataAccessProvider;
        //public UserLoginController(IUser dataAccessProvider)
        //{
        //    _dataAccessProvider = dataAccessProvider;
        //}
        string reg = @"^[a-zA-Z0-9.\s]{1,40}$";
        //Response.Write(reg.IsMatch(txtName.Text));

        [HttpPost("login")]
        public ActionResult UserLogin(AuthenticateRequest login)
        {
            ActionResult response = Unauthorized();

            if (!Regex.IsMatch(login.USER_NAME, reg))
            {
                // Name does not match expression

                var error = "contain sql Injection";
                response = BadRequest(new { message = error });
                return response;
            }

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
                //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
                Response.Cookies.Append("XSRF-TOKEN", tokenString, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = true
                });
            }

            return response;
        }
        [HttpPost("register")]
        public ActionResult Register(AuthenticateRequest login)
        {
            ActionResult response = Unauthorized();

            if (!Regex.IsMatch(login.USER_NAME, reg))
            {
                // Name does not match expression

                var error = "contain sql Injection";
                response = BadRequest(new { message = error });
                return response;
            }
            string USER_NAME = login.USER_NAME;
            string PASSWORD = login.PASSWORD;
            string PASSWORD_ENC = Encrypt(PASSWORD);
            _data.Register(USER_NAME, PASSWORD_ENC);
            response = Ok(new { message = "The data has been created successfully" });

            return response;

        }

        //[HttpPost("register/{user_name}/{password}")]
        //public void register(string user_name, string password)
        //{
        //    _data.Register(user_name, password);

        //}

        private AuthenticateRequest AuthenticateUser(AuthenticateRequest login)
        {
            AuthenticateRequest user = null;

            //Validate the User Credentials    
            string USER_NAME = login.USER_NAME;
            string PASSWORD = login.PASSWORD;
            string PASSWORD_DEC = Encrypt(PASSWORD);
            if (_data.Authenticate(USER_NAME, PASSWORD_DEC).Count > 0)
            {
                user = new AuthenticateRequest { USER_NAME = USER_NAME, PASSWORD = PASSWORD };
            }
            return user;
        }
        private string GenerateJSONWebToken(AuthenticateRequest userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.USER_NAME),
            //new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
            //new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
