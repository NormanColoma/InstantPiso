﻿using PisoEstudiantes.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DAO
{
    public class DAOSchedule : ISchedule
    {
        private string bdConnection = ConfigurationManager.ConnectionStrings["database"].ConnectionString;
        //Instancia de la conexión a la BD.
        private SqlConnection conn = null;

        //SqlCommand será el encargado de ejecutar la sentencia SQL.
        private SqlCommand comm;

        /*DataSet es un elemento donde almacenaremos los resultados de la consulta SQL, 
        para posteriormente poder tratar los datos según nos convenga.*/
        private DataSet ds = new DataSet();

        //Adaptador que contendrá el DataSet.
        private SqlDataAdapter da;

        //DataTable es un elmento tipo tabla.
        private DataTable t = new DataTable();

        public bool createSchedule(Schedule s)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {
                c.Open();
                SqlCommand comm = new SqlCommand("Insert Into [dbo].[Schedule](day,hour,id_flat) VALUES (@day,@hour,@flat)", c);
                comm.Parameters.AddWithValue("@day", s.Day);
                comm.Parameters.AddWithValue("@hour", s.Hour);
                comm.Parameters.AddWithValue("@flat", s.IDFlat);
                int result = comm.ExecuteNonQuery();
                if (result == 1)
                    return true;
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                c.Close();
            }
        }

        public bool deleteSchedule(int id)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {

                c.Open();

                SqlCommand comm = new SqlCommand("Delete From [dbo].[Schedule] where id=@id", c);
                comm.Parameters.AddWithValue("@id", id);
                int result = comm.ExecuteNonQuery();
                if (result == 1)
                    return true;
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                c.Close();
            }
        }  

       
    }
}