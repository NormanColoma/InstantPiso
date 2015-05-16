using PisoEstudiantes.Models.DTO;
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

        public List<Schedule> getSchedule(int id_flat)
        {

            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT * FROM [dbo].[Schedule] where id_flat = @flat", conn);
                da.SelectCommand.Parameters.AddWithValue("@flat", id_flat);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Schedule");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Schedule"];
                List<Schedule> schedule = new List<Schedule>();
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    Schedule s = new Schedule();
                    s.ID = Convert.ToInt16(t.Rows[i]["id"].ToString());
                    s.IDFlat = Convert.ToInt16(t.Rows[i]["id_flat"].ToString());
                    s.Day = t.Rows[i]["day"].ToString();
                    s.Hour = t.Rows[i]["Hour"].ToString();
                    schedule.Add(s);
                }

                return schedule;
                

            }
            catch (SqlException Ex)
            {
                throw Ex;

            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
    }
}