using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgePodKartTest
{
    public class DbOperations
    {
        private static DbOperations dbInstance;
        private static SqlConnection connStr;
        public SqlConnection ConnStr {
            get
            {
                string str = ConfigurationManager.AppSettings.Get("ConnectionString");
                return new SqlConnection(str);
            }
            set
            {
                connStr = value;
            }
        }

        //private SqlConnection conn = new SqlConnection(@"Data Source=127.0.0.1;database=urfetdb;User id=urfet;Password=123123;");

        public DbOperations()
        {

        }

        public static DbOperations getDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new DbOperations();
            }
            return dbInstance;
        }

        public SqlConnection GetDBConnection()
        {
            try
            {
                connStr.Open();
            }
            catch (SqlException e)
            {
            }
            finally
            {
            }

            return connStr;
        }

        public bool CheckDbStatus(string cstr)
        {
            var connection = new SqlConnection(cstr);
            bool status = false ;
            try
            {
                using (connection)
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                        status = true;
                }
            }
            catch
            {
                status = false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return status;

        }

        public bool GetDbStatus()
        {
            return (ConnStr != null && ConnStr.State == ConnectionState.Open);
        }

        public bool IsDbExists(string ConnectionString)
        {

            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);

                sqlCreateDBQuery = string.Format(ConnectionString);

                using (connection)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, connection))
                    {
                        connection.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        connection.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;

        }

        public bool IsDbTableExists(string tableName)
        {
            bool exists;

            try
            {
                // ANSI SQL way.  Works in PostgreSQL, MSSQL, MySQL.  
                var cmd = new SqlCommand("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME= '" + tableName + "') SELECT 1 ELSE SELECT 0");
                //var cmd = new SqlCommand("IF EXISTS(SELECT* FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME= '" + Properties.Settings.Default.DBTableName + "') SELECT 1 ELSE SELECT 0");
                exists = (int)cmd.ExecuteScalar() == 1;
            }
            catch
            {
                exists = false;
            }

            return exists;
        }


        public bool InsertData(
            string FirmaKodu = null
           , string UrunStokKodu = null
           , string UrunGrupKodu = null
           , string UrunKodu = null
           , DateTime? UrunUretimTarihi = null
           , bool? Status = null
           , string UrunTestModu = null
           , string UrunTestTipAdi = null
           , string UrunTestEdenKullanici = null
           , DateTime? UrunTestTarihi = null
           , decimal Deger1 = 0
           , decimal Deger2 = 0
           , decimal Deger3 = 0
           , decimal Deger4 = 0
           , decimal Deger5 = 0
           , decimal Deger6 = 0
           , decimal Deger7 = 0
           , decimal Deger8 = 0
        )
        {

            try
            {
                
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO TestVerileri(
                    FirmaKodu
                    ,UrunStokKodu
                    ,UrunGrupKodu
                    ,UrunKodu
                    ,UrunUretimTarihi
                    ,Status
                    ,UrunTestModu
                    ,UrunTestTipAdi
                    ,UrunTestEdenKullanici
                    ,UrunTestTarihi
                    ,Deger1
                    ,Deger2
                    ,Deger3
                    ,Deger4
                    ,Deger5
                    ,Deger6
                    ,Deger7
                    ,Deger8
                    ) VALUES(
                    @prmFirmaKodu
                    ,@prmUrunStokKodu
                    ,@prmUrunGrupKodu
                    ,@prmUrunKodu
                    ,@prmUrunUretimTarihi
                    ,@prmStatus
                    ,@prmUrunTestModu
                    ,@prmUrunTestTipAdi
                    ,@prmUrunTestEdenKullanici
                    ,@prmUrunTestTarihi
                    ,@prmDeger1
                    ,@prmDeger2
                    ,@prmDeger3
                    ,@prmDeger4
                    ,@prmDeger5
                    ,@prmDeger6
                    ,@prmDeger7
                    ,@prmDeger8
                    )", getDbInstance().ConnStr);


                cmd.Parameters.AddWithValue("@prmFirmaKodu", FirmaKodu);
                cmd.Parameters.AddWithValue("@prmUrunStokKodu", UrunStokKodu);
                cmd.Parameters.AddWithValue("@prmUrunGrupKodu", UrunGrupKodu);
                cmd.Parameters.AddWithValue("@prmUrunKodu", UrunKodu);
                //cmd.Parameters.AddWithValue("@prmUrunUretimTarihi", UrunUretimTarihi);

                //DateTime uretimTarihi = DateTime.ParseExact(UrunUretimTarihi.Value.ToShortDateString().ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@prmUrunUretimTarihi", UrunUretimTarihi);

                cmd.Parameters.AddWithValue("@prmStatus", Status);
                cmd.Parameters.AddWithValue("@prmUrunTestModu", true);
                cmd.Parameters.AddWithValue("@prmUrunTestTipAdi", UrunTestTipAdi);
                cmd.Parameters.AddWithValue("@prmUrunTestEdenKullanici", UrunTestEdenKullanici);
                //cmd.Parameters.AddWithValue("@prmUrunTestTarihi", UrunTestTarihi);
                //cmd.Parameters.Add("@prmUrunTestTarihi", SqlDbType.DateTime).Value = UrunTestTarihi;
                //string testTarihi = UrunTestTarihi.Value.ToString("yyyy-MM-dd hh:mm:ss");
                //DateTime uretimTarihi = DateTime.ParseExact(UrunUretimTarihi.Value.ToShortDateString().ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@prmUrunTestTarihi", UrunTestTarihi);

                cmd.Parameters.AddWithValue("@prmDeger1", Deger1);
                cmd.Parameters.AddWithValue("@prmDeger2", Deger2);
                cmd.Parameters.AddWithValue("@prmDeger3", Deger3);
                cmd.Parameters.AddWithValue("@prmDeger4", Deger4);
                cmd.Parameters.AddWithValue("@prmDeger5", Deger5);
                cmd.Parameters.AddWithValue("@prmDeger6", Deger6);
                cmd.Parameters.AddWithValue("@prmDeger7", Deger7);
                cmd.Parameters.AddWithValue("@prmDeger8", Deger8);

            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                return false;
            }

            if(cmd.Connection.State != ConnectionState.Closed )
                cmd.Connection.Close();

            return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
        
}
