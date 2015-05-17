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
    public class DAODate : IDate
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

        public bool createDate(Date date)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {
                c.Open();
                SqlCommand comm = new SqlCommand("Insert Into [dbo].[Date](id_flat,date,owner,user_email) VALUES (@flat,@bookingDate,@owner,@user)", c);
                comm.Parameters.AddWithValue("@flat", date.IDFlat);
                comm.Parameters.AddWithValue("@bookingDate", date.BookingDate);
                comm.Parameters.AddWithValue("@owner", date.IDOwner);
                comm.Parameters.AddWithValue("@user", date.UserEmail);
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
    }
}