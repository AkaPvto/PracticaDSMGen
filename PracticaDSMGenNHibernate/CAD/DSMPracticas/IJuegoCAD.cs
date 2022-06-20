
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IJuegoCAD
{
JuegoEN ReadOIDDefault (string nombre
                        );

void ModifyDefault (JuegoEN juego);

System.Collections.Generic.IList<JuegoEN> ReadAllDefault (int first, int size);



string New_ (JuegoEN juego);

void Modify (JuegoEN juego);


void Destroy (string nombre
              );


JuegoEN ReadOID (string nombre
                 );


System.Collections.Generic.IList<JuegoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Busqueda (string p_nombre);



System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> GetJuegosPorUsuario (int p_usuario);
}
}
