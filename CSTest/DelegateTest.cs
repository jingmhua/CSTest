using System;
using System.Collections.Generic;
using System.Text;

namespace CSTest
{/**
        委托是类，所以声明位置是和 class 处于同一个级别。但 C# 允许嵌套声明类（一个类里面可以声明另一个类），所以有时也会有 delegate 在 class 内部声明的情况。


         */

        //委托类
    public delegate double DelegateCalc(double x, double y);
    public delegate void dc();

    class DelegateTest
    {
        public static void DelegateTestMain(string[] args) {
            var calculator = new Calculator();
            var calc1 = new DelegateCalc(calculator.Mul);
            var calc2 = new dc(calculator.Report);
            calc2();

            //var a = new dc(calculator.Add);

            Console.WriteLine(calc1(5, 6));
            //Console.WriteLine(calc2);
        }

    }



}
