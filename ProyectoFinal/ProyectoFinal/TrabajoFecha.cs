using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFinal
{
    class TrabajoDeFecha
    {
        private DateTime Fecha;
        private string CantidadDias;
        private string FirstDay;
        private string LastDay;


        /* CONSTRUCTOR DE LA CLASE */
        public TrabajoDeFecha(string fechaIn)
        {
            this.Fecha = Convert.ToDateTime(fechaIn);
        }

        /* CONSTRUCTOR ESPECIAL, PARA PODER ACCERDER A LAS FUNCIONES DE LA CLASE SIN NECESITAR FECHA DE INICIO */
        public TrabajoDeFecha()
        {
            this.Fecha = DateTime.Today;
        }

        public ArrayList CantidadDiaMes()
        {

            /* FUNCION LA CUAL PERMITE DEVUELVE EL DIA DE LA SEMANA DE UN FECHA DETERMINADA 
             * Y EL ULTIMO DEL MES EN BASE A FECHA INGRESADA POR PARAMETRO */

            Hashtable Dias = new Hashtable();
            Dias.Add("Monday", "Lunes");
            Dias.Add("Tuesday", "Martes");
            Dias.Add("Wednesday", "Miercoles");
            Dias.Add("Thursday", "Jueves");
            Dias.Add("Friday", "Viernes");
            Dias.Add("Saturday", "Sabado");
            Dias.Add("Sunday", "Domingo");

            int AñoActual = Fecha.Year;
            int MesSiguiente = Fecha.Month + 1;
            DateTime PrimerDia;
            DateTime UltimoDia;
            string cadena1;
            string cadena2;

            /* ESTA FUNCION PERMITE CALCULAR LA CANTIDAD DE DIAS QUE TIENE UN MES, EN BASE ALA FECHA PASADA COMO PARAMETRO
                 * ESTA HACE AVANZAR LA FECHA PASADA COMO PARAMETRO AL MES SIGUIENTE, PARA LUEGO RESTARLE 1 PARA ASI OBTENER EL ULTIMO
                 * DIA DEL MES */
            
            if (MesSiguiente == 13)
            {
                /* FUNCION ESPECIAL CUANDO SE EXCEDE EL MAXIMO DE CANTIDAD DE MES  */

                MesSiguiente = 1;

                PrimerDia = Convert.ToDateTime("01/" + Fecha.Month + "/" + AñoActual);
                UltimoDia = Convert.ToDateTime("01/" + MesSiguiente + "/" + (AñoActual + 1)).AddDays(-1);

                CantidadDias = UltimoDia.ToString();
                CantidadDias = CantidadDias.Substring(0, 2);
                FirstDay = Convert.ToString(Dias[PrimerDia.DayOfWeek.ToString()]);
                LastDay = Convert.ToString(Dias[UltimoDia.DayOfWeek.ToString()]);

            }
            else
            {
                /* FUNCION NORMAL */

                PrimerDia = Convert.ToDateTime("01/" + Fecha.Month + "/" + AñoActual);
                UltimoDia = Convert.ToDateTime("01/" + MesSiguiente + "/" + AñoActual).AddDays(-1);

                CantidadDias = UltimoDia.ToString();
                CantidadDias = CantidadDias.Substring(0, 2);
                FirstDay = Convert.ToString(Dias[PrimerDia.DayOfWeek.ToString()]);
                LastDay = Convert.ToString(Dias[UltimoDia.DayOfWeek.ToString()]);
            }
            cadena1 = PrimerDia.ToString("dd/MM/yyyy");
            cadena2 = UltimoDia.ToString("dd/MM/yyyy");
            //cadena1 = PrimerDia.ToString("yyyy/MM/dd");
            //cadena2 = UltimoDia.ToString("yyyy/MM/dd");
            ArrayList Datos = new ArrayList();
            Datos.Add(CantidadDias);
            Datos.Add(FirstDay);
            Datos.Add(LastDay);
            Datos.Add(cadena1);
            Datos.Add(cadena2);

            return Datos;
        }

        /* FUNCION LA CUAL PERMITE SACAR LOS TURNOS DE UN EMPLEADO ESPECIFIO Y LOS DEVUELVE EN UN HASHTABLE (CLAVE,VALOR) */
        public ArrayList TurnoEmpleadoPorFecha(string cod_empleado, string fecha_ini, string fecha_fin)
        {
                /* CONEXION A LA BASE DE DATOS Y EJECUCION DE SP */
                ConexionBaseDatos conn = new ConexionBaseDatos();
                string sqlQuery = "EXEC PROC_TURNO_EMPLEADO '" + cod_empleado + "','" + fecha_ini + "','" + fecha_fin + "'";

                /* SE PASA EL RESULTADO DE LA CONSULTA A UN DATATABLE, EL CUAL SE RECORRE PARA SACAR LOS DATOS DEL TURNO (FECHA,COD_TURNO) 
                 * LOS CUALES LUEGO SON GUARDADOS EN UN HASHTABLE */
                DataTable TablaBD = new DataTable();
                SqlDataAdapter ds = new SqlDataAdapter(sqlQuery, conn.AbrirConexion());
                ds.Fill(TablaBD);
                ArrayList TurnoEmpleado = new ArrayList();

                foreach (DataRow rows in TablaBD.Rows)
                {
                    TurnoEmpleado.Add(rows["Fecha"].ToString());
                    TurnoEmpleado.Add(rows["COD_TURNO"].ToString());
                }

                conn.CerrarConexion();
                return TurnoEmpleado;
        }

        /* SE DEVUELVE UN DATATABLE CON TODOS LOS TURNOS CORRESPONDIENTES A LA EMPRESA QUE SE LE PASO POR PARAMETRO */
        public DataTable TurnosEmpresa(string codEmpresa)
        {
            string sqlQuery = "EXEC SP_TURNOS '" + codEmpresa + "'";
            ConexionBaseDatos conn = new ConexionBaseDatos();
            DataTable tabla = new DataTable();
            SqlDataAdapter ds = new SqlDataAdapter(sqlQuery, conn.AbrirConexion());
            ds.Fill(tabla);

            conn.CerrarConexion();
            return tabla;
        }
            
    }
}

