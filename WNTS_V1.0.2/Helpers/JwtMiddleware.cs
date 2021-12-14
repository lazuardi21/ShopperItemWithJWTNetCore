using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WNTS_V1._0._2.Services;
using WNTS_V1._0._2.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WNTS_V1._0._2.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUser userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var token_cookie = context.Request.Cookies["XSRF-TOKEN"];
            if (token_cookie != null)
                attachUserToContext(context, userService, token_cookie);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUser userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var email = (string)(jwtToken.Claims.First(x => x.Type == "sub").Value);

                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetByName(email);
            }
            catch (Exception)
            {
                //HttpContext.Session.SetString("RegistrationEnabled", ex.Message ); // Set Session  
                //var registrationEnabled = HttpContext.Session.GetString("RegistrationEnabled"); // Get Value of Session
                //var bytes = Encoding.UTF8.GetBytes(ex.Message);
                //context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                //return " the error is " + ex.Message;
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
