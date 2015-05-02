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
                    t.Rows[i]["address"].ToString(), t.Rows[i]["description"].ToString(), Convert.ToInt16(t.Rows[i]["bedrooms"]), null, t.Rows[i]["profile_img"].ToString(),
                    Convert.ToDouble(t.Rows[i]["price"]));
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
                comm = new SqlCommand("Insert Into [dbo].[Flat] (province,city,address,postal_code,bedrooms,description,owner,profile_img,price,bathrooms,available_bedrooms,minimum_stay,availableDate,tittle,property_type) VALUES('"+ f.Province + "','" + f.City + "','" + f.Address + "','" 
                + f.PC + "','" + f.Bedrooms + "','" + f.Description + "','" + f.Owner.Email + "','" + f.Profile + "','" + f.Price + "','" + f.Bathrooms + "','" + f.AvailableBedrooms + "','" + f.Minimum + "','" + f.AvailableDate + "','" + f.Tittle + "','" + f.PropertyType +"')", conn);
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
                /*comm = new SqlCommand("Update [dbo].[Flat] Set province= '"+f.Province+"' ,city= '"+ f.City+"' ,address= '"+ f.Address+"' ,postal_code= '"+f.PC+"' ,capacity= '"+f.Capacity+"' ,description= '"+f.Description+"' ,owner= '"+f.Owner +"' ,profile_img= '"+f.Profile+"', img1= '"+f.IMG1+"' ,img2= '"+f.IMG2+"' ,img3= '"+f.IMG3+"' ,img4= '"+f.IMG4+"' ,img5= '"+f.IMG5+"' ,img6= '"+f.IMG6+"' ,img7= '"+f.IMG7+"' ,price= '"+f.Price+"' where id='" + f.ID + "'", conn);
                int result = comm.ExecuteNonQuery();

                if (result == 1)
                    return true;
                else
                    return false;*/
                return true;
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
                    t.Rows[i]["address"].ToString(), t.Rows[i]["description"].ToString(), Convert.ToInt16(t.Rows[i]["bedrooms"]), null, t.Rows[i]["profile_img"].ToString(),
                    Convert.ToDouble(t.Rows[i]["price"]));
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


        public List<Flat> getFlatsByOwner(string email)
        {
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT * FROM [dbo].[Flat] where owner = '" + @email + "'", conn);
                da.SelectCommand.Parameters.AddWithValue("@email", email);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Flats");
                List<Flat> flats = new List<Flat>();
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Flats"];
                for (int i = 0; i < t.Rows.Count; i++)
                {

                    Flat f = new Flat(Convert.ToInt16(t.Rows[i]["id"]), t.Rows[i]["province"].ToString(), t.Rows[i]["city"].ToString(), t.Rows[i]["postal_code"].ToString(),
                    t.Rows[i]["address"].ToString(), t.Rows[i]["description"].ToString(), Convert.ToInt16(t.Rows[i]["bedrooms"]), null, t.Rows[i]["profile_img"].ToString(),
                    Convert.ToDouble(t.Rows[i]["price"]));
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