using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

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

            ArrayList Datos = new ArrayList();
            Datos.Add(CantidadDias);
            Datos.Add(FirstDay);
            Datos.Add(LastDay);
            Datos.Add(PrimerDia);
            Datos.Add(UltimoDia);

            return Datos;
        }
    }
}

/* -------------------------------------------------------------------- */
/* for (int i = 0; i < Lista.Count; i++)
            {
                Console.WriteLine(Lista[i]);
            }
*/