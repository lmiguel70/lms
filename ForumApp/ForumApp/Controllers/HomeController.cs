using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ForumApp.Models;

namespace ForumApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeModel user)
        {

            if (user != null && user.UserName != null && user.Password != null)
            {
                bool IsValidUser = GetDBContext().GetUsers()
                     .Any(u => u.UserName.ToLower() == u
                    .UserName.ToLower() && u
                    .Password == user.Password);

                if (IsValidUser)
                {
                    Session["user"] = user.UserName;
                    return RedirectToAction("Forum");
                }
                ViewBag.Error = "Invalid user name or password ";
            }
            else
                ViewBag.Error = "User name and password are required";
            return View();

        }


        public ActionResult Forum()
        {
            return View(GetForumPosts());
        }

        
        public ActionResult Create()
        {
            return RedirectToAction("Edit", new ForumModel());
        }

          
        public ActionResult Edit(string Id)
        {
            List<ForumModel> posts = GetForumPosts();
            ForumModel post = posts.Find(p => p.Id == int.Parse(Id));
            return View(post);
        }


        private DBContext GetDBContext()
        {
            DBContext dbContext = (DBContext)Session["dbcontext"];
            if (dbContext == null)
            {
                dbContext = new DBContext();
                Session["dbcontext"] = dbContext;
            }
            return dbContext;
        }

        List<ForumModel> GetForumPosts()
        {
            return GetDBContext().GetPosts();

        }
    }
}
