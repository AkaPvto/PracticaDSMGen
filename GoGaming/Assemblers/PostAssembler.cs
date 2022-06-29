using GoGaming.Models;
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
            post.Id = en.Id;
            post.Contenido = en.Contenido;
            post.Categoria = en.Categoria;
            post.Imagen = en.Imagen;
            post.Titulo = en.Titulo;
            post.Likes = en.Likes;
            post.Hora = (DateTime)en.Hora;
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