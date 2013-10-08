using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ProyectoFinal
{
    public partial class BusquedaUsuario : System.Web.UI.Page
    {
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int celda = Convert.ToInt32(GridView1.SelectedIndex.ToString());
            string codigo = GridView1.Rows[celda].Cells[1].Text;
            string nombre = GridView1.Rows[celda].Cells[2].Text;
            string apellidoPa = GridView1.Rows[celda].Cells[3].Text;
            string apellidoMa = GridView1.Rows[celda].Cells[4].Text;
            Server.Transfer("PlanificaTurno.aspx?codigo=" + codigo + "&nombre=" + nombre + "&ape_pa=" + apellidoPa + "&ape_mat=" + apellidoMa + "&indi=" + Session["indi"].ToString() +"&fecha=" + Session["Fecha2"].ToString() + "&state=" + Session["state"].ToString());         
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUnidad.Text = Request.QueryString["agrupacion"];
            Session["Fecha2"] = Request.QueryString["fecha"];
            Session["indi"] = Request.QueryString["indice"];
            Session["state"] = Request.QueryString["estado"];
        }

        
    }
}