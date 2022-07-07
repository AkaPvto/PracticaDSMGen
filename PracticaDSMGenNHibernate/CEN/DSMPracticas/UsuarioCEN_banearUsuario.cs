
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


/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Usuario_banearUsuario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class UsuarioCEN
{
public void BanearUsuario (int p_oid)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Usuario_banearUsuario) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        AvisoCEN aviso = new AvisoCEN ();

        IList<AvisoEN> avisos = aviso.GetAvisosUsu (p_oid);
        Console.WriteLine ("El usuario " + usuario.Nickname + " tiene " + avisos.Count + " avisos\n");

        if (avisos.Count >= 3) {
                if (usuario.Baneado) {
                        Console.WriteLine ("El usuario ya esta baneado");
                }
                else{
                        usuario.Baneado = true;
                        Console.WriteLine ("El usuario " + usuario.Nickname + " ha sido baneado.\n");
                }
        }

        _IUsuarioCAD.Modify (usuario);

        /*PROTECTED REGION END*/
}
}
}
