
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

        UsuarioEN usuarioEN = new UsuarioCEN().ReadOID(p_Usuario_OID);

        //Initialized UsuarioEN
        if(p_nickname != null && p_nickname != "") { 
                usuarioEN.Nickname = p_nickname;
            }
        if(p_nombre != null && p_nombre != "") { 
            usuarioEN.Nombre = p_nombre;
            }
        if(p_apellidos != null && p_apellidos != "") { 
            usuarioEN.Apellidos = p_apellidos;
            }
        if(p_telefono > 0) {
                usuarioEN.Telefono = p_telefono;
            }
        if(p_direccion != null && p_direccion != "") {
                usuarioEN.Direccion = p_direccion;
            }
        if(p_foto != null && p_foto != "") {
                usuarioEN.Foto = p_foto;
            }
        
        
        
        
        
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
