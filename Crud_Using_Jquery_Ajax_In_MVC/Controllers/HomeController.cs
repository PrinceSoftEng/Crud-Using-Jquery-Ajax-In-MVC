using Crud_Using_Jquery_Ajax_In_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Crud_Using_Jquery_Ajax_In_MVC.Controllers
{
    public class HomeController : Controller
    {
        clsDBEmployeeModel objDbEmp = new clsDBEmployeeModel();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListAllEmployee()
        {
            return Json(objDbEmp.ListAllEmployee(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(clsEmployeeModel objEmpModel)
        {
            return Json(objDbEmp.AddEmployee(objEmpModel), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(clsEmployeeModel objEmpModel)
        {
            var objemployee = objDbEmp.ListAllEmployee().Find(x => x.EmpId.Equals(objEmpModel.EmpId));
            return Json(objemployee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(clsEmployeeModel objEmpModel)
        {
            return Json(objDbEmp.UpdateEmployee(objEmpModel), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(clsEmployeeModel objEmpModel)
        {
            return Json(objDbEmp.DeleteEmployee(objEmpModel), JsonRequestBehavior.AllowGet);
        }      
    }
}