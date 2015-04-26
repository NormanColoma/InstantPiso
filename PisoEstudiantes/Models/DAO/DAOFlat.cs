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
                    t.Rows[i]["address"].ToString(), t.Rows[i]["description"].ToString(), t.Rows[i]["capacity"].ToString(), null, t.Rows[i]["profile_img"].ToString(),
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

        public bool insertFlat(Flat f)
        {
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                comm = new SqlCommand("Insert Into [dbo].[Flat] (id,province,city,address,postal_code,capacity,description,owner,profile_img,img1,img2,img3,img4,img5,img6,img7,price) VALUES('" + f.ID + "','" + f.Province + "','" + f.City + "','" + f.Address + "','" + f.PC + "','" + f.Capacity + "','" + f.Description + f.Owner + "','" + f.Profile + "','" + f.IMG1 + "','" + f.IMG2 + "','" + f.IMG3 + "','" + f.IMG4 + "','" + f.IMG5 + "','" + f.IMG6 + "','" + f.IMG7 + "','" + f.Price + "')", conn);
                int result = comm.ExecuteNonQuery();

                if (result == 1)
                    return true;
                return false;



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

        public bool deleteFlat(Flat f)
        {
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                comm = new SqlCommand("DELETE * FROM [dbo].[Flat] WHERE id ='"+f.ID+"'", conn);
                int result = comm.ExecuteNonQuery();
                if (result == 1)
                    return true;
                return false;
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


        public bool updateFlat(Flat f)
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
                comm = new SqlCommand("Update [dbo].[Flat] Set province= '"+f.Province+"' ,city= '"+ f.City+"' ,address= '"+ f.Address+"' ,postal_code= '"+f.PC+"' ,capacity= '"+f.Capacity+"' ,description= '"+f.Description+"' ,owner= '"+f.Owner +"' ,profile_img= '"+f.Profile+"', img1= '"+f.IMG1+"' ,img2= '"+f.IMG2+"' ,img3= '"+f.IMG3+"' ,img4= '"+f.IMG4+"' ,img5= '"+f.IMG5+"' ,img6= '"+f.IMG6+"' ,img7= '"+f.IMG7+"' ,price= '"+f.Price+"' where id='" + f.ID + "'", conn);
                int result = comm.ExecuteNonQuery();

                if (result == 1)
                    return true;
                else
                    return false;
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
                    t.Rows[i]["address"].ToString(), t.Rows[i]["description"].ToString(), t.Rows[i]["capacity"].ToString(), null, t.Rows[i]["profile_img"].ToString(),
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