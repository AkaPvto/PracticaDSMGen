
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Juego_recomendarJuego) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class JuegoCP : BasicCP
{
public void RecomendarJuego (string p_oid, int p_usu)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Juego_recomendarJuego) ENABLED START*/

        IJuegoCAD juegoCAD = null;
        JuegoCEN juegoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                juegoCAD = new JuegoCAD (session);
                juegoCEN = new  JuegoCEN (juegoCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method RecomendarJuego() not yet implemented.");



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
