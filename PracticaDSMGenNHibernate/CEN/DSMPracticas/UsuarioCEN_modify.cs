
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


/*PROTECTED REGION ID(usingPracticaDSMGenNHibernate.CEN.DSMPracticas_Usuario_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
public partial class UsuarioCEN
{
public void Modify (int p_Usuario_OID, string p_nickname, string p_nombre, string p_apellidos, int p_telefono, string p_direccion, string p_foto)
{
        /*PROTECTED REGION ID(PracticaDSMGenNHibernate.CEN.DSMPracticas_Usuario_modify_customized) START*/

        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Nickname = p_nickname;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.Direccion = p_direccion;
        usuarioEN.Foto = p_foto;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
