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
                da = new SqlDataAdapter("SELECT * FROM [dbo].[User] where email = '" + @email + "'", conn);
                da.SelectCommand.Parameters.AddWithValue("@email", email);
                //Llenamos (fill) el dataset, con el resultado de la consulta SQL almacenado en el DataAdapter.
                da.Fill(ds, "User");
                //Obtenemos las tablas contenidas en el DataSet.
                t = ds.Tables["User"];
                User u = new User(t.Rows[0]["email"].ToString(), t.Rows[0]["name"].ToString(), t.Rows[0]["phone"].ToString(),
                t.Rows[0]["age"].ToString(), t.Rows[0]["leaseholder"].ToString(), t.Rows[0]["surname"].ToString(),
                t.Rows[0]["password"].ToString(), t.Rows[0]["gender"].ToString());
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
    }
}