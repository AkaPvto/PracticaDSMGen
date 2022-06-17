
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IComunidadCAD
{
ComunidadEN ReadOIDDefault (string nombre
                            );

void ModifyDefault (ComunidadEN comunidad);

System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size);



void DeletePost (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs);

string New_ (ComunidadEN comunidad);

void Modify (ComunidadEN comunidad);


void Destroy (string nombre
              );


ComunidadEN ReadOID (string nombre
                     );


System.Collections.Generic.IList<ComunidadEN> ReadAll (int first, int size);


void AddUsuarios (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);

void DeleteUsuarios (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);

void AddPost (string p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs);
}
}
