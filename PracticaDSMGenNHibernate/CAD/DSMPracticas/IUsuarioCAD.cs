
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



void AddJuego (int p_Usuario_OID, System.Collections.Generic.IList<string> p_juego_OIDs);

int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id
              );


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


void AddFollowed (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);

void AddComunidad (int p_Usuario_OID, System.Collections.Generic.IList<string> p_comunidad_OIDs);

void DeleteComunidad (int p_Usuario_OID, System.Collections.Generic.IList<string> p_comunidad_OIDs);

void DeleteFollowed (int p_Usuario_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);



void AddFollowing (int p_Usuario_OID, int p_usuario_0_OID);

void BorrarFollowing (int p_Usuario_OID, int p_usuario_0_OID);

System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.UsuarioEN> GetComunidadUsu (string p_comunidad);
}
}
