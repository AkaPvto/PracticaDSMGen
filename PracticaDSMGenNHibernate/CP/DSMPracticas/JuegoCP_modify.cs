
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Juego_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class JuegoCP : BasicCP
{
public void Modify (int p_Juego_OID, string p_nombre, string p_descripcion, string p_portada, System.Collections.Generic.IList<int> p_generos)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Juego_modify) ENABLED START*/

        IJuegoCAD juegoCAD = null;
        JuegoCEN juegoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                juegoCAD = new JuegoCAD (session);
                juegoCEN = new  JuegoCEN (juegoCAD);
                GeneroCAD generoCAD = new GeneroCAD(session);
                GeneroCEN generoCEN = new GeneroCEN(generoCAD);

               

                JuegoEN juegoEN = null;
                //Initialized JuegoEN
                juegoEN = new JuegoEN ();
                juegoEN.Id = p_Juego_OID;
                juegoEN.Nombre = p_nombre;
                juegoEN.Descripcion = p_descripcion;
                juegoEN.Portada = p_portada;

                if(p_generos.Count > 0) {
                    IList<GeneroEN> generosJuego = generoCEN.GetGenerosJuego(p_Juego_OID);
                    IList<int> generosOID = new List<int>();
                    foreach (GeneroEN genero in generosJuego)
                    {
                        generosOID.Add(genero.Id);
                    }
                    juegoCEN.DeleteGenero(p_Juego_OID, generosOID);
                    juegoCEN.AddGenero(p_Juego_OID, p_generos);
                }
                
                //Call to JuegoCAD

                juegoCAD.Modify (juegoEN);


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
