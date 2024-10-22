using System.Data.SqlClient;
using System.Data;

namespace PMS_BLL.Utility
{
    public class Dg_SqlCommon
    {
        public DataTable get_InformationDataTable(string sqlstatement, SqlConnection sqlCon)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlstatement, sqlCon);
                if (sqlCon.State == ConnectionState.Closed || sqlCon.State == ConnectionState.Broken)
                {
                    sqlCon.Open();
                }
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return dt;
        }
        public DataSet get_InformationDtaset(string sqlstatement, SqlConnection sqlCon)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlstatement, sqlCon);
                if (sqlCon.State == ConnectionState.Closed || sqlCon.State == ConnectionState.Broken)
                {
                    sqlCon.Open();
                }
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return ds;
        }
        public async Task<DataSet> get_InformationDtasetAsync(string sqlstatement, SqlConnection sqlCon)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlstatement, sqlCon);
                if (sqlCon.State == ConnectionState.Closed || sqlCon.State == ConnectionState.Broken)
                {
                    await sqlCon.OpenAsync();
                }
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    await sqlCon.CloseAsync();
                }
            }
            return ds;
        }
        public async Task<DataTable> get_InformationDataTableAsync(string sqlstatement, SqlConnection sqlCon)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sqlstatement, sqlCon);
                if (sqlCon.State == ConnectionState.Closed || sqlCon.State == ConnectionState.Broken)
                {
                    await sqlCon.OpenAsync();
                }
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    await sqlCon.CloseAsync();
                }
            }
            return dt;
        }

      
    }
}
