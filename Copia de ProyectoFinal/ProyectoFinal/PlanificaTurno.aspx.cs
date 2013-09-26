using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BasicFrame.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace ProyectoFinal
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private int estado;
        protected void Page_Load(object sender, EventArgs e)
        {
            /* PERMITE COMPROBAR SI LA PAGINA YA ENVIO EL ESTADO A BusquedaUsuario.aspx */
            if (Request.QueryString["state"] == null)
            {
                estado = 0;
            }
            else
            {
                estado = Convert.ToInt32(Request.QueryString["state"]);
            }
           
            /* TOMA LOS VALORES PASADOS POR URL DE BusquedaUsuario.aspx */
            txtCodigo_emple.Text = Request.QueryString["codigo"];
            txtFecha.Text = Request.QueryString["fecha"];
            lblNombre.Text = Request.QueryString["nombre"] + " " + Request.QueryString["ape_pa"] + " " + Request.QueryString["ape_mat"];
            
            if (estado == 1)
            {
                DropDownList3.SelectedIndex = Convert.ToInt32(Request.QueryString["indi"]);
                estado = 0;
            }
            
            lblDato.Text = DropDownList3.SelectedValue;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Server.Transfer("BusquedaUsuario.aspx?agrupacion=" + lblDato.Text + "&fecha=" + Session["fecha"].ToString() + "&indice=" + Session["indice"].ToString() + "&estado=" + Session["estado1"].ToString());
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            Session["fecha"] = txtFecha.Text;
        }

        protected void DropDownList3_SelectedIndexChanged1(object sender, EventArgs e)
        {
            /* SE OBTIENE EL INDICE DEL ELEMENTO SELECIONADO */
            lblDato.Text = DropDownList3.SelectedValue;
            estado = 1;
            Session["estado1"] = estado;
            Session["indice"] = DropDownList3.SelectedIndex;
        }


        /* FUNCION QUE SE ENCARGA DE CREAR Y LLENAR LA TABLA */
        public void LlenaTabla()
        {
            TrabajoDeFecha myfecha = new TrabajoDeFecha(Session["fecha"].ToString());
            ArrayList datos = myfecha.CantidadDiaMes();
            AsignarPrimerDia(datos[1].ToString(), Convert.ToInt32(datos[0].ToString()));
        }

        /* FUNCION QUE SE ENCARGA DEL LLENADO DE LA TABLA, COLOCANDO TANTO LOS TURNOS COMO LOS DIAS CORRESPONDIENTES 
         * AL MES EN CURSO */
        public void AsignarPrimerDia(string primerDia, int cantiDias)
        {
            /* ESTADO CONTROLA SI YA SE HA ESTABLECIDO EL PRIMER DIA, 0 SIGNIFICA QUE TODAVIA NO SE HA ESTABLECIDO */
            int contador = 1;
            int estadoInicial = 0;

            for (int i = 0; i < 7; i++)
            {
                TableRow fila = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    /* ESTABLECE EL PRIMER DIA DEL MES */
                    if (primerDia == ListaUsuario.Rows[0].Cells[j].Text && estadoInicial == 0)
                    {
                        TableCell celda = new TableCell();
                        celda.Text = "1";
                        fila.Cells.Add(celda);
                        estadoInicial = 1;
                    }
                    /* DEJA CON EL TEXTO VACIO LA CELDA SI TODAVIA NO SE HA ESTABLECIDO EL PRIMER DIA */
                    else if (estadoInicial == 0)
                    {
                        TableCell celda = new TableCell();
                        celda.Text = "Vacio";
                        fila.Cells.Add(celda);
                    }
                    /* DEJA EN VACIO TODOS LOS DIAS CORRESPONDIENTES AL MES SGT */
                    else if (contador >= cantiDias)
                    {
                        TableCell celda = new TableCell();
                        celda.Text = "Vacio";
                        fila.Cells.Add(celda);
                    }
                    /* DEJA COMO TEXTO EL CONTADOR EL CUAL MANTIENE EL NUMERO DE DIAS MAXIMOS DEL MES */
                    else
                    {
                        contador = contador + 1;
                        TableCell celda = new TableCell();
                        celda.Text = Convert.ToString(contador);
                        fila.Cells.Add(celda);
                    }
                }
                ListaUsuario.Rows.Add(fila);
            }
        }

        protected void btnCarga_Click(object sender, EventArgs e)
        {
            LlenaTabla();
            //LlenadoDeTurno();
            //TableCell celda = new TableCell();
            //ListBox lista = new ListBox();
            //celda.Controls.Add(lista);
            //fila.Cells.Add(celda);
        }
    }
}



    
        