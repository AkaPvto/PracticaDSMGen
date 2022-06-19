
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);



int NewHijo (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id
              );


ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.ComentarioEN> GetComentariosFecha (int p_post);


void AddComentarioHijo (int p_Comentario_OID, System.Collections.Generic.IList<int> p_comentariosHijos_OIDs);

int NewRaiz (ComentarioEN comentario);
}
}
