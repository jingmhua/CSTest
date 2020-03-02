using System;
using System.Collections.Generic;
using System.Text;

namespace CSTest
{
    //测试用的类
    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("void function : Report()");
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }
}
