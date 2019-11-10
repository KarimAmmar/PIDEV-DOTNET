using Solution.Domain.Entities;
using Solution.Presentation.Models;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Controllers
{
    public class CommentController : Controller
    {
        IPostService Ser = null;

        ICommentService Service = null;
        public CommentController()
        {
            Service = new CommentService();
            Ser = new PostService();
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create/{idP}
        public ActionResult Create(int idP)
        {
            return View();
        }

        // POST: Comment/Create/{idP}
        [HttpPost]
        public ActionResult Create(CommentVM fvm, int idP)
        {
            Comment c = new Comment()
            {
                CommentId=fvm.CommentId,
                PostId = idP,
                UserId = fvm.UserId,
                Content = fvm.Content,
                CommentDate= DateTime.Today,
            NbrLikes = 0
            };
            Service.Add(c);
            Service.Commit();
            Post post = Ser.GetById(idP);
            post.Comments.Add(c);
            //return RedirectToRoute("Post/Details/"+idP);
            return Redirect("~/Post/Details/"+idP);
            /*return RedirectToRoute(new
            {
                controller = "Post",
                action = "Details",
                id = idP
            });*/
        }

        // GET: Comment/Edit/5/{idP}
        public ActionResult Edit(int id,int idP)
        {
            Comment comment = Service.GetById(id);
            CommentVM c = new CommentVM();
            c.PostId = comment.PostId;
            c.CommentId = comment.CommentId;
            c.UserId = comment.UserId;
            c.Content = comment.Content;
            
            c.CommentDate = comment.CommentDate;
            c.NbrLikes = comment.NbrLikes;

            return View(c);
        }

        // POST: Comment/Edit/5/{idP}
        [HttpPost]
        public ActionResult Edit(int id, PostVM fvm,int idP)
        {
            Post post = Ser.GetById(idP);
            Comment p = Service.GetById(id);
            
            
            p.Content = fvm.Content;
            p.PostId = idP;
            p.CommentDate = DateTime.Today;
            
            Service.Update(p);
            
            Service.Commit();
            
            /*foreach (Comment o in post.Comments)
            {
                if (o.CommentId == id)
                    post.Comments.Remove(o);
            }*/
            //post.Comments.Add(p);
            //postt.Comments.Remove(postt.Comments.First(x=>x.CommentId==id));
            //postt.Comments.Add(p);
            //Ser.GetById(idP).Comments.Where(x=>x.CommentId==p.CommentId).up
            //postt.Comments = com;


            //Service.Dispose();
            //int a = (int)p.PostId;
            //Post post = Ser.GetById(idP);
            //post.Comments.Add(p);

            return Redirect("~/Post/Details/" + idP);


        }

        // GET: Comment/Delete/5/{idP}
        public ActionResult Delete(int id,int idP)
        {
            Comment pl = Service.GetById(id);



            if (Service.GetById(id) == null)

            {

                return HttpNotFound();

            }

            return View(pl);
            //return View();
        }

        // POST: Comment/Delete/5/{idP}
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection,int idP)
        {
            Comment pl = Service.GetById(id);
            pl.PostId = null;
            Service.Delete(pl);
            Service.Commit();
            //Service.Dispose();
            //Ser.Dispose();
            //PostController pc = new PostController();
            //return pc.Details(idP);
            return Redirect("~/Post/Details/" + idP);
        }
    }
}
