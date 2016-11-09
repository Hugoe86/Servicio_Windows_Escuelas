using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reportes_Planeacion.Escuelas.Negocio;
using System.Data;
using SIAC.Constantes;
using SharpContent.ApplicationBlocks.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace Reportes_Planeacion.Escuelas.Datos
{
    public class Cls_Rpt_Plan_Escuelas_Datos
    {

        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Tipos_Escuelas
        //DESCRIPCION: Metodo que Consulta las cuentas 
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 18/Agosto/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Tipos_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();
            String Str_My_Sql = "";
            try
            {
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql = "SELECT DISTINCT (ga.Actividad_Giro_ID) as Giro_Actividad_Id";
                Str_My_Sql += ", ga.Nombre";
                Str_My_Sql += ", 0 AS Enero";
                Str_My_Sql += ", 0 as Febrero";
                Str_My_Sql += ", 0 as Marzo";
                Str_My_Sql += ", 0 as Abril";
                Str_My_Sql += ", 0 as Mayo";
                Str_My_Sql += ", 0 as Junio";
                Str_My_Sql += ", 0 as Julio";
                Str_My_Sql += ", 0 as Agosto";
                Str_My_Sql += ", 0 as Septiembre";
                Str_My_Sql += ", 0 as Octubre";
                Str_My_Sql += ", 0 as Noviembre";
                Str_My_Sql += ", 0 as Diciembre";
                Str_My_Sql += ", 0 as Total";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " FROM Cat_Cor_Predios p";
                Str_My_Sql += " JOIN Cat_Cor_Giros_Actividades ga ON ga.Actividad_Giro_ID = p.Giro_Actividad_ID";
                
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " WHERE p.Escuela_Publica = 'SI'";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " GROUP by ga.Actividad_Giro_ID";
                Str_My_Sql += " ,ga.Nombre";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta


        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Tomas_Escuela
        //DESCRIPCION: Metodo que Consulta las cuentas 
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 18/Agosto/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Tomas_Escuela(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();
            String Str_My_Sql = "";
            try
            {
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql = "SELECT isnull(count(ps.Predio_ID), 0) as Tomas";
             

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " FROM Cat_Cor_Predios ps";
                Str_My_Sql += " JOIN Cat_Cor_Giros_Actividades gas ON gas.Actividad_Giro_ID = ps.Giro_Actividad_ID";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " WHERE ps.Escuela_Publica = 'SI'";
                Str_My_Sql += " and ps.Estatus = 'ACTIVO' ";

                //Str_My_Sql += " AND year(ps.Fecha_Creo) = " + Datos.P_Anio;
                //Str_My_Sql += " AND month(ps.Fecha_Creo) = " + Datos.P_Mes;
                Str_My_Sql += " and ps.Giro_Actividad_ID = '" + Datos.P_Giro_Actividad_Id + "'";


                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta


        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Volumenes_Escuela
        //DESCRIPCION: Metodo que Consulta las cuentas 
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 18/Agosto/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Volumenes_Escuela(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();
            String Str_My_Sql = "";
            try
            {
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql = "SELECT isnull(sum(f.Consumo), 0) AS Consumo";


                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " FROM Cat_Cor_Predios ps";
                Str_My_Sql += " JOIN Cat_Cor_Giros_Actividades gas ON gas.Actividad_Giro_ID = ps.Giro_Actividad_ID";
                Str_My_Sql += " join Ope_Cor_Facturacion_Recibos f on f.Predio_ID = ps.Predio_ID";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql += " WHERE ps.Escuela_Publica = 'SI'";

                Str_My_Sql += " AND year(f.Fecha_Emision) = " + Datos.P_Str_Anio;
                Str_My_Sql += " AND MONTH(f.Fecha_Emision) = " + Datos.P_Mes;
                Str_My_Sql += " and ps.Giro_Actividad_ID = '" + Datos.P_Giro_Actividad_Id + "'";


                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta



        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Si_Historico_Agua
        //DESCRIPCION: Metodo que las tomas que tiene el uso de descargar a la red de saneamiento
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 11/Abril/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Si_Existe_Registro_Escuela_Tomas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();
            String Str_My_Sql = "";

            try
            {
                Str_My_Sql = "select * from Ope_Cor_Plan_Tomas_Escuelas";
                Str_My_Sql += " where Giro_Id = '" + Datos.P_Giro_Id + "'";
                Str_My_Sql += " and Año = " + Datos.P_Anio;

                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta




        //*******************************************************************************
        //NOMBRE_FUNCION:  Insertar_Registro_Agua
        //DESCRIPCION: Metodo que ingresa la informacion
        //PARAMETROS : 1.- Cls_Rpt_Plan_Montos_Negocio Clase_Negocios, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 25-Octubre-2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static void Insertar_Registro_Tomas_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            //Declaración de las variables
            SqlTransaction Obj_Transaccion = null;
            SqlConnection Obj_Conexion = new SqlConnection(Cls_Constantes.Str_Conexion);
            SqlCommand Obj_Comando = new SqlCommand();
            String Mi_SQL = "";

            try
            {
                Obj_Conexion.Open();
                Obj_Transaccion = Obj_Conexion.BeginTransaction();
                Obj_Comando.Transaction = Obj_Transaccion;
                Obj_Comando.Connection = Obj_Conexion;


                #region historico


                Mi_SQL = "INSERT INTO  Ope_Cor_Plan_Tomas_Escuelas (";
                Mi_SQL += "  Giro_Id";                          //  1
                Mi_SQL += ", Concepto";                         //  2
                Mi_SQL += ", Año";                              //  3
                Mi_SQL += ", " + Datos.P_Str_Nombre_Mes;        //  4
                Mi_SQL += ", Fecha_Creo";                       //  5
                Mi_SQL += ", Usuario_Creo";                     //  6
                Mi_SQL += ")";
                //***************************************************************************
                Mi_SQL += " values ";
                //***************************************************************************
                Mi_SQL += "(";
                Mi_SQL += "  '" + Datos.P_Giro_Id + "'";                                            //  1
                Mi_SQL += ", '" + Datos.P_Dr_Registro["Nombre"].ToString() + "'";                 //  2
                Mi_SQL += ",  " + Convert.ToDouble(Datos.P_Anio).ToString(new CultureInfo("es-MX")) + "";//  3
                Mi_SQL += ",  " + Convert.ToDouble(Datos.P_Dr_Registro[Datos.P_Str_Nombre_Mes].ToString()).ToString(new CultureInfo("es-MX")) + "";      //  4
                Mi_SQL += ",  getdate()";                                                           //  5
                Mi_SQL += ", '" + Datos.P_Str_Usuario + "'";                                        //  7
                Mi_SQL += ")";

                Obj_Comando.CommandText = Mi_SQL;
                Obj_Comando.ExecuteNonQuery();

                #endregion Fin historico

                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //ejecucion de la transaccion    ***********************************************************************************
                Obj_Transaccion.Commit();


            }
            catch (SqlException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (DBConcurrencyException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            finally
            {
                Obj_Conexion.Close();
            }


        }// fin del metodo



        //*******************************************************************************
        //NOMBRE_FUNCION:  Actualizar_Registro_Tomas_Escuelas
        //DESCRIPCION: Metodo que ingresa la informacion de los montos de la facturacion
        //PARAMETROS : 1.- Cls_Rpt_Plan_Montos_Negocio Clase_Negocios, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 25-Octubre-2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static void Actualizar_Registro_Tomas_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            //Declaración de las variables
            SqlTransaction Obj_Transaccion = null;
            SqlConnection Obj_Conexion = new SqlConnection(Cls_Constantes.Str_Conexion);
            SqlCommand Obj_Comando = new SqlCommand();
            String Mi_SQL = "";

            try
            {
                Obj_Conexion.Open();
                Obj_Transaccion = Obj_Conexion.BeginTransaction();
                Obj_Comando.Transaction = Obj_Transaccion;
                Obj_Comando.Connection = Obj_Conexion;


                #region historico


                Mi_SQL = "update  Ope_Cor_Plan_Tomas_Escuelas set ";
                Mi_SQL += "  " + Datos.P_Str_Nombre_Mes + " = " + Convert.ToDouble(Datos.P_Dr_Registro[Datos.P_Str_Nombre_Mes].ToString()).ToString(new CultureInfo("es-MX"));
                Mi_SQL += ", fecha_modifico = getdate()";
                Mi_SQL += ", usuario_modifico = '" + Datos.P_Str_Usuario + "'";
                Mi_SQL += " where id = '" + Datos.P_Id + "'";
                Obj_Comando.CommandText = Mi_SQL;
                Obj_Comando.ExecuteNonQuery();


                #endregion Fin historico

                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //ejecucion de la transaccion    ***********************************************************************************
                Obj_Transaccion.Commit();


            }
            catch (SqlException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (DBConcurrencyException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            finally
            {
                Obj_Conexion.Close();
            }


        }// fin del metodo






        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Si_Existe_Registro_Escuela_Volumenes
        //DESCRIPCION: Metodo que las tomas que tiene el uso de descargar a la red de saneamiento
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 11/Abril/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Si_Existe_Registro_Escuela_Volumenes(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();
            String Str_My_Sql = "";

            try
            {
                Str_My_Sql = "select * from Ope_Cor_Plan_Volumenes_Escuelas";
                Str_My_Sql += " where Giro_Id = '" + Datos.P_Giro_Id + "'";
                Str_My_Sql += " and Año = " + Datos.P_Anio;

                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta




        //*******************************************************************************
        //NOMBRE_FUNCION:  Insertar_Registro_Agua
        //DESCRIPCION: Metodo que ingresa la informacion
        //PARAMETROS : 1.- Cls_Rpt_Plan_Montos_Negocio Clase_Negocios, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 25-Octubre-2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static void Insertar_Registro_Volumenes_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            //Declaración de las variables
            SqlTransaction Obj_Transaccion = null;
            SqlConnection Obj_Conexion = new SqlConnection(Cls_Constantes.Str_Conexion);
            SqlCommand Obj_Comando = new SqlCommand();
            String Mi_SQL = "";

            try
            {
                Obj_Conexion.Open();
                Obj_Transaccion = Obj_Conexion.BeginTransaction();
                Obj_Comando.Transaction = Obj_Transaccion;
                Obj_Comando.Connection = Obj_Conexion;


                #region historico


                Mi_SQL = "INSERT INTO  Ope_Cor_Plan_Volumenes_Escuelas (";
                Mi_SQL += "  Giro_Id";                          //  1
                Mi_SQL += ", Concepto";                         //  2
                Mi_SQL += ", Año";                              //  3
                Mi_SQL += ", " + Datos.P_Str_Nombre_Mes;        //  4
                Mi_SQL += ", Fecha_Creo";                       //  5
                Mi_SQL += ", Usuario_Creo";                     //  6
                Mi_SQL += ")";
                //***************************************************************************
                Mi_SQL += " values ";
                //***************************************************************************
                Mi_SQL += "(";
                Mi_SQL += "  '" + Datos.P_Giro_Id + "'";                                            //  1
                Mi_SQL += ", '" + Datos.P_Dr_Registro["Nombre"].ToString() + "'";                 //  2
                Mi_SQL += ",  " + Convert.ToDouble(Datos.P_Anio).ToString(new CultureInfo("es-MX")) + "";//  3
                Mi_SQL += ",  " + Convert.ToDouble(Datos.P_Dr_Registro[Datos.P_Str_Nombre_Mes].ToString()).ToString(new CultureInfo("es-MX")) + "";      //  4
                Mi_SQL += ",  getdate()";                                                           //  5
                Mi_SQL += ", '" + Datos.P_Str_Usuario + "'";                                        //  7
                Mi_SQL += ")";

                Obj_Comando.CommandText = Mi_SQL;
                Obj_Comando.ExecuteNonQuery();

                #endregion Fin historico

                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //ejecucion de la transaccion    ***********************************************************************************
                Obj_Transaccion.Commit();


            }
            catch (SqlException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (DBConcurrencyException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            finally
            {
                Obj_Conexion.Close();
            }


        }// fin del metodo



        //*******************************************************************************
        //NOMBRE_FUNCION:  Actualizar_Registro_Volumenes_Escuelas
        //DESCRIPCION: Metodo que ingresa la informacion de los montos de la facturacion
        //PARAMETROS : 1.- Cls_Rpt_Plan_Montos_Negocio Clase_Negocios, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 25-Octubre-2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static void Actualizar_Registro_Volumenes_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            //Declaración de las variables
            SqlTransaction Obj_Transaccion = null;
            SqlConnection Obj_Conexion = new SqlConnection(Cls_Constantes.Str_Conexion);
            SqlCommand Obj_Comando = new SqlCommand();
            String Mi_SQL = "";

            try
            {
                Obj_Conexion.Open();
                Obj_Transaccion = Obj_Conexion.BeginTransaction();
                Obj_Comando.Transaction = Obj_Transaccion;
                Obj_Comando.Connection = Obj_Conexion;


                #region historico


                Mi_SQL = "update  Ope_Cor_Plan_Volumenes_Escuelas set ";
                Mi_SQL += "  " + Datos.P_Str_Nombre_Mes + " = " + Convert.ToDouble(Datos.P_Dr_Registro[Datos.P_Str_Nombre_Mes].ToString()).ToString(new CultureInfo("es-MX"));
                Mi_SQL += ", fecha_modifico = getdate()";
                Mi_SQL += ", usuario_modifico = '" + Datos.P_Str_Usuario + "'";
                Mi_SQL += " where id = '" + Datos.P_Id + "'";
                Obj_Comando.CommandText = Mi_SQL;
                Obj_Comando.ExecuteNonQuery();

                #endregion Fin historico

                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //***********************************************************************************************************************
                //ejecucion de la transaccion    ***********************************************************************************
                Obj_Transaccion.Commit();


            }
            catch (SqlException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (DBConcurrencyException Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            catch (Exception Ex)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Error: " + Ex.Message);
            }
            finally
            {
                Obj_Conexion.Close();
            }


        }// fin del metodo



        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Tabla_Historicos_Volumenes_Escuelas
        //DESCRIPCION: consulta los historicos
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 26/Octubre/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Tabla_Historicos_Volumenes_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();

            String Str_My_Sql = "";
            try
            {
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql = "select ";
                Str_My_Sql += " * ";


                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  from **********************************************************************************************************************************
                Str_My_Sql += " from Ope_Cor_Plan_Volumenes_Escuelas";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  where **********************************************************************************************************************************
                Str_My_Sql += " where";
                Str_My_Sql += " Año = " + Datos.P_Anio;

                if (!String.IsNullOrEmpty(Datos.P_Giro_Id))
                {
                    Str_My_Sql += " and giro_Id = '" + Datos.P_Giro_Id + "'";
                }

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  **********************************************************************************************************************************

                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta


        //*******************************************************************************
        //NOMBRE_FUNCION:  Consultar_Tabla_Historicos_Tomas_Escuelas
        //DESCRIPCION: consulta los historicos
        //PARAMETROS : 1.- Cls_Rpt_Cor_Cc_Reportes_Varios_Neogcio Datos, objeto de la clase de negocios
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 26/Octubre/2016
        //MODIFICO   :
        //FECHA_MODIFICO:
        //CAUSA_MODIFICO:
        //*******************************************************************************
        public static DataTable Consultar_Tabla_Historicos_Tomas_Escuelas(Cls_Rpt_Plan_Escuelas_Negocio Datos)
        {
            DataTable Dt_Consulta = new DataTable();

            String Str_My_Sql = "";
            try
            {
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                Str_My_Sql = "select ";
                Str_My_Sql += " * ";


                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  from **********************************************************************************************************************************
                Str_My_Sql += " from Ope_Cor_Plan_Tomas_Escuelas";

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  where **********************************************************************************************************************************
                Str_My_Sql += " where";
                Str_My_Sql += " Año = " + Datos.P_Anio;

                if (!String.IsNullOrEmpty(Datos.P_Giro_Id))
                {
                    Str_My_Sql += " and giro_Id = '" + Datos.P_Giro_Id + "'";
                }

                //  ****************************************************************************************************************************************
                //  ****************************************************************************************************************************************
                //  **********************************************************************************************************************************

                Dt_Consulta = SqlHelper.ExecuteDataset(Cls_Constantes.Str_Conexion, CommandType.Text, Str_My_Sql).Tables[0];

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: " + Ex.Message);
            }

            return Dt_Consulta;

        }// fin de consulta


    }
}