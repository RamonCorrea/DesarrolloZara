using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public string Empresa;
        public string CentroCosto;

        protected void btnPlaniTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlanificaTurno.aspx");
        }

        protected void btnAsistencia_Click(object sender, EventArgs e)
        {
          Response.Redirect("ReporteAsistencia.aspx");
        }

    }
}