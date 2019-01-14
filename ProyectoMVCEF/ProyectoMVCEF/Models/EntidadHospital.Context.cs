﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ProyectoMVCEF.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class EntidadHospital : DbContext
{
    public EntidadHospital()
        : base("name=EntidadHospital")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<TODOSEMPLEADOS> TODOSEMPLEADOS { get; set; }

    public virtual DbSet<DOCTOR> DOCTOR { get; set; }

    public virtual DbSet<PLANTILLA> PLANTILLA { get; set; }

    public virtual DbSet<EMP> EMP { get; set; }

    public virtual DbSet<DEPT> DEPT { get; set; }

    public virtual DbSet<ENFERMO> ENFERMO { get; set; }

    public virtual DbSet<HOSPITAL> HOSPITAL { get; set; }


    public virtual int ELIMINARENFERMO(Nullable<int> iNSCRIPCION)
    {

        var iNSCRIPCIONParameter = iNSCRIPCION.HasValue ?
            new ObjectParameter("INSCRIPCION", iNSCRIPCION) :
            new ObjectParameter("INSCRIPCION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ELIMINARENFERMO", iNSCRIPCIONParameter);
    }


    public virtual ObjectResult<ENFERMO> MOSTRARENFERMOS()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ENFERMO>("MOSTRARENFERMOS");
    }


    public virtual ObjectResult<ENFERMO> MOSTRARENFERMOS(MergeOption mergeOption)
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ENFERMO>("MOSTRARENFERMOS", mergeOption);
    }


    public virtual ObjectResult<PAGINAREMPLEADOSSIMPLE_Result> PAGINAREMPLEADOSSIMPLE(Nullable<int> pOSICION)
    {

        var pOSICIONParameter = pOSICION.HasValue ?
            new ObjectParameter("POSICION", pOSICION) :
            new ObjectParameter("POSICION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINAREMPLEADOSSIMPLE_Result>("PAGINAREMPLEADOSSIMPLE", pOSICIONParameter);
    }


    public virtual ObjectResult<PAGINARDOCTORES_Result> PAGINARDOCTORES(Nullable<int> pOSICION)
    {

        var pOSICIONParameter = pOSICION.HasValue ?
            new ObjectParameter("POSICION", pOSICION) :
            new ObjectParameter("POSICION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINARDOCTORES_Result>("PAGINARDOCTORES", pOSICIONParameter);
    }


    public virtual int DATOSDEPARTAMENTOS(Nullable<int> dEPTNO, ObjectParameter pERSONAS, ObjectParameter sUMA, ObjectParameter mEDIA)
    {

        var dEPTNOParameter = dEPTNO.HasValue ?
            new ObjectParameter("DEPTNO", dEPTNO) :
            new ObjectParameter("DEPTNO", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DATOSDEPARTAMENTOS", dEPTNOParameter, pERSONAS, sUMA, mEDIA);
    }


    public virtual ObjectResult<PAGINACIONEMPLEADOSAGRUPADOS_Result> PAGINACIONEMPLEADOSAGRUPADOS(Nullable<int> pOSICION, ObjectParameter tOTALREGISTROS)
    {

        var pOSICIONParameter = pOSICION.HasValue ?
            new ObjectParameter("POSICION", pOSICION) :
            new ObjectParameter("POSICION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINACIONEMPLEADOSAGRUPADOS_Result>("PAGINACIONEMPLEADOSAGRUPADOS", pOSICIONParameter, tOTALREGISTROS);
    }


    public virtual ObjectResult<PAGINACIONDOCTORESAGRUPADOS_Result1> PAGINACIONDOCTORESAGRUPADOS(Nullable<int> pOSICION, Nullable<int> sALARIO, ObjectParameter tOTALREGISTROS)
    {

        var pOSICIONParameter = pOSICION.HasValue ?
            new ObjectParameter("POSICION", pOSICION) :
            new ObjectParameter("POSICION", typeof(int));


        var sALARIOParameter = sALARIO.HasValue ?
            new ObjectParameter("SALARIO", sALARIO) :
            new ObjectParameter("SALARIO", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINACIONDOCTORESAGRUPADOS_Result1>("PAGINACIONDOCTORESAGRUPADOS", pOSICIONParameter, sALARIOParameter, tOTALREGISTROS);
    }


    public virtual int ELIMINARENFERMO1(Nullable<int> iNSCRIPCION)
    {

        var iNSCRIPCIONParameter = iNSCRIPCION.HasValue ?
            new ObjectParameter("INSCRIPCION", iNSCRIPCION) :
            new ObjectParameter("INSCRIPCION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ELIMINARENFERMO1", iNSCRIPCIONParameter);
    }


    public virtual ObjectResult<MOSTRARENFERMOS1_Result> MOSTRARENFERMOS1()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MOSTRARENFERMOS1_Result>("MOSTRARENFERMOS1");
    }


    public virtual ObjectResult<PAGINARDOCTORES1_Result> PAGINARDOCTORES1(Nullable<int> pOSICION)
    {

        var pOSICIONParameter = pOSICION.HasValue ?
            new ObjectParameter("POSICION", pOSICION) :
            new ObjectParameter("POSICION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINARDOCTORES1_Result>("PAGINARDOCTORES1", pOSICIONParameter);
    }


    public virtual ObjectResult<PAGINAREMPLEADOSSIMPLE1_Result> PAGINAREMPLEADOSSIMPLE1(Nullable<int> pOSICION)
    {

        var pOSICIONParameter = pOSICION.HasValue ?
            new ObjectParameter("POSICION", pOSICION) :
            new ObjectParameter("POSICION", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINAREMPLEADOSSIMPLE1_Result>("PAGINAREMPLEADOSSIMPLE1", pOSICIONParameter);
    }

}

}
