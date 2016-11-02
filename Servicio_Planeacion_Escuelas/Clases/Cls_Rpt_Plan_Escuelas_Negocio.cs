using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reportes_Planeacion.Escuelas.Datos;
using System.Data;

namespace Reportes_Planeacion.Escuelas.Negocio
{
    public class Cls_Rpt_Plan_Escuelas_Negocio
    {
        #region Variables_Publicas

        public String P_Str_Anio { get; set; }
        public String P_Mes { get; set; }
        public String P_Giro_Actividad_Id { get; set; }
        public String P_Fecha { get; set; }
        public String P_Str_Nombre_Mes { get; set; }
        public String P_Giro_Id { get; set; }
        public Int32 P_Anio { get; set; }
        public DataRow P_Dr_Registro { get; set; }
        public String P_Str_Usuario { get; set; }
        public String P_Id { get; set; }

        #endregion

        #region Consultas
        public DataTable Consultar_Tipos_Escuelas()
        {
            return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Tipos_Escuelas(this);
        }
        public DataTable Consultar_Tomas_Escuela()
        {
            return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Tomas_Escuela(this);
        }
        public DataTable Consultar_Volumenes_Escuela()
        {
            return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Volumenes_Escuela(this);
        }


        public DataTable Consultar_Si_Existe_Registro_Escuela_Tomas() { return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Si_Existe_Registro_Escuela_Tomas(this); }
        public void Insertar_Registro_Tomas_Escuelas() { Cls_Rpt_Plan_Escuelas_Datos.Insertar_Registro_Tomas_Escuelas(this); }
        public void Actualizar_Registro_Tomas_Escuelas() { Cls_Rpt_Plan_Escuelas_Datos.Actualizar_Registro_Tomas_Escuelas(this); }


        public DataTable Consultar_Si_Existe_Registro_Escuela_Volumenes() { return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Si_Existe_Registro_Escuela_Volumenes(this); }
        public void Insertar_Registro_Volumenes_Escuelas() { Cls_Rpt_Plan_Escuelas_Datos.Insertar_Registro_Volumenes_Escuelas(this); }
        public void Actualizar_Registro_Volumenes_Escuelas() { Cls_Rpt_Plan_Escuelas_Datos.Actualizar_Registro_Volumenes_Escuelas(this); }

        public DataTable Consultar_Tabla_Historicos_Volumenes_Escuelas() { return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Tabla_Historicos_Volumenes_Escuelas(this); }
        public DataTable Consultar_Tabla_Historicos_Tomas_Escuelas() { return Cls_Rpt_Plan_Escuelas_Datos.Consultar_Tabla_Historicos_Tomas_Escuelas(this); }
       
        
        #endregion
    }
}