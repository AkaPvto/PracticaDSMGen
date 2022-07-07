
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



/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CP.DSMPracticas_Usuario_banearUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CP.DSMPracticas
{
public partial class UsuarioCP : BasicCP
{
public void BanearUsuario (int p_oid)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CP.DSMPracticas_Usuario_banearUsuario) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;



        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);



                // Write here your custom code...
                UsuarioEN usuario = usuarioCEN.ReadOID(p_oid);

                AvisoCEN aviso = new AvisoCEN();

                IList<AvisoEN> avisos = aviso.GetAvisosUsu(p_oid);
                Console.WriteLine("El usuario " + usuario.Nickname + " tiene " + avisos.Count + " avisos\n");

                if (avisos.Count >= 3)
                {
                    if (usuario.Baneado)
                    {
                        Console.WriteLine("El usuario ya esta baneado");
                    }
                    else
                    {
                        usuario.Baneado = true;
                        Console.WriteLine("El usuario " + usuario.Nickname + " ha sido baneado.\n");
                    }
                }

                usuarioCAD.Modify(usuario);



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
