using GoGaming.Models;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoGaming.Assemblers
{
    public class PostAssembler
    {
        public PostViewModel ConvertENToModelUI(PostEN en)
        {
            PostViewModel post = new PostViewModel();
            int coments = new ComentarioCEN().GetComentariosFecha(en.Id).Count;
            post.Id = en.Id;
            post.Contenido = en.Contenido;
            post.Categoria = Math.Max((int)en.Categoria -1, 0);
            post.Imagen = en.Imagen;
            post.Titulo = en.Titulo;
            post.Likes = en.Likes;
            post.Hora = (DateTime)en.Hora;
            post.Comentarios = coments;
            post.Comunidad = en.Comunidad.Id;
            post.Usuario = en.UsuarioCreador.Id;
            post.UsuarioName = new UsuarioCEN().ReadOID(en.UsuarioCreador.Id).Nickname;
            
            return post;
        }

        public IList<PostViewModel> ConvertListENToModel(IList<PostEN> ens)
        {
            IList<PostViewModel> posts = new List<PostViewModel>();
            foreach(PostEN en in ens)
            {
                posts.Add(ConvertENToModelUI(en));
            }
            return posts;
        }
        
    }
}