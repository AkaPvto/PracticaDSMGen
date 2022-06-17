
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IAvisoCAD
{
AvisoEN ReadOIDDefault (int id
                        );

void ModifyDefault (AvisoEN aviso);

System.Collections.Generic.IList<AvisoEN> ReadAllDefault (int first, int size);



int New_ (AvisoEN aviso);

void Modify (AvisoEN aviso);


void Destroy (int id
              );


AvisoEN ReadOID (int id
                 );


System.Collections.Generic.IList<AvisoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.AvisoEN> GetAvisosUsu (int ? p_usu);
}
}
