
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


/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Usuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class UsuarioCEN
{
public int New_ (string p_nickname, string p_nombre, string p_apellidos, string p_email, int p_telefono, string p_direccion, string p_foto, String p_pass, bool p_admin)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Usuario_new__customized) ENABLED START*/

        UsuarioEN usuarioEN = null;

        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nickname = p_nickname;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Email = p_email;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.Direccion = p_direccion;

        usuarioEN.Foto = p_foto;

        usuarioEN.Baneado = false;

        usuarioEN.Administrator = p_admin;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
