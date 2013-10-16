using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoFinal
{
    public partial class ModificaTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TrabajoDeFecha fecha = new TrabajoDeFecha();
            DataTable turnosEmpresa = fecha.TurnosEmpresa(Login.Cod_Empresa);
            droTurnos.DataSource = turnosEmpresa;
            droTurnos.DataValueField = "COD_TURNO";
            droTurnos.DataBind();

            txtTurnoEmple.Text = Request.QueryString["val"];
        }
    }
}