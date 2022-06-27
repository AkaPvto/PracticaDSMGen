
using System;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace PracticaDSMGenNHibernate.CAD.DSMPracticas
{
public partial interface IPostCAD
{
PostEN ReadOIDDefault (int id
                       );

void ModifyDefault (PostEN post);

System.Collections.Generic.IList<PostEN> ReadAllDefault (int first, int size);



void AddComentario (int p_Post_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);

void BorrarComentario (int p_Post_OID, System.Collections.Generic.IList<int> p_comentario_OIDs);

int New_ (PostEN post);

void Modify (PostEN post);


void Destroy (int id
              );


PostEN ReadOID (int id
                );


System.Collections.Generic.IList<PostEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostsUsu (int ? p_usu);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostPorCategoria (PracticaDSMGenNHibernate.Enumerated.DSMPracticas.Categoria_PostEnum ? p_categoria);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostComunidadLikes (int p_comunidad);


System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostComunidadFecha (int p_comunidad);


void PostLikedByUsuario (int p_Post_OID, System.Collections.Generic.IList<int> p_usuarioLiker_OIDs);

void PostUnlikedByUsuario (int p_Post_OID, System.Collections.Generic.IList<int> p_usuarioLiker_OIDs);

System.Collections.Generic.IList<PracticaDSMGenNHibernate.EN.DSMPracticas.PostEN> GetPostLiked (int p_usuario);
}
}
