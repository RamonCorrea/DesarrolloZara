using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ProyectoFinal
{
    /* CLASE LA CUAL MANEJA CONEXIONES Y OPERACIONES EN LA BASE DE DATOS */ 
    public class ConexionBaseDato
    {
       private SqlConnection conexion;
       private string cadenaConexion;
        
        /* CONSTRUCTOR DE LA CLASE EL CUAL INSTANCIA LA VARIABLE DE CONEXION A LA BASE DATOS */
        public ConexionBaseDato()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
            conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection AbrirConexion()
        {
            conexion.Open();
            return conexion;
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}