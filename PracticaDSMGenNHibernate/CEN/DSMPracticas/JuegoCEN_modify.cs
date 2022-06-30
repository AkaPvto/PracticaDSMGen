
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Juego_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class JuegoCEN
{
public void Modify (int p_Juego_OID, string p_nombre, string p_descripcion, string p_portada)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Juego_modify_customized) START*/

        JuegoEN juegoEN = null;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();
        juegoEN.Id = p_Juego_OID;
        juegoEN.Nombre = p_nombre;
        juegoEN.Descripcion = p_descripcion;
        juegoEN.Portada = p_portada;
        //Call to JuegoCAD

        _IJuegoCAD.Modify (juegoEN);

        /*PROTECTED REGION END*/
}
}
}
