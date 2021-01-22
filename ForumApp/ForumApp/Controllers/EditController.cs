using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using ForumApp.Models;

namespace ForumApp.Controllers
{
    public class EditController : Controller
    {
        public ActionResult Save(ForumModel model, string save, string cancel)
        {
            if (!string.IsNullOrEmpty(save))
            {
                if (model.Id == 0)
                    GetDBContext().InsertPost(model,(string) Session["user"]);
                else
                    GetDBContext().UpdatePost(model);
            }
            return RedirectToAction("Forum", "Home");
        }

        private DBContext GetDBContext()
        {
            return (DBContext)Session["dbcontext"];
   
        }
    }
}
