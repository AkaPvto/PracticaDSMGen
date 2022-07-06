
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IJuegoCAD
{
JuegoEN ReadOIDDefault (int id
                        );

void ModifyDefault (JuegoEN juego);

System.Collections.Generic.IList<JuegoEN> ReadAllDefault (int first, int size);



int New_ (JuegoEN juego);

void Modify (JuegoEN juego);


void Destroy (int id
              );


JuegoEN ReadOID (int id
                 );


System.Collections.Generic.IList<JuegoEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> Busqueda (string p_nombre);



System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.JuegoEN> GetJuegosPorUsuario (int p_usuario);


void AddGenero (int p_Juego_OID, System.Collections.Generic.IList<int> p_genero_OIDs);

void DeleteGenero (int p_Juego_OID, System.Collections.Generic.IList<int> p_genero_OIDs);

void AddComunidad (int p_Juego_OID, int p_comunidad_OID);

void DeleteComunidad (int p_Juego_OID, int p_comunidad_OID);
}
}
