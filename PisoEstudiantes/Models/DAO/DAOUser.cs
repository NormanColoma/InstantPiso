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
    public class DAOUser:IUser
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


        public User getUser(string email)
        {
            
            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT * FROM [dbo].[User] where email = @email", conn);
                da.SelectCommand.Parameters.AddWithValue("@email", email);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "User");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["User"];
                User u = new User(email, t.Rows[0]["name"].ToString(), t.Rows[0]["phone"].ToString(),
                t.Rows[0]["age"].ToString(), t.Rows[0]["leaseholder"].ToString(), t.Rows[0]["surname"].ToString(),
                t.Rows[0]["password"].ToString(), t.Rows[0]["gender"].ToString(), t.Rows[0]["img"].ToString(), t.Rows[0]["city"].ToString());
                return u;

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


        public bool login(User u)
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
                da = new SqlDataAdapter("SELECT email, password FROM [dbo].[User] where email = '" + u.Email + "' and password = '"+ u.Password +"'",conn);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "User");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["User"];
                if (t.Rows.Count == 0)
                    return false;
                if (t.Rows[0]["email"].ToString() == u.Email && t.Rows[0]["password"].ToString() == u.Password)
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

        #region CRUDS

        public bool insertUser(User us)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {
                
                

                c.Open();

                SqlCommand comm = new SqlCommand("Insert Into [dbo].[User](email,name,password,leaseholder,gender,surname,phone,age,city) VALUES ('" + us.Email + "','" + us.Name + "','" + 
                us.Password +"','" + us.Leaseholder + "','" + us.Gender + "','" + us.Surname + "','" + us.Phone + "','" + us.Age + "','"+ us.City + "')", c);

                int result = comm.ExecuteNonQuery();
                if (result == 1)
                    return true;
                return false;
                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally {
                c.Close();
            }
        }


        public bool UpdateUser(User us, string email)
        {
            SqlConnection c = new SqlConnection(bdConnection);
          try
            {
             


                c.Open();

                SqlCommand comm = new SqlCommand("Update [dbo].[User] set name=@nombre , surname=@sur, phone=@phon , password=@pass, leaseholder=@lease, age=@age, gender=@gender, city=@city where email=@omail", c);
                comm.Parameters.AddWithValue("@mail", us.Email);
                comm.Parameters.AddWithValue("@nombre", us.Name);
                comm.Parameters.AddWithValue("@pass", us.Password);
                comm.Parameters.AddWithValue("@omail", email);
                comm.Parameters.AddWithValue("@sur", us.Surname);
                comm.Parameters.AddWithValue("@phon", us.Phone);
                comm.Parameters.AddWithValue("@age", us.Age);
                comm.Parameters.AddWithValue("@gender", us.Gender);
                comm.Parameters.AddWithValue("@lease", us.Leaseholder);
                comm.Parameters.AddWithValue("@city", us.City);
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
        public void BorrarUsuario(User us)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            { 

                c.Open();

                SqlCommand comm = new SqlCommand("Delete From [dbo].[User] where email=@mail", c);
                    comm.Parameters.AddWithValue("@mail",us.Email);
                    comm.ExecuteNonQuery();
                
            }
           catch (Exception ex)
            {

           }
           finally {
               c.Close();
            }
        }    




        #endregion

        public bool checkPassword(User u)
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
                da = new SqlDataAdapter("SELECT password FROM [dbo].[User] where email = '" + u.Email + "'", conn);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "User");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["User"];
                if (t.Rows.Count == 0)
                    return false;
                if (t.Rows[0]["password"].ToString() == u.Password)
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

        public bool insertOwner(Owner owner)
        {
            SqlConnection c = new SqlConnection(bdConnection);
            try
            {



                c.Open();

                SqlCommand comm = new SqlCommand("IF NOT EXISTS(Select user_email from [dbo].[Owner] where user_email = @email)Insert Into [dbo].[Owner](user_email) VALUES (@email)", c);
                comm.Parameters.AddWithValue("@email", owner.Email);
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

        public int getOwnerID(string email)
        {

            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT id FROM [dbo].[Owner] where user_email = @email", conn);
                da.SelectCommand.Parameters.AddWithValue("@email", email);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Owner");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Owner"];
                int id = Convert.ToInt16(t.Rows[0]["id"].ToString());
                return id;

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


        public string getOwnerEmail(int id)
        {

            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT user_email FROM [dbo].[Owner] where Id = @id", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Owner");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Owner"];
                string email = t.Rows[0]["user_email"].ToString();
                return email;

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

        public List<Notification> getNotifications(string email)
        {

            try
            {
                //Creamos instancia y abrimos la conexión de la BD
                conn = new SqlConnection(bdConnection);
                conn.Open();

                /*Realizamos la sentencia SQL y la ejecutamos. Tiene dos parámetros, un string (con la sentencia SQL)
                y una instancia de SqlConnection, para pasarle la conexión.*/
                da = new SqlDataAdapter("SELECT * FROM [dbo].[Notification] where user_email = @email", conn);
                da.SelectCommand.Parameters.AddWithValue("@email", email);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "Notifications");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["Notifications"];
                List<Notification> notifications = new List<Notification>();
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    User u = new User();
                    u.Email = t.Rows[i]["user_email"].ToString();
                    Notification n = new Notification(Convert.ToInt16(t.Rows[i]["Id"].ToString()), t.Rows[i]["message"].ToString(), (bool)t.Rows[i]["checked"],
                    u, Convert.ToInt16(t.Rows[i]["id_flat"].ToString()), t.Rows[i]["type"].ToString());
                    notifications.Add(n);
                }
                    return notifications;

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