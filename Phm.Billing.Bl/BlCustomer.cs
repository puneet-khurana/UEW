using Phm.Billing.Cdo;
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
    public class BlCustomer
    {
        public int AddCustomer(CdoCustomer customer)
        {
            Logger.LogInfo("Enters BlCustomer_InsertCustomer");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@Name", customer.Name),
                new SqlParameter("@Location", customer.Location),
                new SqlParameter("@Address", customer.Address),
                new SqlParameter("@Email", customer.Email),
                new SqlParameter("@Phone", customer.Phone),
                new SqlParameter("@TinNo", customer.TinNo),
            };
            var customerId = BlUtil.ExecuteScalar("usp_InsertCustomer", parameters);
            Logger.LogInfo("Exits BlCustomer_InsertCustomer");
            return customerId;
        }

        public int UpdateCustomer(CdoCustomer customer)
        {
            Logger.LogInfo("Enters BlCustomer_UpdateCustomer");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@CustomerId", customer.Id),
                new SqlParameter("@Name", customer.Name),
                new SqlParameter("@Location", customer.Location),
                new SqlParameter("@Address", customer.Address),
                new SqlParameter("@Email", customer.Email),
                new SqlParameter("@Phone", customer.Phone),
                new SqlParameter("@TinNo", customer.TinNo),
            };
            var customerId = BlUtil.ExecuteScalar("usp_UpdateCustomer", parameters);
            Logger.LogInfo("Exits BlCustomer_UpdateCustomer");
            return customerId;
        }

        public int DeleteCustomer(int customerId)
        {
            Logger.LogInfo("Enters BlCustomer_DeleteCustomer");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@CustomerId", customerId),
            };
            var rowsAffected = BlUtil.ExecuteNonQuery("usp_DeleteCustomer", parameters);
            Logger.LogInfo("Exits BlCustomer_DeleteCustomer");
            return rowsAffected;
        }

        public DataSet GetCustomer(int? id = null)
        {
            Logger.LogInfo("Enters BlCustomer_GetCustomer");
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@CustomerId", id)
            };
            var customer = BlUtil.ExecuteDataset("usp_GetCustomer", parameters);
            Logger.LogInfo("Exits BlCustomer_GetCustomer");
            return customer;
        }
    }
}
