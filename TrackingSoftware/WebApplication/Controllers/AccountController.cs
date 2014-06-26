using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using WebMatrix.WebData;
using WebApplication.Models;
using BusinessLayer;

namespace WebApplication.Controllers {
    [Authorize]
    public class AccountController : Controller {

        protected IList<User> users;

        public AccountController()
            : base() {
                UserReopsitory repo = new UserReopsitory();
                users = repo.GetAll();
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl) {

            User current = null;

            if(ModelState.IsValid) 
                // find user with same data as in model
                foreach(var user in users) 
                    if(user.Username == model.UserName && user.Password == model.Password) {
                        current = user;
                        break;
                    }         

            if(current != null) {
                Session.Add("CurrentUser", current);
                FormsAuthentication.SetAuthCookie(current.Username, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            ModelState.AddModelError("", "Օգտատիրոջ անվան կամ գաղտնաբառի սխալ.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            Session["CurrentUser"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

      
     



        #region Helper Methods
        private ActionResult RedirectToLocal(string returnUrl) {
            if(Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            } else {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}
