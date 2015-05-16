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

        public bool deleteFlat(int id)
        {
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                comm = new SqlCommand("DELETE FROM [dbo].[Flat] WHERE id = @id", conn);
                comm.Parameters.AddWithValue("@id", id);
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
                SqlCommand comm = new SqlCommand("Update [dbo].[Flat] set province=@province , city=@city, postal_code=@pc , address=@addr, description=@desc, tittle=@tittle, bedrooms=@bed, profile_img=@img, price=@price, bathrooms=@bath, available_bedrooms=@ab, minimum_stay=@minimum, property_type=@pt, availableDate=@date where Id=@id", conn);
                comm.Parameters.AddWithValue("@city", f.City);
                comm.Parameters.AddWithValue("@province", f.Province);
                comm.Parameters.AddWithValue("@pc", f.PC);
                comm.Parameters.AddWithValue("@addr", f.Address);
                comm.Parameters.AddWithValue("@desc", f.Description);
                comm.Parameters.AddWithValue("@tittle", f.Tittle);
                comm.Parameters.AddWithValue("@bed", f.Bedrooms);
                comm.Parameters.AddWithValue("@img", f.Profile);
                comm.Parameters.AddWithValue("@price", f.Price);
                comm.Parameters.AddWithValue("@bath", f.Bathrooms);
                comm.Parameters.AddWithValue("@ab", f.AvailableBedrooms);
                comm.Parameters.AddWithValue("@minimum", f.Minimum);
                comm.Parameters.AddWithValue("@pt", f.PropertyType);
                comm.Parameters.AddWithValue("@date", f.AvailableDate);
                comm.Parameters.AddWithValue("@id", f.ID);
                conn.Open();
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

        public List<Flat> getLastFlats()
        {
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT TOP(6) * FROM [dbo].[Flat]", conn);
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


        public Flat getFlat(int id)
        {
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT * FROM [dbo].[Flat] where Id = @id", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Flat");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Flat"];
                Owner owner = new Owner();
                owner.Email = t.Rows[0]["owner"].ToString();
                Flat f = new Flat(t.Rows[0]["province"].ToString(), t.Rows[0]["city"].ToString(), t.Rows[0]["postal_code"].ToString(), t.Rows[0]["address"].ToString(), t.Rows[0]["description"].ToString(),
                t.Rows[0]["tittle"].ToString(), Convert.ToInt16(t.Rows[0]["bedrooms"]), owner, t.Rows[0]["profile_img"].ToString(), Convert.ToDouble(t.Rows[0]["price"]), Convert.ToInt16(t.Rows[0]["bathrooms"]), Convert.ToInt16(t.Rows[0]["available_bedrooms"]), Convert.ToInt16(t.Rows[0]["minimum_stay"]),
                t.Rows[0]["property_type"].ToString(), Convert.ToDateTime(t.Rows[0]["availableDate"].ToString()));
                return f;

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