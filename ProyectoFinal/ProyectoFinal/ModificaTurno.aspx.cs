using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public partial class ModificaTurno : System.Web.UI.Page
    {
        private static int valor;

        protected void Page_Load(object sender, EventArgs e)
        {
            TrabajoDeFecha fecha = new TrabajoDeFecha();
            DataTable turnosEmpresa = fecha.TurnosEmpresa(Login.Cod_Empresa);
            droTurnos.DataSource = turnosEmpresa;
            droTurnos.DataTextField = "COD_TURNO";
            droTurnos.DataValueField = "COD_TURNO";
            droTurnos.DataBind();

            if (IsPostBack)
            {
                droTurnos.SelectedIndex = valor;
            }

            /* RUTINA LA CUAL PERMITE DEJAR CONFIGURADA LA INSERCION O ACTUALIZACION DEL TURNO */
            txtTurnoEmple.Text = Request.QueryString["val"];
            string diaT = Request.QueryString["dia"];
            string fechaT = Request.QueryString["fecha"];
            txtCodigo.Text = Request.QueryString["codTur"];
            lblNombre2.Text = Request.QueryString["nombre"];
            Session["codi"] = Request.QueryString["Empre"];
            fechaT = fechaT.Remove(0, 2);
            string resul = diaT + fechaT;
            
            //if (txtTurnoEmple.Text == "Sin Turno")
            //{
            //    btnActualizarTurno.Text = "Ingresar";
            //}
           
            if (resul.Length < 10)
            {
                resul = resul.PadLeft(10, '0');
                txtFecha.Text = resul;
            }
            else
            {
                txtFecha.Text = resul;
            }
        }

        protected void btnActualizarTurno_Click(object sender, EventArgs e)
        {
            string RESUL = Session["codi"].ToString();
            string RESUL2 = Session["hola"].ToString();
            ConexionBaseDatos conn = new ConexionBaseDatos();
            string sqlQuery = "EXEC PROC_WEB_UPD_PLANTURNO '" + txtCodigo.Text + "','" + txtFecha.Text + "','" + RESUL+ "','" + RESUL2 + "'";
            SqlCommand comando = new SqlCommand(sqlQuery, conn.AbrirConexion());
        }

        protected void droTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["hola"] = droTurnos.SelectedIndex;
            valor = Convert.ToInt32(Session["hola"].ToString());
        }
    }
}