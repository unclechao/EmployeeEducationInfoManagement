using EmployeeEducationInfo.BLL;
using EmployeeEducationInfo.IBLL;
using EmployeeEducationInfo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.EmployeeEducationInfo.Controllers
{
    public class HomeController : Controller
    {
        IAdminService adminService = new AdminService();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //data validate
            if (admin == null || string.IsNullOrEmpty(admin.Id.ToString()) || string.IsNullOrEmpty(admin.Password))
            {
                return View("Index");
            }

            var res = adminService.GetAllAdmins().Where(m => m.Name == admin.Name).SingleOrDefault();
            if (res != null)
            {
                //username exist
                if (res.Password == admin.Password)
                {
                    if (res.ErrorTime <= 5)
                    {
                        //login success
                        Session[admin.Name] = "login";
                        TempData.Clear();
                        TempData.Add("loginInfo", admin.Name);
                        return RedirectToAction("Index", "EmployeeEducationInfo");
                    }
                }
                else
                {
                    //password error
                    res.ErrorTime++;
                    return View("Index");
                }
            }
            //username not found
            return View("Index");
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
