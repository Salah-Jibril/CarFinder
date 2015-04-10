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
    public class TrimsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        //Get api/years
        public IEnumerable<string> Get(string make, string model, int year)
        {
            List<string> retval = new List<string>();
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetTrimsByYearMakeAndModel", conn);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@year", year);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(rdr["model_trim"].ToString());
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
