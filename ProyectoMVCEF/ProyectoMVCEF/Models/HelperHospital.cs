using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVCEF.Models
{
    public class HelperHospital
    {

        EntidadHospital entity;
        public HelperHospital()
        {
            entity = new EntidadHospital();
        }

        public List<HOSPITAL> GetHOSPITAL()
        {
            var consulta = this.entity.MOSTRARHOSPITALES();
            List<HOSPITAL> hospitales = consulta.ToList();
            return hospitales;
        }

        public List<PLANTILLA> GetPlantillaHospiatl(int[] hospital,ref String orden)
        {
            var consulta = from datos in entity.PLANTILLA
                            where hospital.Contains((int)datos.HOSPITAL_COD)
                            select datos;

            if (orden == "" || orden == "ASC")
            {
                consulta = consulta.OrderBy(x => x.APELLIDO);
                orden = "DESC";
            } else
            {
                 consulta = consulta.OrderByDescending(x => x.APELLIDO);
                orden = "ASC";
            }
            
            return consulta.ToList();
        }
    }
}