using System;
using System.Collections.Generic;
using System.Text;

namespace CSTest
{
    class MainClass
    {

        static void Main(string[] args)
        {

            //SampleDelegateTest1.SampleDelegateTestMain(args);

            //IAction man = new Man(11);
            //man.Eat();
            //man.GetAge();

            Person p = Factory(11);
            if (p is Adult) {
                Adult a = (Adult)p;
                a.Sing();
            }

            Child child = new Child(12);//多态用这种 调用其子类的函数， 部分情况， 需要强转
            Adult man = new Adult(1,1);
            personDo(child);
            actionDo(man,man.Sex);
            //actionDo(child, child.Sex);

        }

       static void personDo(Person p) {
            if (p is Child) {
                Console.WriteLine("child");
            }
            if (p is Adult) {
                Console.WriteLine("adult");
            }

        }

        static void actionDo(IWork action,int sex) {
            if (sex == 1)
            {
                action.Work();
            }
            else {
                action.Sing();
            }

        }

        static Person Factory(int age) {
            if (age > 18)
            {
                return new Adult(age,1);
            }
            else {

                return new Child(age);
            }
        }
    }


    interface IWork {
        void Work();
        void Sing();

    }
    class Person {
        public int Age { get; set; }
        public virtual void Func1() {

        }

        public void Eat(Person person)
        {
            Console.WriteLine("Man is Eatting ");
        }
    }

    class Adult : Person, IWork
    {
        int sex;
        public Adult(int age,int sex) {
             this.Age = age;
            this.sex = sex;
        }
        public int Sex { get => sex; }
        public void GetAge() {
            Console.WriteLine("man"+ Age);
        }

        public void Work() {
            Console.WriteLine("man sleep");
        }
        public void Sing() {
            Console.WriteLine("man sleep");
        }

    }
    class Child : Person
    {
        public Child(int age)
        {

        }
        public void Eat()
        {
            Console.WriteLine("Woman is Eatting " );

        }

        public void GetAge()
        {
            Console.WriteLine("woman" + Age);
        }

        public void Work() {
            Console.WriteLine("woman sleep");
        }
        public void Sing() {
            Console.WriteLine("woman sing");
        }
    }
}
