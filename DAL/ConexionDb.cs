﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace DAL
{
    public class ConexionDb
    {
        //todo:forma correcta de leer el ConnectionString
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        /// <summary>
        /// para ejecutar todos los codigos
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public bool EjecutarDB(string Codigo)
        {
            bool mensaje = false;
            SqlCommand cmd = new SqlCommand();


            try
            {
                con.Open(); // abrimos la conexion
                //MessageBox.Show("Conexion abierta");

                cmd.Connection = con; //asignamos la conexion
                cmd.CommandText = Codigo;     //asignamos el comando
                cmd.ExecuteNonQuery(); // ejecutamos el comando
                mensaje = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                con.Close(); //cerramos la conexion
                // MessageBox.Show("Conexion cerrada");

            }
            return mensaje;
        }

        public DataTable BuscarDb(string comando)
        {
            SqlDataAdapter adp;
            DataTable dt = new DataTable();
            try
            {
                con.Open(); // abrimos la conexion
                adp = new SqlDataAdapter(comando, con);

                adp.Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close(); //cerramos la conexion

            }
            return dt;
        }

        public Object ObtenerValorDb(string escalar)
        {
            con.Open();
            SqlCommand com = new SqlCommand(escalar, con);
            Object objeto = com.ExecuteScalar();
            con.Close();
            return objeto;
        }

        public SqlDataReader DataReader(string comando)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                con = null;
                throw;
            }
            cmd = new SqlCommand(comando, con);
            return cmd.ExecuteReader();
        }

        public void Desconectar()
        {
            if (con.State == ConnectionState.Open || con.State == ConnectionState.Executing)
            {
                con.Close();
            }
        }
    }
}
