using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
namespace WNTS_V1._0._2.Services
{
    public class GasOperationService : IGasOperation
    {
        private readonly string _connectionString;
        public string Message { get; set; }
        public GasOperationService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<PL_OPERATION> GetGasOperation()
        {
            List<PL_OPERATION> GasOperationList = new List<PL_OPERATION>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                
                using (OracleCommand cmd = con.CreateCommand())
                {
                   
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PL_OPERATION where rownum <= 10";
                        OracleDataReader reader = cmd.ExecuteReader();
                        PL_OPERATION item = new PL_OPERATION();
                        while (reader.Read())
                        {
                            item = new PL_OPERATION();
                            if (reader[1] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(reader[1]); }
                            if (reader[0] != DBNull.Value) { item.DATE_STAMP = Convert.ToDateTime(reader[0]); }
                            if (reader[2] != DBNull.Value) { item.PRESSURE = Convert.ToSingle(reader[2]); }
                            if (reader[3] != DBNull.Value) { item.TEMPERATURE = Convert.ToSingle(reader[3]); }
                            if (reader[4] != DBNull.Value) { item.MOISTURE = Convert.ToSingle(reader[4]); }
                            if (reader[5] != DBNull.Value) { item.ENERGY_RATE = Convert.ToSingle(reader[5]); }
                            if (reader[6] != DBNull.Value) { item.VOLUME_RATE = Convert.ToSingle(reader[6]); }
                            if (reader[7] != DBNull.Value) { item.INLET_PRESSURE = Convert.ToSingle(reader[7]); }
                            if (reader[8] != DBNull.Value) { item.INLET_TEMPERATURE = Convert.ToSingle(reader[8]); }
                            if (reader[9] != DBNull.Value) { item.FUEL_VOLUME_RATE = Convert.ToSingle(reader[9]); }
                            if (reader[10] != DBNull.Value) { item.FUEL_ENERGY_RATE = Convert.ToSingle(reader[10]); }
                            //if (reader[11] != DBNull.Value) { item.CALCULATED = Convert.ToSingle(reader[11]); }
                            //if (reader[12] != DBNull.Value) { item.USER_ID = Convert.ToString(reader[12]); }
                            //if (reader[13] != DBNull.Value) { item.VERSION_NUMBER = Convert.ToInt32(reader[13]); }
                            GasOperationList.Add(item);
                        }
                        
                    }
                    catch (Exception ex) 
                    {
                        Message = ex.Message;
                    }


                }
            }
            return GasOperationList;
        }


        public List<PL_OPERATION> GetGasOperationByDate(string startdate, string enddate)
        {

            List<PL_OPERATION> GasOperationList = new List<PL_OPERATION>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from (Select * from PL_OPERATION where DATE_STAMP>= TO_DATE('" + startdate + "','YYYY-MM-DD HH24:MI:SS') " +
                        "and DATE_STAMP < TO_DATE('" + enddate + "','YYYY-MM-DD HH24:MI:SS') order by DATE_STAMP desc) where rownum=1" + "";
                    OracleDataReader reader = cmd.ExecuteReader();
                    PL_OPERATION item = new PL_OPERATION();
                    while (reader.Read())
                    {
                        item = new PL_OPERATION();
                        if (reader[1] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(reader[1]); }
                        if (reader[0] != DBNull.Value) { item.DATE_STAMP = Convert.ToDateTime(reader[0]); }
                        if (reader[2] != DBNull.Value) { item.PRESSURE = Convert.ToSingle(reader[2]); }
                        if (reader[3] != DBNull.Value) { item.TEMPERATURE = Convert.ToSingle(reader[3]); }
                        if (reader[4] != DBNull.Value) { item.MOISTURE = Convert.ToSingle(reader[4]); }
                        if (reader[5] != DBNull.Value) { item.ENERGY_RATE = Convert.ToSingle(reader[5]); }
                        if (reader[6] != DBNull.Value) { item.VOLUME_RATE = Convert.ToSingle(reader[6]); }
                        if (reader[7] != DBNull.Value) { item.INLET_PRESSURE = Convert.ToSingle(reader[7]); }
                        if (reader[8] != DBNull.Value) { item.INLET_TEMPERATURE = Convert.ToSingle(reader[8]); }
                        if (reader[9] != DBNull.Value) { item.FUEL_VOLUME_RATE = Convert.ToSingle(reader[9]); }
                        if (reader[10] != DBNull.Value) { item.FUEL_ENERGY_RATE = Convert.ToSingle(reader[10]); }
                        //if (reader[11] != DBNull.Value) { item.CALCULATED = Convert.ToSingle(reader[11]); }
                        //if (reader[12] != DBNull.Value) { item.USER_ID = Convert.ToString(reader[12]); }
                        //if (reader[13] != DBNull.Value) { item.VERSION_NUMBER = Convert.ToInt32(reader[13]); }
                        GasOperationList.Add(item);

                    }
                }
            }
            return GasOperationList;
        }

        //public GasComponentService GetGasComponentbyId(int eid)
        //public IEnumerable<PL_OPERATION> GetGasComponentById(int eid)
        //{

        //    List<PL_OPERATION> GasComponentList = new List<PL_OPERATION>();
        //    using (OracleConnection con = new OracleConnection(_connectionString))
        //    {
        //        using (OracleCommand cmd = con.CreateCommand())
        //        {
        //            con.Open();
        //            cmd.CommandText = "Select * from PL_OPERATION where rownum <= 10 and ASSET_ID=" + eid + "";
        //            OracleDataReader rdr = cmd.ExecuteReader();
        //            PL_OPERATION item = new PL_OPERATION();
        //            while (rdr.Read())
        //            {
        //                item = new PL_OPERATION();
        //                if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]); }
        //                if (rdr["DATE_STAMP"] != DBNull.Value) { item.DATE_STAMP = (DateTime)rdr["DATE_STAMP"]; }
        //                if (rdr["C1"] != DBNull.Value) { item.C1 = Convert.ToSingle(rdr["C1"]); }
        //                if (rdr["C2"] != DBNull.Value) { item.C2 = Convert.ToSingle(rdr["C2"]); }
        //                if (rdr["C3"] != DBNull.Value) { item.C3 = Convert.ToSingle(rdr["C3"]); }
        //                if (rdr["NC4"] != DBNull.Value) { item.NC4 = Convert.ToSingle(rdr["NC4"]); }
        //                if (rdr["IC5"] != DBNull.Value) { item.IC5 = Convert.ToSingle(rdr["IC5"]); }
        //                if (rdr["NC5"] != DBNull.Value) { item.NC5 = Convert.ToSingle(rdr["NC5"]); }
        //                if (rdr["C6"] != DBNull.Value) { item.C6 = Convert.ToSingle(rdr["C6"]); }
        //                if (rdr["C7"] != DBNull.Value) { item.C7 = Convert.ToSingle(rdr["C7"]); }
        //                if (rdr["C8"] != DBNull.Value) { item.C8 = Convert.ToSingle(rdr["C8"]); }
        //                if (rdr["C9"] != DBNull.Value) { item.C9 = Convert.ToSingle(rdr["C9"]); }
        //                if (rdr["N2"] != DBNull.Value) { item.N2 = Convert.ToSingle(rdr["N2"]); }
        //                if (rdr["CO2"] != DBNull.Value) { item.CO2 = Convert.ToSingle(rdr["CO2"]); }
        //                if (rdr["HCDP"] != DBNull.Value) { item.HCDP = Convert.ToSingle(rdr["HCDP"]); }
        //                if (rdr["CALC_HCDP"] != DBNull.Value) { item.CALC_HCDP = Convert.ToSingle(rdr["CALC_HCDP"]); }
        //                if (rdr["GHV"] != DBNull.Value) { item.GHV = Convert.ToSingle(rdr["GHV"]); }
        //                GasComponentList.Add(item);

        //            }
        //        }
        //    }
        //    return GasComponentList;
        //}



        //public void AddGasComponent(PL_OPERATION GasComponent)
        //{
        //    try
        //    {
        //        using (OracleConnection con = new OracleConnection(_connectionString))
        //        {
        //            using (OracleCommand cmd = new OracleCommand())
        //            {
        //                con.Open();
        //                cmd.CommandText = "Insert into Student(Id, Name, Email)Values(" + GasComponent.Id + ",'" + GasComponent.Name + "','" + GasComponent.Email + "'')";
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //public void EditGasComponent(PL_OPERATION GasComponent)
        //{
        //    try
        //    {
        //        using (OracleConnection con = new OracleConnection(_connectionString))
        //        {
        //            using (OracleCommand cmd = new OracleCommand())
        //            {
        //                con.Open();
        //                cmd.CommandText = "Update Student Set Name='" + student.Name + "', Email='" + student.Email + "' where Id=" + student.Id + "";
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //public void DeleteGasComponent(PL_OPERATION GasComponent)
        //{
        //    try
        //    {
        //        using (OracleConnection con = new OracleConnection(_connectionString))
        //        {
        //            using (OracleCommand cmd = new OracleCommand())
        //            {
        //                con.Open();
        //                cmd.CommandText = "Delete from Student where Id=" + student.Id + "";
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}