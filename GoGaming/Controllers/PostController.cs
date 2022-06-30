﻿using GoGaming.Assemblers;
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

namespace GoGaming.Controllers
{
    public class PostController : BasicController
    {
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

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PostCAD postCAD = new PostCAD(session);
            PostCEN postCEN = new PostCEN(postCAD);

            PostEN listEN = postCEN.ReadOID(id);
            PostViewModel postViewModel = new PostAssembler().ConvertENToModelUI(listEN);
            SessionClose();
            return View(postViewModel);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            PostViewModel post = new PostViewModel();
            return View(post);
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel post)
        {
            try
            {
                // TODO: Add insert logic here
                PostCP postCP = new PostCP();
                postCP.New_(post.Contenido, 32770, 0000, post.Categoria, post.Titulo, post.Imagen, DateTime.Now);
                //postCP.New_(post.Contenido, ((UsuarioEN)Session["Usuario"]).Id, idComunidad, post.Categoria, post.Titulo, post.Imagen, DateTime.Now);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            PostViewModel post = null;
            SessionInitialize();
            PostEN postEN = new PostCAD(session).ReadOIDDefault(id);
            post = new PostAssembler().ConvertENToModelUI(postEN);
            SessionClose();
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
                postCEN.Modify(post.Id, post.Contenido, post.Categoria, post.Titulo, post.Imagen, DateTime.Now, post.Likes);
                //postCEN.Modify(post.Id, post.Contenido, post.Categoria, post.Titulo, post.Imagen, post.Hora, post.Likes);
                return RedirectToAction("Index");
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