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
        string reg = @"^[a-zA-Z0-9@.\s]{1,40}$";
        //Response.Write(reg.IsMatch(txtName.Text));
        [Authorize]
        [HttpGet]
        public ActionResult GetUsers()
        {
            ActionResult response = Unauthorized();

            

            var users = _data.GetAll();

            if (users != null)
            {
               response = Ok(new { users});
                //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
                
            }

            return response;
        }

        [HttpPost("signin")]
        public ActionResult UserLogin(USER login)
        {
            ActionResult response = Unauthorized();

            if (!Regex.IsMatch(login.email, reg))
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
                string user_name = user.username;
                string email = user.email;
                response = Ok(new { email = email, token = tokenString, username = user_name });
                //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
                Response.Cookies.Append("XSRF-TOKEN", tokenString, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = true
                });
            }

            return response;
        }
        [HttpPost("signup")]
        public ActionResult Register(AuthenticateRequest login)
        {
            ActionResult response = Unauthorized();

            if (!Regex.IsMatch(login.username, reg))
            {
                // Name does not match expression

                var error = "contain sql Injection";
                response = BadRequest(new { message = error });
                return response;
            }

            string user_name = login.username;
            string password = login.password;
            string email = login.email;
            string phone = login.phone;
            string country = login.country;
            string city = login.city;
            string postcode = login.postcode;
            string name = login.name;
            string address = login.address;
           
            string PASSWORD_ENC = Encrypt(password);
            var user = _data.Register(user_name, PASSWORD_ENC, email, phone, country,city,postcode,name,address);
            if (user != null)
            {
                USER users = null;
                if (user.Count > 0)
                {
                    users = new USER { email = email, password = password };
                }
                var tokenString = GenerateJSONWebToken(users);

                //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
                Response.Cookies.Append("XSRF-TOKEN", tokenString, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    HttpOnly = true
                });

                response = Ok(new { email = email, token = tokenString, username = user_name });

                return response;
            }
            return null;
        }

        //[HttpPost("register/{user_name}/{password}")]
        //public void register(string user_name, string password)
        //{
        //    _data.Register(user_name, password);

        //}

        private USER AuthenticateUser(USER login)
        {
            USER user = null;

            //Validate the User Credentials    
            string email = login.email;
            string PASSWORD = login.password;
            string PASSWORD_DEC = Encrypt(PASSWORD);
            var b = _data.Authenticate(email, PASSWORD_DEC);
            if (b.Count > 0)
            {
                string username = b[0].username;
                user = new USER { email = email, password = PASSWORD_DEC, username = username  };
            }
            return user;
        }
        private string GenerateJSONWebToken(USER userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.email),
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
