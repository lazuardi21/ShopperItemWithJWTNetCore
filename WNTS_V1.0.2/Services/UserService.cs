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
        }

        
        


        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<PL_USER> _users = new List<PL_USER>
        {
            new PL_USER {USER_NAME = "admin", PASSWORD = "admin" }
        };



        public List<PL_USER> Authenticate(string USER_NAME, string PASSWORD)
        {

            List<PL_USER> UserList = new List<PL_USER>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try 
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PL_USER where USER_NAME= '" + USER_NAME + "' and PASSWORD = '" + PASSWORD + "'";
                        OracleDataReader reader = cmd.ExecuteReader();
                        PL_USER item = new PL_USER();
                        while (reader.Read())
                        {
                            item = new PL_USER();
                            if (reader[0] != DBNull.Value) { item.USER_ID = Convert.ToInt32(reader[0]); }
                            if (reader[1] != DBNull.Value) { item.USER_NAME = Convert.ToString(reader[1]); }
                            if (reader[2] != DBNull.Value) { item.PASSWORD = Convert.ToString(reader[2]); }

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

        public void Register(string USER_NAME, string PASSWORD)
        {

           
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                try
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        Message = "";
                        con.Open();
                        cmd.CommandText = "Insert into PL_USER (user_id, user_name, password) values (pl_user_seq.nextval,'" + USER_NAME + "','" + PASSWORD + "')" + "";
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
          
        }

        public IEnumerable<PL_USER> GetAll()
        {
            return _users;
        }

        public PL_USER GetByName(string name)
        {
            return _users.FirstOrDefault(x => x.USER_NAME == name);
        }

        // helper methods

        private string generateJwtToken(PL_USER user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("USER_NAME", user.USER_NAME.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
