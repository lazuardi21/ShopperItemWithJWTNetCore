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
    public class ShoppingController : ControllerBase
    {
        private IConfiguration _config;

        private IShopping _data;
        private IAntiforgery _antiForgery;

        public ShoppingController(IConfiguration config, IShopping data, IAntiforgery antiForgery)
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
                response = Ok(new { users });
                //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);

            }

            return response;
        }
        [Authorize]
        [HttpGet("all/{id}")]
        public ActionResult GetByID(int id)
        {
            ActionResult response = Unauthorized();
            
            var shop  = _data.GetById(id);
            
            if (shop != null)
            {
                string name = shop[0].name;
                string createddate = shop[0].createddate;
                SHOPPING shops = null;
                if (shop.Count > 0)
                {
                    shops = new SHOPPING { id = id, name = name, createddate = createddate};
                }
                
                response = Ok(new { id = id, name = name, createddate = createddate });
                //var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
                //Response.Cookies.Append("XSRF-TOKEN", tokenString, new Microsoft.AspNetCore.Http.CookieOptions
                //{
                //    HttpOnly = true
                //});
            }

            return response;
        }
        [HttpPost]
        public ActionResult Add(SHOPPING shopping)
        {
            ActionResult response = Unauthorized();
            
            if (!Regex.IsMatch(shopping.name, reg))
            {
                // Name does not match expression

                var error = "contain sql Injection";
                response = BadRequest(new { message = error });
                return response;
            }

            string name = shopping.name;
            string createddate = string.Format("{0:HH:mm:ss tt}", shopping.createddate);
           
            var shop = _data.Add(name, createddate);
            if (shop != null)
            {
                response = Ok(new { name = name, createddate = createddate });

                return response;
                //SHOPPING shoppings = null;
                //if (shop.Count > 0)
                //{
                //    //shoppings = new SHOPPING { name = name, createddate = createddate };
                   
                //}
                

               
            }
            return null;
        }

        
    }
}
