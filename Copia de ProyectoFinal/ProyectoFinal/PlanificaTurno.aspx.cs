using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                Session["CodEmple"] = Request.QueryString["codigo"];
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
            Server.Transfer("BusquedaUsuario.aspx?agrupacion=" + lblDato.Text + "&fecha=" + Session["fecha"].ToString() + "&indice=" + Session["indice"].ToString() + "&estado=" + Session["estado"].ToString());
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
            Session["estado"] = estado;
            Session["indice"] = DropDownList3.SelectedIndex;
        }


        /* FUNCION QUE SE ENCARGA DE CREAR Y LLENAR LA TABLA */
        public void LlenaTabla(string codEmple)
        {
            TrabajoDeFecha myfecha = new TrabajoDeFecha(Session["fecha"].ToString());
            ArrayList datos = myfecha.CantidadDiaMes();
            AsignarPrimerDia(datos[1].ToString(), Convert.ToInt32(datos[0].ToString()), datos[3].ToString(), datos[4].ToString(),codEmple);
        }

        /* FUNCION QUE SE ENCARGA DEL LLENADO DE LA TABLA, COLOCANDO TANTO LOS TURNOS COMO LOS DIAS CORRESPONDIENTES 
         * AL MES EN CURSO */
        public void AsignarPrimerDia(string primerDia, int cantiDias, string fecha_ini, string fecha_fin, string cod_empleado)
        {
            /* ESTADO CONTROLA SI YA SE HA ESTABLECIDO EL PRIMER DIA, 0 SIGNIFICA QUE TODAVIA NO SE HA ESTABLECIDO */
            /* contadorTurnos PERMITE IR EXTRAYENDO LOS TURNOS DEL ARRAYLIST turnoEmpleado */
            int contador = 1;
            int estadoInicial = 0;
            int contadorTurnos = 0;
            TrabajoDeFecha fecha = new TrabajoDeFecha(Session["fecha"].ToString());

            ArrayList turnosEmpleado = fecha.TurnoEmpleadoPorFecha(cod_empleado, fecha_ini, fecha_fin);

            for (int i = 0; i < 7; i++)
            {
                TableRow fila = new TableRow();
                TableRow fila2 = new TableRow();

                for (int j = 0; j < 7; j++)
                {
                    /* ESTABLECE EL PRIMER DIA DEL MES */
                    if ((primerDia == ListaUsuario.Rows[0].Cells[j].Text) && (estadoInicial == 0))
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

                /* RECORRE CELDAS DE LA TABLA COMPARANDO SI EL DIA Y EL DIATURNO SON IGUALES SI ES ASI CREA UNA CELDA LA CUAL TIENE EL
                 * TURNO DEL EMPLEADO, SINO COLOCA SIN TURNO */
                for (int x = 0; x < 7; x++)
                {
                    int rows = ListaUsuario.Rows.Count - 1;

                    /* VERIFICA QUE SE NO SE PRODUSCA UN DESBORDE EN EL ARRAYLIST turnosEmpleado */
                    if (contadorTurnos >= turnosEmpleado.Count)
                    {
                        TableCell celda = new TableCell();
                        celda.Text = "Sin Turno";
                        celda.Font.Bold = true;
                        fila2.Cells.Add(celda);
                    }
                    /* EN CASO DE LA CELDA CORRESPONDIENTE AL DIA DEL MES DIGA Vacio ESTE LO DEJA COMO SIN TURNO */
                    else if (ListaUsuario.Rows[rows].Cells[x].Text == "Vacio")
                    {
                        TableCell celda = new TableCell();
                        celda.Text = "Sin Turno";
                        celda.Font.Bold = true;
                        fila2.Cells.Add(celda);
                    }
                    /* ASIGNA TURNO CUANDO EL DIA DE LA TABLA SE CORRESPONDA CON EL DEL TURNO
                     * SE APLICAN CONVERSIONES A INT PARA PODER REALIZAR COMPARACION */
                    else if (Convert.ToInt32(ListaUsuario.Rows[rows].Cells[x].Text) == Convert.ToInt32(turnosEmpleado[contadorTurnos].ToString()))
                    { 
                        TableCell celda = new TableCell();
                        celda.Text = turnosEmpleado[contadorTurnos + 1].ToString();
                        celda.Font.Bold = true;
                        fila2.Cells.Add(celda);
                        contadorTurnos += 2;
                    }
                    else
                    {
                        TableCell celda = new TableCell();
                        celda.Text = "Sin Turno";
                        celda.Font.Bold = true;
                        fila2.Cells.Add(celda);
                    }     
                }
                /* SE AGREGA FILA2 LA CUAL CONTIENE LAS CELDAS CORRESPONDIENTES A LOS TURNOS */
                ListaUsuario.Rows.Add(fila2);
            }
        }

        protected void btnCarga_Click(object sender, EventArgs e)
        {
            LlenaTabla(Session["CodEmple"].ToString());
        }
    }
}



    
        