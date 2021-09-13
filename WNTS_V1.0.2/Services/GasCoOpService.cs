using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WNTS_V1._0._2.Interface;
using WNTS_V1._0._2.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace WNTS_V1._0._2.Services
{
    public class GasCoOpService : IGasCoOp
    {
        private readonly string _connectionString;
        public string Message { get; set; }
        public GasCoOpService(IConfiguration _configuratio)
        {
            _connectionString = _configuratio.GetConnectionString("OracleDBConnection");
        }

        public List<PV_CoOp> GetGasCoOpByDate(string startdate, string enddate)
        {
            List<PV_CoOp> GasCoOpList = new List<PV_CoOp>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandText = "Select * from PV_CoOp where DATE_STAMP>= TO_DATE('" + startdate + "','YYYY-MM-DD HH24:MI:SS') " +
                        "and DATE_STAMP < TO_DATE('" + enddate + "','YYYY-MM-DD HH24:MI:SS')" + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    PV_CoOp item = new PV_CoOp();
                    while (rdr.Read())
                    {
                        item = new PV_CoOp();
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
                        if (rdr[19] != DBNull.Value) { item.PRESSURE = Convert.ToSingle(rdr[19]); }
                        if (rdr[20] != DBNull.Value) { item.TEMPERATURE = Convert.ToSingle(rdr[20]); }
                        if (rdr[21] != DBNull.Value) { item.MOISTURE = Convert.ToSingle(rdr[21]); }
                        if (rdr[22] != DBNull.Value) { item.ENERGY_RATE = Convert.ToSingle(rdr[22]); }
                        if (rdr[23] != DBNull.Value) { item.VOLUME_RATE = Convert.ToSingle(rdr[23]); }
                        if (rdr[24] != DBNull.Value) { item.INLET_PRESSURE = Convert.ToSingle(rdr[24]); }
                        if (rdr[25] != DBNull.Value) { item.INLET_TEMPERATURE = Convert.ToSingle(rdr[25]); }
                        if (rdr[26] != DBNull.Value) { item.FUEL_VOLUME_RATE = Convert.ToSingle(rdr[26]); }
                        if (rdr[27] != DBNull.Value) { item.FUEL_ENERGY_RATE = Convert.ToSingle(rdr[27]); }
                        if (rdr[28] != DBNull.Value) { item.NAME = Convert.ToString(rdr[28]); }

                        GasCoOpList.Add(item);

                    }
                }
            }
            return GasCoOpList;
        }

        public List<PV_CoOp> GetlastGasCoOpByDate(string startdate, string enddate)
        {
            List<PV_CoOp> GasCoOpList = new List<PV_CoOp>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "SELECT Y.DATE_STAMP, Y.ASSET_ID, Y.C1,Y.C2,Y.C3,Y.IC4,Y.NC4,Y.IC5,Y.NC5,Y.C6,Y.C7,Y.C8,Y.C9,Y.N2,Y.CO2,Y.H20," +
                            "Y.HCDP,Y.CALC_HCDP,Y.GHV,Y.PRESSURE,Y.TEMPERATURE,Y.MOISTURE,Y.ENERGY_RATE,Y.VOLUME_RATE,Y.INLET_PRESSURE,Y.INLET_TEMPERATURE," +
                            "Y.FUEL_VOLUME_RATE,Y.FUEL_ENERGY_RATE,Y.NAME FROM ( SELECT RANK() OVER (PARTITION BY asset_id ORDER BY date_stamp desc) AS RNK," +
                            " DATE_STAMP, ASSET_ID, C1,C2,C3,IC4,NC4,IC5,NC5,C6,C7,C8,C9,N2,CO2,H20,HCDP,CALC_HCDP,GHV,PRESSURE,TEMPERATURE,MOISTURE," +
                            "ENERGY_RATE,VOLUME_RATE,INLET_PRESSURE,INLET_TEMPERATURE,FUEL_VOLUME_RATE,FUEL_ENERGY_RATE, NAME FROM PV_CoOp" +
                            " WHERE DATE_STAMP >= TO_DATE ('" + startdate + "', 'YYYY-MM-DD HH24:MI:SS') AND DATE_STAMP < TO_DATE ('" + enddate + "', 'YYYY-MM-DD HH24:MI:SS')) Y " +
                            "WHERE Y.RNK = 1" + "";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        PV_CoOp item = new PV_CoOp();
                        while (rdr.Read())
                        {
                            item = new PV_CoOp();
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
                            if (rdr[19] != DBNull.Value) { item.PRESSURE = Convert.ToSingle(rdr[19]); }
                            if (rdr[20] != DBNull.Value) { item.TEMPERATURE = Convert.ToSingle(rdr[20]); }
                            if (rdr[21] != DBNull.Value) { item.MOISTURE = Convert.ToSingle(rdr[21]); }
                            if (rdr[22] != DBNull.Value) { item.ENERGY_RATE = Convert.ToSingle(rdr[22]); }
                            if (rdr[23] != DBNull.Value) { item.VOLUME_RATE = Convert.ToSingle(rdr[23]); }
                            if (rdr[24] != DBNull.Value) { item.INLET_PRESSURE = Convert.ToSingle(rdr[24]); }
                            if (rdr[25] != DBNull.Value) { item.INLET_TEMPERATURE = Convert.ToSingle(rdr[25]); }
                            if (rdr[26] != DBNull.Value) { item.FUEL_VOLUME_RATE = Convert.ToSingle(rdr[26]); }
                            if (rdr[27] != DBNull.Value) { item.FUEL_ENERGY_RATE = Convert.ToSingle(rdr[27]); }
                            if (rdr[28] != DBNull.Value) { item.NAME = Convert.ToString(rdr[28]); }

                            GasCoOpList.Add(item);

                        }

                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                    
                }
            }
            return GasCoOpList;
        }

        public List<PV_CoOp> GetGasCoOpByDateId(int id, string startdate, string enddate)
        {
            List<PV_CoOp> GasCoOpList = new List<PV_CoOp>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select * from PV_CoOp where ASSET_ID = " + id + " and DATE_STAMP>= TO_DATE('" + startdate + "','YYYY-MM-DD HH24:MI:SS') " +
                            "and DATE_STAMP < TO_DATE('" + enddate + "','YYYY-MM-DD HH24:MI:SS') " + "";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        PV_CoOp item = new PV_CoOp();
                        while (rdr.Read())
                        {
                            item = new PV_CoOp();
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
                            if (rdr[19] != DBNull.Value) { item.PRESSURE = Convert.ToSingle(rdr[19]); }
                            if (rdr[20] != DBNull.Value) { item.TEMPERATURE = Convert.ToSingle(rdr[20]); }
                            if (rdr[21] != DBNull.Value) { item.MOISTURE = Convert.ToSingle(rdr[21]); }
                            if (rdr[22] != DBNull.Value) { item.ENERGY_RATE = Convert.ToSingle(rdr[22]); }
                            if (rdr[23] != DBNull.Value) { item.VOLUME_RATE = Convert.ToSingle(rdr[23]); }
                            if (rdr[24] != DBNull.Value) { item.INLET_PRESSURE = Convert.ToSingle(rdr[24]); }
                            if (rdr[25] != DBNull.Value) { item.INLET_TEMPERATURE = Convert.ToSingle(rdr[25]); }
                            if (rdr[26] != DBNull.Value) { item.FUEL_VOLUME_RATE = Convert.ToSingle(rdr[26]); }
                            if (rdr[27] != DBNull.Value) { item.FUEL_ENERGY_RATE = Convert.ToSingle(rdr[27]); }
                            if (rdr[28] != DBNull.Value) { item.NAME = Convert.ToString(rdr[28]); }

                            GasCoOpList.Add(item);

                        }
                    }
                    catch (Exception ex) 
                    
                    {
                        Message = ex.Message;
                    }
                }
            }
            return GasCoOpList;
        }

        public List<Pivot_CoOp> GetGasCoOpByDateIdPivot(int id, string startdate, string enddate)
        {
            List<Pivot_CoOp> GasCoOpList = new List<Pivot_CoOp>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "select * from PV_CoOp unpivot(value for asset_property in (" + "\"" + "C1" + "\"" + "," + "\"" + "C2" + "\"" + "," + "\"" + "C3" + "\"" + "," + "\"" + "IC4" + "\"" + "," + "\"" + "NC4" + "\"" + "," + "\"" + "IC5" + "\"" + "," + "\"" + "NC5" + "\"" + "," + "\"" + "C6" + "\"" + "," + "\"" + "C7" + "\"" + "," + "\"" + "C8" + "\"" + "," + "\"" + "C9" + "\"" + "," + "\"" + "N2" + "\"" + "," + "\"" + "CO2" + "\"" + "," + "\"" + "H20" + "\"" + "," + "\"" + "HCDP" + "\"" + "," + "\"" + "CALC_HCDP" + "\"" + "," + "\"" + "GHV" + "\"" + "," + "\"" + "PRESSURE" + "\"" + "," + "\"" + "TEMPERATURE" + "\"" + "," + "\"" + "MOISTURE" + "\"" + "," + "\"" + "ENERGY_RATE" + "\"" + "," + "\"" + "VOLUME_RATE" + "\"" + "," + "\"" + "INLET_PRESSURE" + "\"" + "," + "\"" + "INLET_TEMPERATURE" + "\"" + "," + "\"" + "FUEL_VOLUME_RATE" + "\"" + "," + "\"" + "FUEL_ENERGY_RATE" + "\"" + ") ) u " +
                            "where ASSET_ID = " + id + " and DATE_STAMP>= TO_DATE('" + startdate + "','YYYY-MM-DD HH24:MI:SS') " +
                            "and DATE_STAMP < TO_DATE('" + enddate + "','YYYY-MM-DD HH24:MI:SS') " + "";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        Pivot_CoOp item = new Pivot_CoOp();
                        while (rdr.Read())
                        {
                            item = new Pivot_CoOp();
                            if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]); }
                            if (rdr["DATE_STAMP"] != DBNull.Value) { item.DATE_STAMP = (DateTime)rdr["DATE_STAMP"]; }
                            if (rdr["NAME"] != DBNull.Value) { item.NAME = Convert.ToString(rdr["NAME"]); }
                            if (rdr["ASSET_PROPERTY"] != DBNull.Value) { item.ASSET_PROPERTY = Convert.ToString(rdr["ASSET_PROPERTY"]); }
                            if (rdr["VALUE"] != DBNull.Value) { item.VALUE = Convert.ToSingle(rdr["VALUE"]); }
                           
                            GasCoOpList.Add(item);

                        }
                    }
                    catch (Exception ex)

                    {
                        Message = ex.Message;
                    }
                }
            }
            return GasCoOpList;
        }


        public List<PV_CoOp> GetAllId()
        {
            List<PV_CoOp> GasCoOpList = new List<PV_CoOp>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Select distinct asset_id from PV_CoOp ORDER BY 1" + "";
                        OracleDataReader rdr = cmd.ExecuteReader();
                        PV_CoOp item = new PV_CoOp();
                        while (rdr.Read())
                        {
                            item = new PV_CoOp();
                            if (rdr["ASSET_ID"] != DBNull.Value) { item.ASSET_ID = Convert.ToInt32(rdr["ASSET_ID"]); }
                            GasCoOpList.Add(item);

                        }
                    }
                    catch (Exception ex)

                    {
                        Message = ex.Message;
                    }
                }
            }
            return GasCoOpList;
        }
    }
}



