using Phm.Billing.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phm.Billing.Bl
{
    public class BlUtil
    {
         private static string connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["BillingConnectionString"].ConnectionString;
        
        public static int ExecuteNonQuery(string command, SqlParameter[] parameters)
        {
            Logger.LogInfo("Enters BlUtil_ExecuteNonQuery");
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand(command);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Connection = conn;
                    comm.Parameters.AddRange(parameters);
                    conn.Open();
                    rowsAffected = comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            finally
            {
                Logger.LogInfo("Exits BlUtil_ExecuteNonQuery");
            }
            return rowsAffected;
        }

        public static int ExecuteScalar(string command, SqlParameter[] parameters)
        {
            Logger.LogInfo("Enters BlUtil_ExecuteScalar");
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand(command);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Connection = conn;
                    comm.Parameters.AddRange(parameters);
                    conn.Open();
                    var result = comm.ExecuteScalar();
                    rowsAffected = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            finally
            {
                Logger.LogInfo("Exits BlUtil_ExecuteScalar");
            }
            return rowsAffected;
        }

        public static DataSet ExecuteDataset(string command, SqlParameter[] parameters)
        {
            Logger.LogInfo("Enters BlUtil_ExecuteDataset");
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    SqlCommand comm = new SqlCommand(command);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Connection = conn;
                    comm.Parameters.AddRange(parameters);
                    conn.Open();
                    
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comm;
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
            }
            finally
            {
                Logger.LogInfo("Exits BlUtil_ExecuteDataset");
            }
            return ds;
        }
    }
}
