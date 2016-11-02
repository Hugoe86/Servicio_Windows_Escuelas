using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Reportes_Planeacion.Escuelas.Negocio;
using SIAC.Metodos_Generales;

namespace Forma_Escuelas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //*******************************************************************************
        //NOMBRE DE LA FUNCIÓN:Btn_Probar_Click
        //DESCRIPCIÓN: Metodo que permite  generar la insercion de la informacion de las escuelas
        //PARAMETROS: 
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 01/Noviembre/2016
        //MODIFICO:
        //FECHA_MODIFICO:
        //CAUSA_MODIFICACIÓN:
        //*******************************************************************************
        private void Btn_Probar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultar_Informacion();
                MessageBox.Show("Proceso Completo");
            }
            catch (Exception Ex)
            {
            }

        }// fin del metodo


         //*******************************************************************************
        //NOMBRE DE LA FUNCIÓN:Consultar_Informacion
        //DESCRIPCIÓN: Metodo que permite llenar el Grid con la informacion de la consulta
        //PARAMETROS: 
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 07/Abril/2016
        //MODIFICO:
        //FECHA_MODIFICO:
        //CAUSA_MODIFICACIÓN:
        //*******************************************************************************
        public void Consultar_Informacion()
        {
            Cls_Rpt_Plan_Escuelas_Negocio Rs_Consulta = new Cls_Rpt_Plan_Escuelas_Negocio();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Tomas = new DataTable();
            DataTable Dt_Volumenes = new DataTable();
            DataTable Dt_Auxiliar = new DataTable();
            DataTable Dt_Resumen = new DataTable();

            Dictionary<Int32, String> Dic_Meses;
            DateTime Dtime_Fecha;
            int Int_Anio = 0;
            Double Db_Total_Tomas = 0;
            Double Db_Total_Volumenes = 0;

            try
            {
                Dic_Meses = Cls_Metodos_Generales.Crear_Diccionario_Meses();

                Int_Anio = DateTime.Now.Year;

                //  valor para el año
                Rs_Consulta.P_Str_Anio = Int_Anio.ToString();

                //  se consulta la estructura del reporte
                Dt_Consulta = Rs_Consulta.Consultar_Tipos_Escuelas();



                Dt_Tomas = Dt_Consulta.Copy();
                Dt_Volumenes = Dt_Consulta.Copy();

                Dt_Tomas.TableName = "Tomas";
                Dt_Volumenes.TableName = "Volumenes";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  se consultan las tomas que se encuentran registradas
                foreach (DataRow Registro_Anio in Dt_Tomas.Rows)
                {
                    //  se establece que se modificaran los registros
                    Registro_Anio.BeginEdit();

                    //  se consulta el giro actividad
                    Rs_Consulta.P_Giro_Actividad_Id = Registro_Anio["Giro_Actividad_Id"].ToString();
                    Db_Total_Tomas = 0;


                    Dt_Consulta = new DataTable();
                    Dt_Consulta = Rs_Consulta.Consultar_Tomas_Escuela();

                    foreach (DataRow Registro_Mes in Dt_Consulta.Rows)
                    {
                        Db_Total_Tomas = Db_Total_Tomas + Convert.ToDouble(Registro_Mes["Tomas"].ToString());
                        Registro_Anio[Dic_Meses[DateTime.Now.Month]] = Convert.ToDouble(Registro_Mes["Tomas"].ToString());
                    }


                    //  se ingresa el total de las tomas
                    Registro_Anio["Total"] = Db_Total_Tomas;

                    //  se guardan los cambios
                    Registro_Anio.EndEdit();
                    Registro_Anio.AcceptChanges();

                }

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  se consultan los volumenes que se encuentran registradas
                foreach (DataRow Registro_Anio in Dt_Volumenes.Rows)
                {

                    //  se establece que se modificaran los registros
                    Registro_Anio.BeginEdit();

                    //  se consulta el giro actividad
                    Rs_Consulta.P_Giro_Actividad_Id = Registro_Anio["Giro_Actividad_Id"].ToString();
                    Db_Total_Volumenes = 0;


                    //  valor para el mes
                    Rs_Consulta.P_Mes = DateTime.Now.Month.ToString();

                    Dt_Consulta = new DataTable();
                    Dt_Consulta = Rs_Consulta.Consultar_Volumenes_Escuela();

                    foreach (DataRow Registro_Mes in Dt_Consulta.Rows)
                    {
                        Db_Total_Volumenes = Db_Total_Volumenes + Convert.ToDouble(Registro_Mes["Consumo"].ToString());
                        Registro_Anio[Dic_Meses[DateTime.Now.Month]] = Convert.ToDouble(Registro_Mes["Consumo"].ToString());
                    }

                    //  se ingresa el total de las tomas
                    Registro_Anio["Total"] = Db_Total_Volumenes;

                    //  se guardan los cambios
                    Registro_Anio.EndEdit();
                    Registro_Anio.AcceptChanges();
                }


                DataTable Dt_Existencia = new DataTable();
                String Str_Nombre_Mes = "";

                //  se ingresara la informacion
                //  se realizara la insercion de la informacion
                foreach (DataRow Registro in Dt_Tomas.Rows)
                {
                    Dt_Existencia.Clear();

                    Str_Nombre_Mes = "";
                    Str_Nombre_Mes = Dic_Meses[DateTime.Now.Month];
                    Rs_Consulta.P_Str_Nombre_Mes = Str_Nombre_Mes;
                    Rs_Consulta.P_Giro_Id = Registro["giro_actividad_id"].ToString();
                    Rs_Consulta.P_Anio = DateTime.Now.Year;
                    Rs_Consulta.P_Dr_Registro = Registro;
                    Rs_Consulta.P_Str_Usuario = "Servicio";


                    Dt_Existencia = Rs_Consulta.Consultar_Si_Existe_Registro_Escuela_Tomas();

                    //  validacion de la consulta
                    if (Dt_Existencia != null && Dt_Existencia.Rows.Count > 0)
                    {
                        //  actualizacion
                        Rs_Consulta.P_Id = Dt_Existencia.Rows[0]["ID"].ToString();
                        Rs_Consulta.Actualizar_Registro_Tomas_Escuelas();

                    }// fin del if
                    else
                    {
                        //  insercion
                        Rs_Consulta.Insertar_Registro_Tomas_Escuelas();

                    }// fin el else

                }// fin foreach



                //  se ingresara la informacion
                //  se realizara la insercion de la informacion
                foreach (DataRow Registro in Dt_Volumenes.Rows)
                {
                    Dt_Existencia.Clear();

                    Str_Nombre_Mes = "";
                    Str_Nombre_Mes = Dic_Meses[DateTime.Now.Month];
                    Rs_Consulta.P_Str_Nombre_Mes = Str_Nombre_Mes;
                    Rs_Consulta.P_Giro_Id = Registro["giro_actividad_id"].ToString();
                    Rs_Consulta.P_Anio = DateTime.Now.Year;
                    Rs_Consulta.P_Dr_Registro = Registro;
                    Rs_Consulta.P_Str_Usuario = "Servicio";


                    Dt_Existencia = Rs_Consulta.Consultar_Si_Existe_Registro_Escuela_Volumenes();

                    //  validacion de la consulta
                    if (Dt_Existencia != null && Dt_Existencia.Rows.Count > 0)
                    {
                        //  actualizacion
                        Rs_Consulta.P_Id = Dt_Existencia.Rows[0]["ID"].ToString();
                        Rs_Consulta.Actualizar_Registro_Volumenes_Escuelas();

                    }// fin del if
                    else
                    {
                        //  insercion
                        Rs_Consulta.Insertar_Registro_Volumenes_Escuelas();

                    }// fin el else

                }// fin foreach

            }
            catch (Exception Ex)
            {

            }
        }// fin del metodo
    }
}
