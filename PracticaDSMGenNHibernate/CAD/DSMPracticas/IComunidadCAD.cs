
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IComunidadCAD
{
ComunidadEN ReadOIDDefault (int id
                            );

void ModifyDefault (ComunidadEN comunidad);

System.Collections.Generic.IList<ComunidadEN> ReadAllDefault (int first, int size);



void DeletePost (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs);

int New_ (ComunidadEN comunidad);

void Modify (ComunidadEN comunidad);


void Destroy (int id
              );


ComunidadEN ReadOID (int id
                     );


System.Collections.Generic.IList<ComunidadEN> ReadAll (int first, int size);


void AddUsuarios (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);

void DeleteUsuarios (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_usuario_OIDs);

void AddPost (int p_Comunidad_OID, System.Collections.Generic.IList<int> p_post_OIDs);
}
}
