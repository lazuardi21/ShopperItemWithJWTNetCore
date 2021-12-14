using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;
using WNTS_V1._0._2.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace WNTS_V1._0._2.Services
{
    public class UserService : IUser
    {
        private readonly AppSettings _appSettings;
        private readonly string _connectionString;
        public string Message { get; set; }
        public UserService(IOptions<AppSettings> appSettings, IConfiguration _configuratio)
        {
            _appSettings = appSettings.Value;
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
            //_connectionString = _configuratio.GetConnectionString("DefaultDB");
        }

        
        


        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<USER> _users = new List<USER>
        {
            new USER {username = "admin", password = "admin", email = "i@gmail.com" }
        };



        public List<USER> Authenticate(string email, string PASSWORD)
        {

            List<USER> UserList = new List<USER>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try 
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PIPELINE." + "\"" + "user" + "\"" + "where email= '" + email + "' and password = '" + PASSWORD + "'";
                        OracleDataReader reader = cmd.ExecuteReader();
                        USER item = new USER();
                        while (reader.Read())
                        {
                            item = new USER();
                            if (reader[3] != DBNull.Value) { item.email = Convert.ToString(reader[3]); }
                            if (reader[2] != DBNull.Value) { item.password = Convert.ToString(reader[2]); }
                            if (reader[1] != DBNull.Value) { item.username = Convert.ToString(reader[1]); }

                            UserList.Add(item);

                        }
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                    }
                    
                }
            }
            return UserList;
        }

        public List<USER> Register(string user_name, string PASSWORD_ENC, string email, string phone, string country, string city, string postcode, string name, string address)
        {

            List<USER> UserList = new List<USER>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                try
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        Message = "";
                        con.Open();
                        cmd.CommandText = "Insert into PIPELINE.\"user\"(username,password,email,phone,country,city,postcode,name,address) values ('" + user_name + "','" + PASSWORD_ENC + "','" + email + "','" + phone + "','" + country + "','" + city + "','" + postcode + "','" + name + "','" + address + "')" + "";
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                UserList.Add(GetByName(user_name));
                UserList.Add(GetByName(PASSWORD_ENC));
                UserList.Add(GetByName(email));
                UserList.Add(GetByName(phone));
                UserList.Add(GetByName(country));
                UserList.Add(GetByName(city));
                UserList.Add(GetByName(postcode));
                UserList.Add(GetByName(name));
                UserList.Add(GetByName(address));
            }
            return UserList;
          
        }

        public IEnumerable<USER> GetAll()
        {
            List<USER> UserList = new List<USER>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PIPELINE." + "\"" + "user" + "\"" + "";
                        OracleDataReader reader = cmd.ExecuteReader();
                        USER item = new USER();
                        while (reader.Read())
                        {
                            item = new USER();
                            if (reader[3] != DBNull.Value) { item.email = Convert.ToString(reader[3]); }
                            if (reader[2] != DBNull.Value) { item.password = Convert.ToString(reader[2]); }
                            if (reader[1] != DBNull.Value) { item.username = Convert.ToString(reader[1]); }
                            if (reader[4] != DBNull.Value) { item.phone = Convert.ToString(reader[4]); }
                            if (reader[5] != DBNull.Value) { item.country = Convert.ToString(reader[5]); }
                            if (reader[6] != DBNull.Value) { item.city = Convert.ToString(reader[6]); }
                            if (reader[6] != DBNull.Value) { item.postcode = Convert.ToString(reader[6]); }
                            if (reader[6] != DBNull.Value) { item.name = Convert.ToString(reader[6]); }
                            if (reader[6] != DBNull.Value) { item.address = Convert.ToString(reader[6]); }
                            UserList.Add(item);

                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }

                }
            }
            return UserList;


            
        }

        public USER GetByName(string email)
        {
            return _users.FirstOrDefault(x => x.email == email);
        }

        // helper methods

        private string generateJwtToken(USER user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", user.username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
