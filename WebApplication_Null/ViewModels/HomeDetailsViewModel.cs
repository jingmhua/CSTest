using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Null.Models;

namespace WebApplication_Null.ViewModels
{
    public class HomeDetailsViewModel
    {
        public HomeDetailsViewModel(Student Student, string PageTitle)
        {
            this.Student = Student;
            this.PageTitle = PageTitle;
        }
        public Student Student { get; set; }
        public string PageTitle { get; set; }
    }
}
