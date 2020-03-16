using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Null.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication_Null.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudent _student;

        public HomeController(IStudent student)
        {
            _student = student;
        }
        // GET: /<controller>/
        //public JsonResult Index()
        //{
        //    //_student.GetStudent(1);
        //    return Json(new { id=1,Name="s"});
        //}
        public string Index()
        {
            return _student.GetStudent(1).Name;
            
        }
    }
}
