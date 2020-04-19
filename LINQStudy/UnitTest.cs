using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQStudy
{
   public class UnitTest
    {
        public static void Main(string[] args) {
            Lesson3();
        }

        [Fact]
        public static void Lesson2() {
            var lesson = new Lesson2WhereAndSelect();
            lesson.Test();
           Assert.True(true);
        }
        [Fact]
        public static void Lesson3()
        {
            var lesson = new Lesson3AnyAndCountAndSUm();
            lesson.Test();
            
        }
    }
}
