
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Aviso_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class AvisoCP : BasicCP
{
public PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN New_ (string p_texto, int p_usuario, Nullable<DateTime> p_hora)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Aviso_new_) ENABLED START*/

        IAvisoCAD avisoCAD = null;
        AvisoCEN avisoCEN = null;

        PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                avisoCAD = new AvisoCAD (session);
                avisoCEN = new  AvisoCEN (avisoCAD);



                int oid;
                //Initialized AvisoEN
                AvisoEN avisoEN;
                avisoEN = new AvisoEN ();
                avisoEN.Texto = p_texto;


                if (p_usuario != -1) {
                        avisoEN.Usuario = new PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN ();
                        avisoEN.Usuario.Id = p_usuario;
                }

                avisoEN.Hora = p_hora;

                //Call to AvisoCAD

                oid = avisoCAD.New_ (avisoEN);
                result = avisoCAD.ReadOIDDefault (oid);



                SessionCommit ();
                new UsuarioCP().BanearUsuario (p_usuario);
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
        return result;


        /*PROTECTED REGION END*/
}
}
}
