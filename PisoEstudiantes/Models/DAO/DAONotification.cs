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
    public class DAONotification : INotifaction
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

        public void createNotification(Notification n)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {
                c.Open();
                SqlCommand comm = new SqlCommand("Insert Into [dbo].[Notification](message,checked,user_email) VALUES (@message,@check,@user)", c);
                comm.Parameters.AddWithValue("@message", n.Message);
                comm.Parameters.AddWithValue("@check", n.Check);
                comm.Parameters.AddWithValue("@user", n.User);
                comm.ExecuteNonQuery();

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

        public void updateNotification(Notification n)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {

                c.Open();

                SqlCommand comm = new SqlCommand("Update [dbo].[Notification] set checked=@check where Id=@id", conn);
                comm.Parameters.AddWithValue("@id", n.ID);
                comm.Parameters.AddWithValue("@check", n.Check);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                c.Close();
            }
        }
    }
}