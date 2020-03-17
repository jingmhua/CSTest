using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Null.Models;
using WebApplication_Null.ViewModels;

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

        /// <summary>
        /// 默认值， 返回值改成string了。 
        /// </summary>
        /// <returns></returns>
        //public string Index()
        //{
        //    return _student.GetStudent(1).Name;

        //}
        public IActionResult Index()
        {
            return View(_student.GetAllStudents());

        }

        /// <summary>
        ///当返回的view里没有其他页面地址时， 返回方法名同名页面。 具体拼配是 本controller的前缀名词（去除controller）之后再加上方法名： 比如本controller本方法对应的是：http://localhost:5000/home/details
        ///当返回的view里有其他页面地址，那就跳转到对应地址
        /// </summary>
        /// <returns></returns>
        public IActionResult Details()
        {

            var student = _student.GetStudent(1);
            //使用ViewData给view传递值(弱类型)
            ViewData["PageTitle"] = "fuck";
            ViewData["Student"] = student;

            //使用ViewBag给view传递值(弱类型)
            ViewBag.PageTitle = "you";
            ViewBag.Student = student;

            //return View();//弱类型使用这个


            //return View(student);//强类型使用这个

            HomeDetailsViewModel hdvm = new HomeDetailsViewModel(student, "viewmodel");
            return View(hdvm);





        }
    }
}
