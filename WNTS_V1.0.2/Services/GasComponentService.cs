using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
namespace WNTS_V1._0._2.Services
{
    public class GasComponentService : IGasComponent
    {
        private readonly string _connectionString;
        public string Message { get; set; }
        public GasComponentService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<PL_GAS_COMPONENT> GetGasComponent()
        {
            List<PL_GAS_COMPONENT> GasComponentList = new List<PL_GAS_COMPONENT>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                
                using (OracleCommand cmd = con.CreateCommand())
                {
                   
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PL_GAS_COMPONENT where rownum <= 10";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        PL_GAS_COMPONENT item = new PL_GAS_COMPONENT();
                        while (rdr.Read())
                        {
                                item = new PL_GAS_COMPONENT();
                                //ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]),
                                //DATE_STAMP = (DateTime)rdr["DATE_STAMP"],
                                if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]);}
                                if (rdr["DATE_STAMP"] != DBNull.Value) { item.DATE_STAMP = (DateTime)rdr["DATE_STAMP"]; }
                                if (rdr["C1"] != DBNull.Value) { item.C1 = Convert.ToSingle(rdr["C1"]); }
                                if (rdr["C2"] != DBNull.Value) { item.C2 = Convert.ToSingle(rdr["C2"]); }
                                if (rdr["C3"] != DBNull.Value) { item.C3 = Convert.ToSingle(rdr["C3"]); }
                                if (rdr["NC4"] != DBNull.Value) { item.NC4 = Convert.ToSingle(rdr["NC4"]); }
                                if (rdr["IC5"] != DBNull.Value) { item.IC5 = Convert.ToSingle(rdr["IC5"]); }
                                if (rdr["NC5"] != DBNull.Value) { item.NC5 = Convert.ToSingle(rdr["NC5"]); }
                                if (rdr["C6"] != DBNull.Value) { item.C6 = Convert.ToSingle(rdr["C6"]); }
                                if (rdr["C7"] != DBNull.Value) { item.C7 = Convert.ToSingle(rdr["C7"]); }
                                if (rdr["C8"] != DBNull.Value) { item.C8 = Convert.ToSingle(rdr["C8"]); }
                                if (rdr["C9"] != DBNull.Value) { item.C9 = Convert.ToSingle(rdr["C9"]); }
                                if (rdr["N2"] != DBNull.Value) { item.N2 = Convert.ToSingle(rdr["N2"]); }
                                if (rdr["CO2"] != DBNull.Value) { item.CO2 = Convert.ToSingle(rdr["CO2"]); }
                                if (rdr["HCDP"] != DBNull.Value) { item.HCDP = Convert.ToSingle(rdr["HCDP"]); }
                                if (rdr["CALC_HCDP"] != DBNull.Value) { item.CALC_HCDP = Convert.ToSingle(rdr["CALC_HCDP"]); }
                                if (rdr["GHV"] != DBNull.Value) { item.GHV = Convert.ToSingle(rdr["GHV"]); }
                                GasComponentList.Add(item);
                        }
                        
                    }
                    catch (Exception ex) 
                    {
                        Message = ex.Message;
                    }


                }
            }
            return GasComponentList;
        }

        //public GasComponentService GetGasComponentbyId(int eid)
        public IEnumerable<PL_GAS_COMPONENT> GetGasComponentById(int eid)
        {

            List<PL_GAS_COMPONENT> GasComponentList = new List<PL_GAS_COMPONENT>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from PL_GAS_COMPONENT where rownum <= 10 and ASSET_ID=" + eid + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    PL_GAS_COMPONENT item = new PL_GAS_COMPONENT();
                    while (rdr.Read())
                    {
                        item = new PL_GAS_COMPONENT();
                        if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]); }
                        if (rdr["DATE_STAMP"] != DBNull.Value) { item.DATE_STAMP = (DateTime)rdr["DATE_STAMP"]; }
                        if (rdr["C1"] != DBNull.Value) { item.C1 = Convert.ToSingle(rdr["C1"]); }
                        if (rdr["C2"] != DBNull.Value) { item.C2 = Convert.ToSingle(rdr["C2"]); }
                        if (rdr["C3"] != DBNull.Value) { item.C3 = Convert.ToSingle(rdr["C3"]); }
                        if (rdr["NC4"] != DBNull.Value) { item.NC4 = Convert.ToSingle(rdr["NC4"]); }
                        if (rdr["IC5"] != DBNull.Value) { item.IC5 = Convert.ToSingle(rdr["IC5"]); }
                        if (rdr["NC5"] != DBNull.Value) { item.NC5 = Convert.ToSingle(rdr["NC5"]); }
                        if (rdr["C6"] != DBNull.Value) { item.C6 = Convert.ToSingle(rdr["C6"]); }
                        if (rdr["C7"] != DBNull.Value) { item.C7 = Convert.ToSingle(rdr["C7"]); }
                        if (rdr["C8"] != DBNull.Value) { item.C8 = Convert.ToSingle(rdr["C8"]); }
                        if (rdr["C9"] != DBNull.Value) { item.C9 = Convert.ToSingle(rdr["C9"]); }
                        if (rdr["N2"] != DBNull.Value) { item.N2 = Convert.ToSingle(rdr["N2"]); }
                        if (rdr["CO2"] != DBNull.Value) { item.CO2 = Convert.ToSingle(rdr["CO2"]); }
                        if (rdr["HCDP"] != DBNull.Value) { item.HCDP = Convert.ToSingle(rdr["HCDP"]); }
                        if (rdr["CALC_HCDP"] != DBNull.Value) { item.CALC_HCDP = Convert.ToSingle(rdr["CALC_HCDP"]); }
                        if (rdr["GHV"] != DBNull.Value) { item.GHV = Convert.ToSingle(rdr["GHV"]); }
                        GasComponentList.Add(item);
                       
                    }
                }
            }
            return GasComponentList;
        }



        public List<PL_GAS_COMPONENT> GetGasComponentByDate(string startdate, string enddate)
        {

            List<PL_GAS_COMPONENT> GasComponentList = new List<PL_GAS_COMPONENT>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from (Select * from PL_GAS_COMPONENT where DATE_STAMP>= TO_DATE('" + startdate + "','YYYY-MM-DD HH24:MI:SS') " +
                        "and DATE_STAMP < TO_DATE('" + enddate + "','YYYY-MM-DD HH24:MI:SS') order by DATE_STAMP desc) where rownum=1"  + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    PL_GAS_COMPONENT item = new PL_GAS_COMPONENT();
                    while (rdr.Read())
                    {
                        item = new PL_GAS_COMPONENT();
                        if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]); }
                        if (rdr["DATE_STAMP"] != DBNull.Value) { item.DATE_STAMP = (DateTime)rdr["DATE_STAMP"]; }
                        if (rdr["C1"] != DBNull.Value) { item.C1 = Convert.ToSingle(rdr["C1"]); }
                        if (rdr["C2"] != DBNull.Value) { item.C2 = Convert.ToSingle(rdr["C2"]); }
                        if (rdr["C3"] != DBNull.Value) { item.C3 = Convert.ToSingle(rdr["C3"]); }
                        if (rdr["NC4"] != DBNull.Value) { item.NC4 = Convert.ToSingle(rdr["NC4"]); }
                        if (rdr["IC5"] != DBNull.Value) { item.IC5 = Convert.ToSingle(rdr["IC5"]); }
                        if (rdr["NC5"] != DBNull.Value) { item.NC5 = Convert.ToSingle(rdr["NC5"]); }
                        if (rdr["C6"] != DBNull.Value) { item.C6 = Convert.ToSingle(rdr["C6"]); }
                        if (rdr["C7"] != DBNull.Value) { item.C7 = Convert.ToSingle(rdr["C7"]); }
                        if (rdr["C8"] != DBNull.Value) { item.C8 = Convert.ToSingle(rdr["C8"]); }
                        if (rdr["C9"] != DBNull.Value) { item.C9 = Convert.ToSingle(rdr["C9"]); }
                        if (rdr["N2"] != DBNull.Value) { item.N2 = Convert.ToSingle(rdr["N2"]); }
                        if (rdr["CO2"] != DBNull.Value) { item.CO2 = Convert.ToSingle(rdr["CO2"]); }
                        if (rdr["HCDP"] != DBNull.Value) { item.HCDP = Convert.ToSingle(rdr["HCDP"]); }
                        if (rdr["CALC_HCDP"] != DBNull.Value) { item.CALC_HCDP = Convert.ToSingle(rdr["CALC_HCDP"]); }
                        if (rdr["GHV"] != DBNull.Value) { item.GHV = Convert.ToSingle(rdr["GHV"]); }
                        GasComponentList.Add(item);

                    }
                }
            }
            return GasComponentList;
        }

        public List<PL_GAS_COMPONENT> GetGasComponentByDateId(int id, string startdate, string enddate)
        {

            List<PL_GAS_COMPONENT> GasComponentList = new List<PL_GAS_COMPONENT>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from (Select * from PL_GAS_COMPONENT where ASSET_ID ="+ id + " AND DATE_STAMP>= TO_DATE('" + startdate + "','YYYY-MM-DD HH24:MI:SS') " +
                        "and DATE_STAMP < TO_DATE('" + enddate + "','YYYY-MM-DD HH24:MI:SS') order by DATE_STAMP desc) where rownum=1" + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    PL_GAS_COMPONENT item = new PL_GAS_COMPONENT();
                    while (rdr.Read())
                    {
                        item = new PL_GAS_COMPONENT();
                        if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]); }
                        if (rdr["DATE_STAMP"] != DBNull.Value) { item.DATE_STAMP = (DateTime)rdr["DATE_STAMP"]; }
                        if (rdr["C1"] != DBNull.Value) { item.C1 = Convert.ToSingle(rdr["C1"]); }
                        if (rdr["C2"] != DBNull.Value) { item.C2 = Convert.ToSingle(rdr["C2"]); }
                        if (rdr["C3"] != DBNull.Value) { item.C3 = Convert.ToSingle(rdr["C3"]); }
                        if (rdr["NC4"] != DBNull.Value) { item.NC4 = Convert.ToSingle(rdr["NC4"]); }
                        if (rdr["IC5"] != DBNull.Value) { item.IC5 = Convert.ToSingle(rdr["IC5"]); }
                        if (rdr["NC5"] != DBNull.Value) { item.NC5 = Convert.ToSingle(rdr["NC5"]); }
                        if (rdr["C6"] != DBNull.Value) { item.C6 = Convert.ToSingle(rdr["C6"]); }
                        if (rdr["C7"] != DBNull.Value) { item.C7 = Convert.ToSingle(rdr["C7"]); }
                        if (rdr["C8"] != DBNull.Value) { item.C8 = Convert.ToSingle(rdr["C8"]); }
                        if (rdr["C9"] != DBNull.Value) { item.C9 = Convert.ToSingle(rdr["C9"]); }
                        if (rdr["N2"] != DBNull.Value) { item.N2 = Convert.ToSingle(rdr["N2"]); }
                        if (rdr["CO2"] != DBNull.Value) { item.CO2 = Convert.ToSingle(rdr["CO2"]); }
                        if (rdr["HCDP"] != DBNull.Value) { item.HCDP = Convert.ToSingle(rdr["HCDP"]); }
                        if (rdr["CALC_HCDP"] != DBNull.Value) { item.CALC_HCDP = Convert.ToSingle(rdr["CALC_HCDP"]); }
                        if (rdr["GHV"] != DBNull.Value) { item.GHV = Convert.ToSingle(rdr["GHV"]); }
                        GasComponentList.Add(item);

                    }
                }
            }
            return GasComponentList;
        }
        //public void AddGasComponent(PL_GAS_COMPONENT GasComponent)
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
        //public void EditGasComponent(PL_GAS_COMPONENT GasComponent)
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
        //public void DeleteGasComponent(PL_GAS_COMPONENT GasComponent)
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