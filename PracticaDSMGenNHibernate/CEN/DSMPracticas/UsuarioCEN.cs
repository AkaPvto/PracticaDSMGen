

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaDSMGenNHibernate.Exceptions;

using PracticaDSMGenNHibernate.EN.DSMPracticas;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;


namespace PracticaDSMGenNHibernate.CEN.DSMPracticas
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public void AddJuego (int p_Usuario_OID, System.Collections.Generic.IList<int> p_juego_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddJuego (p_Usuario_OID, p_juego_OIDs);
}
public void Destroy (int id
                     )
{
        _IUsuarioCAD.Destroy (id);
}

public UsuarioEN ReadOID (int id
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public void AddComunidad (int p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidad_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddComunidad (p_Usuario_OID, p_comunidad_OIDs);
}
public void DeleteComunidad (int p_Usuario_OID, System.Collections.Generic.IList<int> p_comunidad_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DeleteComunidad (p_Usuario_OID, p_comunidad_OIDs);
}
public string Login (int p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public void AddFollowing (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddFollowing (p_Usuario_OID, p_usuario_OIDs);
}
public void DeleteFollowing (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DeleteFollowing (p_Usuario_OID, p_usuario_OIDs);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetUsuariosComunidad (int p_comunidad)
{
        return _IUsuarioCAD.GetUsuariosComunidad (p_comunidad);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetFollowing (int p_usuario)
{
        return _IUsuarioCAD.GetFollowing (p_usuario);
}
public void UsuarioLikePost (int p_Usuario_OID, System.Collections.Generic.IList<int> p_postLiked_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.UsuarioLikePost (p_Usuario_OID, p_postLiked_OIDs);
}
public void UsuarioUnlikePost (int p_Usuario_OID, System.Collections.Generic.IList<int> p_postLiked_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.UsuarioUnlikePost (p_Usuario_OID, p_postLiked_OIDs);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetFollowed (int p_usuario)
{
        return _IUsuarioCAD.GetFollowed (p_usuario);
}
public System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetUsuariosNotificacion (int p_notificacion)
{
        return _IUsuarioCAD.GetUsuariosNotificacion (p_notificacion);
}
public void DeleteJuego (int p_Usuario_OID, System.Collections.Generic.IList<int> p_juego_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DeleteJuego (p_Usuario_OID, p_juego_OIDs);
}
public PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN GetUsuarioEmail (string p_email)
{
        return _IUsuarioCAD.GetUsuarioEmail (p_email);
}



private string Encode (string email, int id)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }, { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);
        string token = Encode (en.Email, en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}

public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
