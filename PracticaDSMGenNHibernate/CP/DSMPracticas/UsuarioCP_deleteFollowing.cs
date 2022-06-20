
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Usuario_deleteFollowing) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class UsuarioCP : BasicCP
{
public void DeleteFollowing (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Usuario_deleteFollowing) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);






                //Call to UsuarioCAD

                usuarioCAD.DeleteFollowing (p_Usuario_OID, p_usuario_OIDs);



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
