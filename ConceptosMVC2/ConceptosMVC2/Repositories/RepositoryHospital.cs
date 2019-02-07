using ConceptosMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConceptosMVC2.Repositories
{
    public class RepositoryHospital
    {
        HospitalContext context;
        public RepositoryHospital()
        {
            context = new HospitalContext();
        }

        public List<Enfermo> GetEnfermos()
        {
            return this.context.Enfermos.ToList();
        }

        public Enfermo BuscarEnfermo(int inscripcion)
        {
            return this.context.Enfermos.Single(z => z.Inscripcion == inscripcion);
        }

        public void EliminarEnfermo(int inscripcion)
        {
            Enfermo enfermo = this.BuscarEnfermo(inscripcion);
            this.context.Enfermos.Remove(enfermo);
            this.context.SaveChanges();
        }
        public List<Doctor> GetDoctores()
        {
            return this.context.Doctores.ToList();
        }
        public void InsertarDoctor(int doctorno, int hospitalno, String apellido, String especialidad, int salario)
        {
            Doctor doc = new Doctor();
            doc.IdDoctor = doctorno;
            doc.CodigoHospital = hospitalno;
            doc.Apellido = apellido;
            doc.Especialidad = especialidad;
            doc.Salario = salario;
            this.context.Doctores.Add(doc);
            this.context.SaveChanges();
        }
        public int GetMaxException()
        {
            if(this.context.Excepciones.Count() == 0)
            {
                return 1;
            } else {
                return this.context.Excepciones.Max(z => z.IdExcepcion) + 1;
            }
        }

        public void InsertarExcepcion(String mensaje, String controlador, DateTime fecha)
        {
            Excepcion ex = new Excepcion();
            ex.IdExcepcion = GetMaxException();
            ex.Mensaje = mensaje;
            ex.Contorlador = controlador;
            ex.Fecha = fecha;
            this.context.Excepciones.Add(ex);
            this.context.SaveChanges();
        }
    }
}