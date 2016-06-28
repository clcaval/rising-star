using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RISING.STAR.Business.Common;
using RISING.STAR.Utils.Password;
using RISING.STAR.WebApp.ActionFilters;

namespace RISING.STAR.WebApp.Controllers
{

    public class LoginView {

        public string User {get;set;}
        public string Password {get;set;}

    }

    public class ReturnedData
    {

        public bool IsAuth { get; set; }
        public String Message { get; set; }

    }
     [RBAC]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        // Login/
        [HttpPost]
        public ActionResult TryLogin(LoginView loginViewModel)
        {

            var commomBuss = new CommonBusiness();
            var isAuth = commomBuss.CheckLogin(loginViewModel.User, loginViewModel.Password);
            var retData = new ReturnedData();

            if(isAuth)
            {
                retData.IsAuth = isAuth;
                retData.Message = "OK";
            }
            else
            {
                retData.IsAuth = isAuth;
                retData.Message = "Not OK";
            }

            return Json(retData);
        }


        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
    }
}
