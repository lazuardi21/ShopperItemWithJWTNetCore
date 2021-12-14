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
    public class ShoppingService : IShopping
    {
        private readonly AppSettings _appSettings;
        private readonly string _connectionString;
        public string Message { get; set; }
        public ShoppingService(IOptions<AppSettings> appSettings, IConfiguration _configuratio)
        {
            _appSettings = appSettings.Value;
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
            //_connectionString = _configuratio.GetConnectionString("DefaultDB");
        }

        
        


        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<SHOPPING> _shop = new List<SHOPPING>
        {
            new SHOPPING {name = "admin", createddate = "admin"}
        };



        public List<SHOPPING> Authenticate(string email, string PASSWORD)
        {

            List<SHOPPING> ShopList = new List<SHOPPING>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try 
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PIPELINE." + "\"" + "user" + "\"" + "where email= '" + email + "' and password = '" + PASSWORD + "'";
                        OracleDataReader reader = cmd.ExecuteReader();
                        SHOPPING item = new SHOPPING();
                        while (reader.Read())
                        {
                            item = new SHOPPING();
                            if (reader[0] != DBNull.Value) { item.id = Convert.ToInt32(reader[0]); }
                            if (reader[1] != DBNull.Value) { item.name = Convert.ToString(reader[1]); }
                            if (reader[2] != DBNull.Value) { item.createddate = Convert.ToString(reader[2]); }

                            ShopList.Add(item);

                        }
                    }
                    catch(Exception ex)
                    {
                        Message = ex.Message;
                    }
                    
                }
            }
            return ShopList;
        }

        public List<SHOPPING> Add(string name, string createddate)
        {

            List<SHOPPING> ShopList = new List<SHOPPING>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                try
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        
                        Message = "";
                        con.Open();
                        cmd.CommandText = "Insert into PIPELINE.\"shopping\"(name,createddate) values ('" + name + "',(TO_DATE('" + createddate + "', 'yyyy/mm/dd hh24:mi:ss')))" + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        
                    }
                    ShopList.Add(GetByName(name));
                    ShopList.Add(GetByName(createddate));
                }
                catch (Exception)
                {
                    throw;
                }
                
               
            }
            return ShopList;
          
        }

        public IEnumerable<SHOPPING> GetAll()
        {
            List<SHOPPING> ShopList = new List<SHOPPING>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PIPELINE." + "\"" + "user" + "\"" + "";
                        OracleDataReader reader = cmd.ExecuteReader();
                        SHOPPING item = new SHOPPING();
                        while (reader.Read())
                        {
                            item = new SHOPPING();
                            if (reader[0] != DBNull.Value) { item.id = Convert.ToInt32(reader[0]); }
                            if (reader[1] != DBNull.Value) { item.name = Convert.ToString(reader[1]); }
                            if (reader[2] != DBNull.Value) { item.createddate = Convert.ToString(reader[2]); }
                            ShopList.Add(item);

                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }

                }
            }
            return ShopList;


            
        }

        public SHOPPING GetByName(string email)
        {
            return _shop.FirstOrDefault(x => x.name == email);
        }

        public List<SHOPPING> GetById(int id)
        {
            List<SHOPPING> ShopList = new List<SHOPPING>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PIPELINE." + "\"" + "shopping" + "\"" + "where id= '" + id + "'";
                        OracleDataReader reader = cmd.ExecuteReader();
                        SHOPPING item = new SHOPPING();
                        while (reader.Read())
                        {
                            item = new SHOPPING();
                            if (reader[0] != DBNull.Value) { item.id = Convert.ToInt32(reader[0]); }
                            if (reader[1] != DBNull.Value) { item.name = Convert.ToString(reader[1]); }
                            if (reader[2] != DBNull.Value) { item.createddate = Convert.ToString(reader[2]); }

                            ShopList.Add(item);

                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }

                }
            }
            return ShopList;
        }

        // helper methods


    }
}
