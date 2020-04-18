using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQStudy
{
   public class UnitTest
    {
        public static void Main(string[] args) {
            Lesson2();
        }

        [Fact]
        public static void Lesson2() {
            var lesson = new Lesson2();
            lesson.Test();
           Assert.True(true);
        }
    }
}
