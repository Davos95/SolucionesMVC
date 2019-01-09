using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region PROCEDIMIENTOS
/*
GO
CREATE PROCEDURE ELIMINARENFERMO
(@INSCRIPCION INT)
AS
    DELETE FROM ENFERMO

    WHERE INSCRIPCION = @INSCRIPCION
GO

CREATE PROCEDURE MOSTRARENFERMOS
AS

    SELECT* FROM ENFERMO
GO
*/
#endregion

namespace ProyectoMVCEF.Models
{
    public class HelperEnfermos
    {
        EntidadHospital entity;
        public HelperEnfermos()
        {
            entity = new EntidadHospital();
        }

        public int EliminarEnfermo(int inscripcion)
        {
            int eliminados = this.entity.ELIMINARENFERMO(inscripcion);
            return eliminados;
        }

        public List<ENFERMO> GetEnfermos()
        {
            List<ENFERMO> enfermos = this.entity.MOSTRARENFERMOS().ToList();
            return enfermos;
        }
    }
}