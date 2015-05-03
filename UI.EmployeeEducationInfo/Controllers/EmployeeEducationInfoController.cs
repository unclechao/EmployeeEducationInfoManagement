using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeEducationInfo.Model;
using EmployeeEducationInfo.IBLL;
using EmployeeEducationInfo.BLL;

namespace UI.EmployeeEducationInfo.Controllers
{
    public class EmployeeEducationInfoController : Controller
    {
        IEmployeeService employeeService = new EmployeeService();
        IEducationInfoService educationInfoService = new EducationInfoService();
        //
        // GET: /EmployeeEducationInfo/

        public ActionResult Index()
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);
            return View(employeeService.GetAllEmployees());
        }

        //
        // GET: /EmployeeEducationInfo/Create

        public ActionResult Create()
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);
            return View();
        }

        //
        // POST: /EmployeeEducationInfo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);

            //data validate
            if (employee == null || string.IsNullOrEmpty(employee.Id.ToString()) || string.IsNullOrEmpty(employee.Name))
            {
                return View("Index", employeeService.GetAllEmployees());
            }

            if (Request["sdate"] != null && Request["edate"] != null && Request["eduexp"] != null)
            {
                var sdateArr = Request["sdate"].Split(',');
                var edateArr = Request["edate"].Split(',');
                var eduexpArr = Request["eduexp"].Split(',');
                for (int i = 0; i < sdateArr.Length; i++)
                {
                    DateTime temp;
                    if (DateTime.TryParse(sdateArr[i], out temp) && DateTime.TryParse(edateArr[i], out temp))
                    {
                        EducationInfo eduInfo = new EducationInfo();
                        eduInfo.StartTime = Convert.ToDateTime(sdateArr[i]);
                        eduInfo.EndTime = Convert.ToDateTime(edateArr[i]);
                        eduInfo.Education = eduexpArr[i];
                        eduInfo.IsDel = false;
                        eduInfo.EmployeeId = employee.Id;
                        employee.EducationInfo.Add(eduInfo);
                    }
                    else
                    {
                        return View("Index", employeeService.GetAllEmployees());
                    }
                }
            }
            employeeService.InsertEmployee(employee);
            return RedirectToAction("Index");
        }

        //
        // GET: /EmployeeEducationInfo/Edit/5

        public ActionResult Edit(int id)
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);

            //data validate
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return View("Index", employeeService.GetAllEmployees());
            }

            Employee employee = employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /EmployeeEducationInfo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);

            //data validate
            if (employee == null || string.IsNullOrEmpty(employee.Id.ToString()) || string.IsNullOrEmpty(employee.Name))
                return View("Index", employeeService.GetAllEmployees());

            //Add new education info
            if (Request["sdate"] != null && Request["edate"] != null && Request["eduexp"] != null)
            {
                var sdateArr = Request["sdate"].Split(',');
                var edateArr = Request["edate"].Split(',');
                var eduexpArr = Request["eduexp"].Split(',');
                for (int i = 0; i < sdateArr.Length; i++)
                {
                    DateTime temp;
                    if (DateTime.TryParse(sdateArr[i], out temp) && DateTime.TryParse(edateArr[i], out temp))
                    {
                        EducationInfo eduInfo = new EducationInfo();
                        eduInfo.StartTime = Convert.ToDateTime(sdateArr[i]);
                        eduInfo.EndTime = Convert.ToDateTime(edateArr[i]);
                        eduInfo.Education = eduexpArr[i];
                        eduInfo.IsDel = false;
                        eduInfo.EmployeeId = employee.Id;
                        var emp = educationInfoService.GetAllEducationInfos().OrderBy(s => s.Id).Skip(educationInfoService.GetAllEducationInfos().Count() - 1).SingleOrDefault();
                        if (emp != null)
                            eduInfo.Id = emp.Id + 1;
                        else
                            eduInfo.Id = 1;
                        employee.EducationInfo.Add(eduInfo);
                    }
                    else
                    {
                        return View("Index", employeeService.GetAllEmployees());
                    }
                }
            }
            #region
            ////Edit exist education info
            //if (Request["ready4update"] != null || Request["ready4delete"] != null)
            //{
            //    string[] ready4updateArr = null;
            //    string[] ready4deleteArr = null;
            //    var idArr = Request["EducationInfo.Id"].Split(',');
            //    var startTimeArr = Request["EducationInfo.StartTime"].Split(',');
            //    var endTimeArr = Request["EducationInfo.EndTime"].Split(',');
            //    var educationArr = Request["EducationInfo.Education"].Split(',');
            //    if (Request["ready4update"] != null)
            //        ready4updateArr = Request["ready4update"].Split(',');
            //    if (Request["ready4delete"] != null)
            //        ready4deleteArr = Request["ready4delete"].Split(',');
            //    for (int i = 0; i < idArr.Length; i++)
            //    {
            //        if (ready4deleteArr != null && ready4deleteArr.Contains(idArr[i]))
            //        {
            //            //Do delete
            //            int id = Convert.ToInt32(idArr[i]);
            //            EducationInfo eduInfo = educationInfoService.GetEducationInfoById(id);
            //            eduInfo.IsDel = true;
            //        }
            //        if (ready4updateArr != null && ready4updateArr.Contains(idArr[i]))
            //        {
            //            //Do update
            //            int id = Convert.ToInt32(idArr[i]);
            //            EducationInfo eduInfo = educationInfoService.GetEducationInfoById(id);
            //            eduInfo.StartTime = Convert.ToDateTime(startTimeArr[i]);
            //            eduInfo.EndTime = Convert.ToDateTime(endTimeArr[i]);
            //            eduInfo.Education = educationArr[i];
            //        }
            //    }
            //}
            #endregion
            employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        //
        // GET: /EmployeeEducationInfo/Delete/5

        public ActionResult Delete(int id)
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);

            //data validate
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return View("Index", employeeService.GetAllEmployees());
            }

            var employee = employeeService.GetEmployeeById(id);
            return View(employee);
        }

        //
        // POST: /EmployeeEducationInfo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (TempData["loginInfo"] == null)
                return RedirectToAction("Index", "Home");
            string userName = TempData["loginInfo"].ToString();
            if (Session[userName] == null)
                return RedirectToAction("Index", "Home");
            TempData.Clear();
            TempData.Add("loginInfo", userName);

            //data validate
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return View("Index", employeeService.GetAllEmployees());
            }

            employeeService.DeleteEmployeeoById(id);
            return RedirectToAction("Index");
        }
    }
}