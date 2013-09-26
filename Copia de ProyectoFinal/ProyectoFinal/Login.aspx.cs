using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;

namespace ProyectoFinal
{
    public partial class Login : System.Web.UI.Page
    {
        public static int Cod_Empresa;
        public static double Division;

        public string cadena = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ConnectionString;
        
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            /* SE ESTABLECE QUE LA VARIABLES DE TIPO SESION TENDRAN UNA DURACION DE 40 MINUTOS */
            Session.Timeout = 40; 
            if (CompruebaBD(txtUsuario.Text, txtPassword.Text))
            {
                Cod_Empresa = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                Division = Convert.ToDouble(DropDownList2.SelectedItem.Value);
                Session["USUARIO"] = txtUsuario.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, false);
            }
            else
            {
                Mensaje.Text = "USUARIO O CONTRASEÑA INCORRECTA";
            }
        }

        public bool CompruebaBD(string usuario, string pass)
        {
            string ProcedureValue;
            SqlConnection conen;

            try
            {
                /* PROCEDIMIENTO EL CUAL EJECUTA PROCEDIMIENTO ALMACENADO EL CUAL DEVUELVE LA CLAVE DESDE LA BD */
                /* (@"data source = fcanales001; initial catalog =BD_STANDAR_LOGAM; user id = sa; password = sa") 
                   (@"data source = SVRLOGAM2008; initial catalog =BD_STANDAR_LOGAM;Integrated Security=True"); */
                conen = new SqlConnection(cadena);
                conen.Open();

                /* SE ESTABLE TANTO EL NOMBRE DEL SP COMO EL TIEMPO MAXIMO DE ESPERA */
                SqlCommand LlamadaProc = new SqlCommand();
                LlamadaProc.Connection = conen;
                LlamadaProc.CommandType = System.Data.CommandType.StoredProcedure;
                LlamadaProc.CommandText = "SP_VERIFICA_NET";
                LlamadaProc.CommandTimeout = 10;

                /* CREACION Y ASIGNACION DE PARAMATROS PARA EL SP */
                LlamadaProc.Parameters.Add(new SqlParameter("@USUARIO", SqlDbType.VarChar));
                LlamadaProc.Parameters.Add(new SqlParameter("@PASS", SqlDbType.VarChar));

                /* SE DETERMINA CUALES SON LOS PARAMETROS DE ENTRADA Y LOS DE SALIDA */
                LlamadaProc.Parameters["@USUARIO"].Direction = ParameterDirection.Input;
                LlamadaProc.Parameters["@PASS"].Direction = ParameterDirection.Output;
                LlamadaProc.Parameters["@USUARIO"].Value = usuario;
                LlamadaProc.Parameters["@PASS"].Size = 20;

                LlamadaProc.ExecuteScalar();

                ProcedureValue = Convert.ToString(LlamadaProc.Parameters["@PASS"].Value);
            }
            catch (Exception ex)
            {
                Mensaje.Text = ex.ToString();
                return false;
            }
            
            /* SE COMPRUEBA SI LA CLAVE ES IGUAL QUE LA QUE ESTA EN LA BASE DE DATOS */
            if (ProcedureValue == pass)
            {
                conen.Close();
                return true;   
            }
            else
            {
                conen.Close();
                return false;        
            }
        }

        public void CargaCCosto(object sender, EventArgs e)
        {
            int CodEmpresa = Convert.ToInt32(DropDownList1.SelectedItem.Value);


            try
            {
                string sqlquery = "Select UNIDAD_NEGOCIO,DESC_UNIDAD FROM P_UNIDAD_NEGOCIO Where COD_EMPRESA =" + CodEmpresa;
                ConexionBaseDato conn = new ConexionBaseDato();
                DataSet Tablavirtual = new DataSet();

                SqlDataAdapter ds = new SqlDataAdapter(sqlquery, conn.AbrirConexion());
                ds.Fill(Tablavirtual, "P_UNIDAD_NEGOCIO");

                DropDownList2.DataSource = Tablavirtual;
                DropDownList2.DataTextField = "DESC_UNIDAD";
                DropDownList2.DataValueField = "UNIDAD_NEGOCIO";
                DropDownList2.DataBind();
                conn.CerrarConexion();
            }
            catch (Exception ex)
            {
                Mensaje.Text = ex.ToString();
            }
        }
    }
}