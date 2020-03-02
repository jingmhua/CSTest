using System;

namespace CSTest
{
    /**
     * Action 和 Func 是 C# 内置的委托实例，它们都有很多重载以方便使用。
     * 
     * */
    class ActionAndFun
    {
        static void Main(string[] args)
        {
            var cal = new Calculator();
            // Action 用于无形参无返回值的方法。
            Action action = new Action(cal.Report);
            //cal.Report();//调用原来的函数
            //action.Invoke();//action方式调用。
            // 模仿函数指针的简略写法。
            action();
            Func<int, int, int> func1 = new Func<int, int, int>(cal.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(cal.Sub);

            int x = 100;
            int y = 200;
            int z = 0;

            z = func1.Invoke(x, y);
            Console.WriteLine(z);
            z = func2.Invoke(x, y);
            Console.WriteLine(z);

            // Func 也有简略写法。
            z = func1(x, y);
            Console.WriteLine(z);
            z = func2(x, y);
            Console.WriteLine(z);
        }
    }

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
    }
}
