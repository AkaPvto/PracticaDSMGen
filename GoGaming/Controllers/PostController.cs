using GoGaming.Assemblers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.CP.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaDSMGenNHibernate.Enumerated.DSMPracticas;
using System.IO;

namespace GoGaming.Controllers
{
    public class PostController : BasicController
    {

        public ActionResult DetailsPartial(int id)
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);

            PostEN postEN = postCEN.ReadOID(id);
            PostViewModel postViewModel = new PostAssembler().ConvertENToModelUI(postEN);
            SessionClose();
            return View(postViewModel);
        }
        // GET: Post
        public ActionResult Index()
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);
            IList<PostEN> listEN = postCEN.ReadAll(0, -1);
            IEnumerable<PostViewModel> listViewModel = new PostAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            return View(listViewModel);
        }

        public ActionResult IndexPartialFecha(int id)
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);
            IList<PostEN> listEN = postCEN.GetPostComunidadFecha(id);
            IEnumerable<PostViewModel> listViewModel = new PostAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
            IList<string> lista = new List<string>();
            foreach(var value in values)
            {
                lista.Add(value.ToString());
            }
            ViewData["enum"] = lista;
            return View(listViewModel);
        }

        public ActionResult IndexPartialLikes(int id)
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);
            IList<PostEN> listEN = postCEN.GetPostComunidadLikes(id);
            IEnumerable<PostViewModel> listViewModel = new PostAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
            IList<string> lista = new List<string>();
            foreach (var value in values)
            {
                lista.Add(value.ToString());
            }
            ViewData["enum"] = lista;
            return View(listViewModel);
        }

        public ActionResult IndexPostsUsuario(int id)
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);
            IList<PostEN> listEN = postCEN.GetPostsUsu(id);
            IEnumerable<PostViewModel> listViewModel = new PostAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();
            Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
            IList<string> lista = new List<string>();
            foreach (var value in values)
            {
                lista.Add(value.ToString());
            }
            ViewData["enum"] = lista;
            return View(listViewModel);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            PostCEN postCEN = new PostCEN();

            PostEN postEN = postCEN.ReadOID(id);
            PostViewModel postViewModel = new PostAssembler().ConvertENToModelUI(postEN);

            bool liked = false;
            if (Session["Usuario"] != null)
            {
                IList<PostEN> listEN = postCEN.GetPostLiked(((UsuarioEN)Session["Usuario"]).Id);
                liked = listEN.Contains(postCEN.ReadOID(id));
            }

            ViewData["Liked"] = liked;
            return View(postViewModel);
        }

        public ActionResult Interact(int id)
        {
            UsuarioCP usuarioCP = new UsuarioCP();
            
            if(Session["Usuario"] != null)
            {
                usuarioCP.InteractPost(((UsuarioEN)Session["Usuario"]).Id, id);
            }
            

            return RedirectToAction("Details/" + id);
        }
        // GET: Post/Create
        public ActionResult Create(int id)
        {
            if(Session["Usuario"] == null)
            {
                return RedirectToAction("../Usuario/Login", new { error = "Tienes que iniciar sesión para crear un post" });
            }
            Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
            IList<SelectListItem> enumLista = new List<SelectListItem>();
            for(int i=0; i < values.Length; i++)
            {
                enumLista.Add(new SelectListItem { Text = values.GetValue(i).ToString(), Value = i.ToString() });
            }

            ViewData["Categoria"] = enumLista;

            PostViewModel postVM = new PostViewModel();
            postVM.Comunidad = id;
            postVM.Categoria = -1;
            return View(postVM);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel post, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                post.Imagen = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images"), post.Imagen);
                file.SaveAs(path);
            }
            try
            {
                // TODO: Add insert logic here
                PostCP postCP = new PostCP();
                Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
                Categoria_PostEnum categoria = (Categoria_PostEnum)values.GetValue(post.Categoria);
                if (post.Imagen == null) post.Imagen = "";
                postCP.New_(post.Contenido, ((UsuarioEN)Session["Usuario"]).Id, post.Id, categoria, post.Titulo, post.Imagen, DateTime.Now);

                NotificacionCP notificacionCP = new NotificacionCP();
                NotificacionCEN notificacionCEN = new NotificacionCEN();
                int idNotificacion = notificacionCP.New_(post.Id).Id;
                notificacionCP.EnviarNotificacion(idNotificacion);
                
                string url = "../Comunidad/Details/" + post.Id;
                return RedirectToAction(url);
            }
            catch(Exception e)
            {
                ViewData["error"] = e.ToString();
                HandleErrorInfo error = new HandleErrorInfo(e, "Post", "Create");
                return RedirectToAction("../Home/Error", error);
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            PostEN postEN = new PostCEN().ReadOID(id);
            PostViewModel post = new PostAssembler().ConvertENToModelUI(postEN);

            Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
            IList<SelectListItem> enumLista = new List<SelectListItem>();
            for (int i = 0; i < values.Length; i++)
            {
                enumLista.Add(new SelectListItem { Text = values.GetValue(i).ToString(), Value = i.ToString() });
            }

            ViewData["Categoria"] = enumLista;

            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(PostViewModel post)
        {
            try
            {
                // TODO: Add update logic here
                PostCEN postCEN = new PostCEN();
                PostEN postEN = postCEN.ReadOID(post.Id);
                Array values = Enum.GetValues(new Categoria_PostEnum().GetType());
                Categoria_PostEnum categoria = (Categoria_PostEnum)values.GetValue(post.Categoria);
                if (post.Imagen == null) post.Imagen = "";
                postCEN.Modify(post.Id, post.Contenido, categoria, post.Titulo, post.Imagen, postEN.Hora, post.Likes);
                //postCEN.Modify(post.Id, post.Contenido, post.Categoria, post.Titulo, post.Imagen, post.Hora, post.Likes);
                string url = "../Comunidad/Details/" + post.Id;
                return RedirectToAction(url);
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);

            PostEN listEN = postCEN.ReadOID(id);
            PostViewModel postViewModel = new PostAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(postViewModel);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                new PostCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
