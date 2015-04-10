using CarFinder.Models;
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
    public class CarsController : ApiController
    {
        private SqlConnection conn = null;
        private SqlDataReader rdr = null;

        //Get api/cars
        public IEnumerable<Car> GetCarMake(string make)
        {
            List<Car> retval = new List<Car>();
            //connection string in the braces below
            //db.Execute ("AddCar", new{ Year="2015", Make= "Chevy", Model= "Tahoe"})
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("GetCarsByMake", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", make);
                //if (!String.IsNullOrEmpty(model) && year == 0)
                //{
                //    cmd = new SqlCommand("GetCarsByMakeAndModel", conn);
                //}
                //if (String.IsNullOrEmpty(trim))
                //{
                //    cmd = new SqlCommand("GetCarsByMakeModelAndYear", conn);
                //}
                //else if (String.IsNullOrEmpty(trim)) { cmd = new SqlCommand("GetCarsByYearMakeModelAndTrim", conn);}
                
                
                
                //cmd.Parameters.AddWithValue("@model", model);
                //cmd.Parameters.AddWithValue("@year", year);
                //cmd.Parameters.AddWithValue("@trim", trim);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(new Car
                    {
                        Make = rdr["make"].ToString(),
                        Model = rdr["model_name"].ToString(),
                        Year = rdr["model_year"].ToString(),
                        Trim = rdr["model_trim"].ToString(),
                        BodyType = rdr["body_style"].ToString(),
                        EnginePosition = rdr["engine_position"].ToString(),
                        EngineCylinder = rdr["engine_num_cyl"].ToString(),
                        EngineType = rdr["engine_type"].ToString(),
                        EnginePowerRPM = rdr["engine_power_rpm"].ToString(),
                        EngineTorqueRPM = rdr["engine_torque_rpm"].ToString(),
                        EngineFuel = rdr["engine_fuel"].ToString(),
                        FuelCapacity = rdr["fuel_capacity_l"].ToString(),
                        TopSpeed = rdr["top_speed_kph"].ToString(),
                        Transmission = rdr["transmission_type"].ToString(),
                        Seats = rdr["seats"].ToString(),
                        Doors = rdr["doors"].ToString(),
                        Weight = rdr["weight_kg"].ToString(),
                        Height = rdr["height_mm"].ToString(),
                        Width = rdr["width_mm"].ToString(),
                        Length = rdr["length_mm"].ToString()
                    });                        
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
            return retval.ToArray<Car>();
        }

        public IEnumerable<Car> GetCarMakeAndModel(string make, string model)
        {
            List<Car> retval = new List<Car>();
            using (conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=HCL2;Integrated Security=true"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCarsByMakeAndModel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(new Car
                    {
                        Make = rdr["make"].ToString(),
                        Model = rdr["model_name"].ToString(),
                        Year = rdr["model_year"].ToString(),
                        Trim = rdr["model_trim"].ToString(),
                        BodyType = rdr["body_style"].ToString(),
                        EnginePosition = rdr["engine_position"].ToString(),
                        EngineCylinder = rdr["engine_num_cyl"].ToString(),
                        EngineType = rdr["engine_type"].ToString(),
                        EnginePowerRPM = rdr["engine_power_rpm"].ToString(),
                        EngineTorqueRPM = rdr["engine_torque_rpm"].ToString(),
                        EngineFuel = rdr["engine_fuel"].ToString(),
                        FuelCapacity = rdr["fuel_capacity_l"].ToString(),
                        TopSpeed = rdr["top_speed_kph"].ToString(),
                        Transmission = rdr["transmission_type"].ToString(),
                        Seats = rdr["seats"].ToString(),
                        Doors = rdr["doors"].ToString(),
                        Weight = rdr["weight_kg"].ToString(),
                        Height = rdr["height_mm"].ToString(),
                        Width = rdr["width_mm"].ToString(),
                        Length = rdr["length_mm"].ToString()
                    });
                }

                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return retval.ToArray<Car>();
        }

        public IEnumerable<Car> GetCarMakeModelAndYear(string make, string model, int year)
        {
            List<Car> retval = new List<Car>();
            using (conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=HCL2;Integrated Security=true"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCarsByMakeModelAndYear", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@year", year);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(new Car
                    {
                        Make = rdr["make"].ToString(),
                        Model = rdr["model_name"].ToString(),
                        Year = rdr["model_year"].ToString(),
                        Trim = rdr["model_trim"].ToString(),
                        BodyType = rdr["body_style"].ToString(),
                        EnginePosition = rdr["engine_position"].ToString(),
                        EngineCylinder = rdr["engine_num_cyl"].ToString(),
                        EngineType = rdr["engine_type"].ToString(),
                        EnginePowerRPM = rdr["engine_power_rpm"].ToString(),
                        EngineTorqueRPM = rdr["engine_torque_rpm"].ToString(),
                        EngineFuel = rdr["engine_fuel"].ToString(),
                        FuelCapacity = rdr["fuel_capacity_l"].ToString(),
                        TopSpeed = rdr["top_speed_kph"].ToString(),
                        Transmission = rdr["transmission_type"].ToString(),
                        Seats = rdr["seats"].ToString(),
                        Doors = rdr["doors"].ToString(),
                        Weight = rdr["weight_kg"].ToString(),
                        Height = rdr["height_mm"].ToString(),
                        Width = rdr["width_mm"].ToString(),
                        Length = rdr["length_mm"].ToString()
                    });
                }

                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return retval.ToArray<Car>();
        }

        public IEnumerable<Car> GetCarMakeModelYearAndTrim(string make, string model, int year, string trim)
        {
            List<Car> retval = new List<Car>();
            using (conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=HCL2;Integrated Security=true"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetCarsByYearMakeModelAndTrim", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@trim", trim);

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    retval.Add(new Car
                    {
                        Make = rdr["make"].ToString(),
                        Model = rdr["model_name"].ToString(),
                        Year = rdr["model_year"].ToString(),
                        Trim = rdr["model_trim"].ToString(),
                        BodyType = rdr["body_style"].ToString(),
                        EnginePosition = rdr["engine_position"].ToString(),
                        EngineCylinder = rdr["engine_num_cyl"].ToString(),
                        EngineType = rdr["engine_type"].ToString(),
                        EnginePowerRPM = rdr["engine_power_rpm"].ToString(),
                        EngineTorqueRPM = rdr["engine_torque_rpm"].ToString(),
                        EngineFuel = rdr["engine_fuel"].ToString(),
                        FuelCapacity = rdr["fuel_capacity_l"].ToString(),
                        TopSpeed = rdr["top_speed_kph"].ToString(),
                        Transmission = rdr["transmission_type"].ToString(),
                        Seats = rdr["seats"].ToString(),
                        Doors = rdr["doors"].ToString(),
                        Weight = rdr["weight_kg"].ToString(),
                        Height = rdr["height_mm"].ToString(),
                        Width = rdr["width_mm"].ToString(),
                        Length = rdr["length_mm"].ToString()
                    });
                }

                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return retval.ToArray<Car>();
        }
    }
}
