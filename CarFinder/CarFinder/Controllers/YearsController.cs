using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarFinder.Controllers
{
    public class YearsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        //Get api/years
        public IEnumerable<string> Get(string make, string model)
        {
            List<string> retval = new List<string>();
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetYearsByMakeAndModel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);
                rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    retval.Add(rdr["model_year"].ToString());
                }

                //close the connection and reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return retval.ToArray<string>();
        }

    }
}
