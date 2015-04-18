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
    public class DAOFlat: IFlat
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

        public List<Flat> getFlatsByProvince(string province)
        {
            /*Usaremos un bloque try/catch para comprobar si el nombre y contraseña del usuario 
            existe en nuestra base de datos, de lo contrario devolveremos false.*/
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT * FROM [dbo].[Flat] where province = '" + province + "'", conn);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Flats");
                List<Flat> flats = new List<Flat>();
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Flats"];
                for (int i = 0; i < t.Rows.Count; i++)
                {

                    Flat f = new Flat(Convert.ToInt16(t.Rows[i]["id"]), t.Rows[i]["province"].ToString(), t.Rows[i]["city"].ToString(), t.Rows[i]["postal_code"].ToString(),
                    t.Rows[i]["address"].ToString(), t.Rows[i]["capacity"].ToString(), t.Rows[i]["description"].ToString(), null, t.Rows[i]["profile_img"].ToString(),
                    t.Rows[i]["img1"].ToString(), t.Rows[i]["img2"].ToString(), t.Rows[i]["img3"].ToString(), t.Rows[i]["img4"].ToString(), t.Rows[i]["img5"].ToString(),
                    t.Rows[i]["img6"].ToString(), t.Rows[i]["img7"].ToString(),Convert.ToDouble(t.Rows[i]["price"]));
                    flats.Add(f);
                }
                return flats;

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

        public List<Flat> getLastFlats()
        {
            /*Usaremos un bloque try/catch para comprobar si el nombre y contraseña del usuario 
            existe en nuestra base de datos, de lo contrario devolveremos false.*/
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT TOP(10) * FROM [dbo].[Flat]", conn);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Flats");
                List<Flat> flats = new List<Flat>();
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Flats"];
                for (int i = 0; i < t.Rows.Count; i++)
                {

                    Flat f = new Flat(Convert.ToInt16(t.Rows[i]["id"]), t.Rows[i]["province"].ToString(), t.Rows[i]["city"].ToString(), t.Rows[i]["postal_code"].ToString(),
                    t.Rows[i]["address"].ToString(), t.Rows[i]["capacity"].ToString(), t.Rows[i]["description"].ToString(), null, t.Rows[i]["profile_img"].ToString(),
                    t.Rows[i]["img1"].ToString(), t.Rows[i]["img2"].ToString(), t.Rows[i]["img3"].ToString(), t.Rows[i]["img4"].ToString(), t.Rows[i]["img5"].ToString(),
                    t.Rows[i]["img6"].ToString(), t.Rows[i]["img7"].ToString(), Convert.ToDouble(t.Rows[i]["price"]));
                    flats.Add(f);
                }
                return flats;

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