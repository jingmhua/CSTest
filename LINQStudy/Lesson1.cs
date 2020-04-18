using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQStudy
{
    /// <summary>
    /// 1、Enumerable and collection is not the same.
    /// 2、Presents Ienumberable 
    /// 3 sequence and collection is not the same. collection could store data, but sequence not.
    /// </summary>
    class Lesson1
    {
        static void test1(string[] args)
        {
            //foreach (var item in GenerateStrings())
            //{
            //    Console.WriteLine(item);
            //}

            //var sequence = GenerateStrings();
            //var iterator = sequence.GetEnumerator();

            //for (int i = 0; i < 100; i++)
            //{
            //    iterator.MoveNext();
            //    Console.WriteLine(iterator.Current);
            //}

            //foreach (var item in GenerateStrings().Take(100))
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in GenerateStrings(()=> { int i = 0; return i++.ToString(); }).Take(100))
            //{
            //    Console.WriteLine(item);
            //}


            /*

            //结果出现是50到149，因为是lazy执行的， 当执行到foreach里面使用sequence变量后， 这个时候i已经是50了。
            //应该有闭包的问题？
            int i = 0;
            var sequence = GenerateStrings(() => { return i++.ToString(); });//括号里面的传入是的方法，走的是lamda表达式  i++.toString()， 这个是先tostring，之后再++
            i = 50;
            foreach (var item in sequence.Take(100))
            {
                Console.WriteLine(item);
            }
            */


            /*
            int i = 0;
            var sequence = GenerateStrings(() => { return i++.ToString(); });//括号里面的传入是的方法，走的是lamda表达式  i++.toString()， 这个是先tostring，之后再++
            foreach (var item in sequence.Take(100))
            {
                //从GenerateStrings方法出来后， i这个时候就++了。所以第一次到这个时候， i是1
                i += 10;//如果添加这个， 会引起闭包问题??。 因为当前的sequence变量是lazy， 且是序列（IEnumerable<string>）
                Console.WriteLine(item);
            }
            */


            int i = 0;
            var sequence = GenerateStrings(() => { return DateTime.Now; });//括号里面的传入是的方法，走的是lamda表达式  i++.toString()， 这个是先tostring，之后再++
            foreach (var item in sequence.Take(100))
            {
                //从GenerateStrings方法出来后， i这个时候就++了。所以第一次到这个时候， i是1
                i += 10;//如果添加这个， 会引起闭包问题??。 因为当前的sequence变量是lazy， 且是序列（IEnumerable<string>）
                Console.WriteLine(item);
            }






            /*
             * 调用下面内容会oom。 因为list是存到内存的， maxvalue会爆。 但IEnumerable的list是一个枚举list，一个一个传过来。 不存入内存。 
            var list = GenerateStringsList();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(list[i]);

            }
            */

        }


        //因为是list， 他是存入数据的， 返回个存入内存的list
        public static IEnumerable<T> GenerateStringsForList<T>(Func<T> itemGenerator)
        {
            var rVal = new List<T>();

            for (int i = 0; i < int.MaxValue; i++)
            {
                //yield return itemGenerator();
                rVal.Add(itemGenerator());

            }
            return rVal;

        }

        public static IEnumerable<T> GenerateStrings<T>(Func<T> itemGenerator)
        {

            for (int i = 0; i < int.MaxValue; i++)
            {
                yield return itemGenerator();

            }

        }
        public static IEnumerable<string> GenerateStrings()
        {

            for (int i = 0; i < int.MaxValue; i++)
            {
                yield return i.ToString();

            }

        }

        public static List<string> GenerateStringsList()
        {
            var list = new List<string>(int.MaxValue);
            for (int i = 0; i < int.MaxValue; i++)
            {
                list.Add(i.ToString());

            }
            return list;

        }
    }
}
