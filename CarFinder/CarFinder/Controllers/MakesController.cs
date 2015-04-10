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
    public class MakesController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        //Get api/Makes
        public IEnumerable<string> Get()
        {
            List<string> retval = new List<string>();
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetMakes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(rdr["make"].ToString());
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
