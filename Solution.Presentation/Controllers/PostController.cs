using Solution.Presentation.Models;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Service;
using Solution.Domain.Entities;
using System.IO;
namespace Solution.Presentation.Controllers
{
    public class PostController : Controller
    {
        IPostService Service = null;
        ICommentService commentService = null;
        public PostController()
        {
            Service = new PostService();
            commentService = new CommentService();
        }
        // GET: Post
        public ActionResult Index(string search)
        {
            if (search != null)
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(Service.GetMany().Where(x => x.Content.Contains(search) || x.UrlImage.Contains(search) || x.PostDate.ToString().Contains(search)).OrderByDescending(x => x.PostId));
            }
            
            else
            {
                return View(Service.GetMany().OrderByDescending(x => x.PostId));
            }
            //return View(Service.GetMany().OrderByDescending(x => x.PostId));
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            Post post = Service.GetById(id);
            IEnumerable<Comment> c = commentService.GetCommentByPost(id);
            ViewBag.TotalComments = c;
            //post.Comments = (ICollection<Comment>)commentService.GetCommentByPost(id);
            return View(post);
        }
        // POST: Post/Details/5/like
        public ActionResult Like(int id)
        {
            Post p = Service.GetById(id);
            Service.LikePost(id);
            Service.Update(p);
            Service.Commit();
            return Redirect("~/Post/Details/" + id);
        }
        // POST: Post/Details/5/dislike
        public ActionResult DisLike(int id)
        {
            Post p = Service.GetById(id);
            Service.DisLikePost(id);
            Service.Update(p);
            Service.Commit();
            return Redirect("~/Post/Details/" + id);
        }
        // GET: Post/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostVM fvm, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid ||
                file == null ||
                file.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            
            Post p = new Post()
            {
                PostId = fvm.PostId,
                UserId = fvm.UserId,
                Content = fvm.Content,
                UrlImage = file.FileName,
                UrlVideo = "rien",
                PostDate = DateTime.Today,
                NbrLikes = 0
            };
            Service.Add(p);
            Service.Commit();
            //Service.Dispose();
            //ajout d'image sous dossier
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.
                    Combine(Server.MapPath("~/Content/Uploads/"),
                    fileName);
                file.SaveAs(path);
            }


            return RedirectToAction("Index");
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {

            Post post = Service.GetById(id);
            PostVM p = new PostVM();
            p.PostId = post.PostId;
            p.UserId = post.UserId;
            p.Content = post.Content;
            p.UrlImage = post.UrlImage;
            p.UrlVideo = post.UrlVideo;
            p.PostDate = post.PostDate;
            p.NbrLikes = post.NbrLikes;

            return View(p);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostVM fvm, HttpPostedFileBase file)
        {
            Post p = Service.GetById(id);
            p.Content = fvm.Content;
            p.UrlImage = file.FileName;
            p.UrlVideo = "rien";
            p.PostDate = DateTime.Today;

            Service.Update(p);
            Service.Commit();
            //Service.Dispose();
            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.
                    Combine(Server.MapPath("~/Content/Uploads/"),
                    fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            Post pl = Service.GetById(id);



            if (Service.GetById(id) == null)

            {

                return HttpNotFound();

            }

            return View(pl);
            //return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Post pl = Service.GetById(id);
            Service.Delete(pl);
            Service.Commit();

            return RedirectToAction("Index");
        }
    }
}
