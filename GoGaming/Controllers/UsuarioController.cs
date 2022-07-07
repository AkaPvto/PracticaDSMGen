using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoGaming.Assemblers;
using GoGaming.Models;
using PracticaDSMGenNHibernate.CAD.DSMPracticas;
using PracticaDSMGenNHibernate.CEN.DSMPracticas;
using PracticaDSMGenNHibernate.EN.DSMPracticas;

namespace GoGaming.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listEN = usuCEN.ReadAll(0, -1);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult Seguidores(int id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listEN = usuCEN.GetFollowing(id);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        public ActionResult Seguidos(int id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            IList<UsuarioEN> listEN = usuCEN.GetFollowed(id);
            IEnumerable<UsuarioViewModel> listViewModel = new UsuarioAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();

            return View(listViewModel);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = new UsuarioCEN().ReadOID(id);
            int seguidores = new UsuarioCEN().GetFollowing(id).Count;
            int seguidos = new UsuarioCEN().GetFollowed(id).Count;
            UsuarioViewModel usuarioVM = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);

            ViewData["seguidores"] = seguidores;
            ViewData["seguidos"] = seguidos;
            bool siguiendo = false;
            if (Session["Usuario"] != null)
            {
                IList<UsuarioEN> listEN = usuarioCEN.GetFollowed(((UsuarioEN)Session["Usuario"]).Id);
                siguiendo = listEN.Contains(usuarioCEN.ReadOID(id));
            }

            
            ViewData["Siguiendo"] = siguiendo;
            return View(usuarioVM);
        }

        // POST: Usuario/Details/5
        public ActionResult Seguir(int idFollower, int idFollowed)
        {
            try
            {
                // TODO: Add delete logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                IList<UsuarioEN> listEN = usuarioCEN.GetFollowing(idFollowed);
                
                bool siguiendo = listEN.Contains(usuarioCEN.ReadOID(idFollower));

                if (siguiendo)
                {
                    usuarioCEN.DeleteFollowing(idFollowed, new List<int>() { idFollower });
                }
                else
                {
                    usuarioCEN.AddFollowing(idFollowed, new List<int>() { idFollower });
                }
                return RedirectToAction("Details/"+idFollowed);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id, string error)
        {
            UsuarioEN usuarioEN = new UsuarioCEN().ReadOID(id);
            UsuarioViewModel usuarioVM = new UsuarioAssembler().ConvertENToModelUI(usuarioEN);
            if (error == null) error = "";
            ViewData["Error"] = error;


            return View(usuarioVM);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuario, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                usuario.Foto = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images"), usuario.Foto);
                file.SaveAs(path);

            }
            try
            {
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                IList<UsuarioEN> lista = usuarioCEN.ReadAll(0, -1);
                List<string> listaNicknames = new List<string>();
                string errorString = "";
                foreach (UsuarioEN usu in lista)
                {
                    listaNicknames.Add(usu.Nickname);
                }
                if (((UsuarioEN)Session["Usuario"]).Nickname != usuario.Nickname && listaNicknames.Contains(usuario.Nickname))
                {
                    errorString += "El nickname introducido esta en uso";
                }
                if (errorString == "")
                {
                    usuarioCEN.Modify(usuario.Id, usuario.Nickname, usuario.Nombre, usuario.Apellidos, usuario.Telefono, usuario.Direccion, usuario.Foto);
                    UsuarioEN nuevoUsu = usuarioCEN.ReadOID(usuario.Id);
                    Session["Usuario"] = nuevoUsu;
                    return RedirectToAction("Details/"+usuario.Id);
                }
                else
                {
                    return RedirectToAction("Edit", "Usuario", new { id = usuario.Id, error = errorString });
                }
            }
            catch(Exception e)
            {
                string exp = e.ToString();
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        public ActionResult Login(string error)
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            usuarioVM.Apellidos = "";
            usuarioVM.Direccion = "";
            usuarioVM.Email = "";
            usuarioVM.Foto = "";
            usuarioVM.Nickname = "";
            usuarioVM.Nombre = "";
            usuarioVM.Password = "";
            ViewData["Error"] = error;
            return View(usuarioVM);
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel usuario)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            int idUsuario = usuarioCEN.GetUsuarioEmail(usuario.Email).Id;
            string loginResult = usuarioCEN.Login(idUsuario, usuario.Password);

            if(loginResult != null)
            {
                UsuarioEN usuarioEN = usuarioCEN.ReadOID(idUsuario);
                if (usuarioEN.Baneado)
                {
                    return RedirectToAction("Login", "Usuario", new { error = "Baneado" });
                }
                else
                {
                    Session["Usuario"] = usuarioEN;
                    return RedirectToAction("../");
                }
                
            }
            else
            {
                return RedirectToAction("Login", "Usuario", new { error = "El usuario o la contrasenia no son correctos"});
            }
        }

        public ActionResult Register(string error)
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            usuarioVM.Apellidos = "";
            usuarioVM.Direccion = "";
            usuarioVM.Email = "";
            usuarioVM.Foto = "";
            usuarioVM.Nickname = "";
            usuarioVM.Nombre = "";
            usuarioVM.Password = "";
            ViewData["Error"] = error;
            return View(usuarioVM);
        }

        [HttpPost]
        public ActionResult Register(UsuarioViewModel usuario, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                usuario.Foto = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Images"), usuario.Foto);
                file.SaveAs(path);

            }
            else
            {
                usuario.Foto = "usuario.png";
            }
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> lista = usuarioCEN.ReadAll(0, -1);
            List<string> listaNicknames = new List<string>();
            string errorString = "";
            foreach(UsuarioEN usu in lista)
            {
                listaNicknames.Add(usu.Nickname);
            }
            if (usuarioCEN.GetUsuarioEmail(usuario.Email) != null)
            {
                errorString += "El email introducido esta en uso";
            }
            if(listaNicknames.Contains(usuario.Nickname))
            {
                if(errorString == "") errorString += "El nickname introducido esta en uso";
                else errorString += " y el nickname introducido esta en uso";
            }

            if(errorString == "")
            {
                int idUsuario = usuarioCEN.New_(usuario.Nickname, usuario.Nombre, usuario.Apellidos, usuario.Email, usuario.Telefono, usuario.Direccion, usuario.Foto, usuario.Password, false);
                UsuarioEN nuevoUsu = usuarioCEN.ReadOID(idUsuario);
                Session["Usuario"] = nuevoUsu;
                return RedirectToAction("../");
            }
            else
            {
                return RedirectToAction("Register", "Usuario", new { error = errorString });
            }
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("../");
        }
    }
}
