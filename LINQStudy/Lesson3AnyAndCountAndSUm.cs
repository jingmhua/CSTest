using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy
{
    /// <summary>
    /// 
    /// </summary>
    class Lesson3AnyAndCountAndSUm
    {

        public void Test()
        {
            //var input = SequenceFromConsle().Select(x => int.Parse(x));
            //foreach (var item in input)
            //{
            //    Console.WriteLine($"\t {item}");

            //}
            TestAggregate();
        }

        public void TestCount()
        {
            Console.WriteLine(SequenceFromConsle().Count(x=> x=="1"));

        }
        public void TestAny()
        {
            Console.WriteLine(SequenceFromConsle().Any(x => x.Contains("hello")));
            return;
        }
        public void TestAll()
        {
            Console.WriteLine(SequenceFromConsle().All(x => x.Contains("1")));
            return;
        }
        public void TestSum()
        {
            Console.WriteLine(SequenceFromConsle().Select(x=>int.Parse(x)).Sum());
            return;
        }

        public void TestAggregate()
        {
            //Console.WriteLine(SequenceFromConsle().Select(x => int.Parse(x)).Aggregate((partialSum, item) => partialSum + item*10));
            //Console.WriteLine(SequenceFromConsle().Select(x => int.Parse(x)).Aggregate(10,(partialSum, item) => partialSum + item * 10));
            Console.WriteLine(SequenceFromConsle().Select(x => int.Parse(x)).Aggregate("this", (partialSum, item) => partialSum + ","+item )); ;

            return;
        }
        public IEnumerable<string> SequenceFromConsle()
        {
            string text = default(string);

            //default(string);
            while (text != "done")
            {
                text = Console.ReadLine();
                if (text != "done")
                    yield return text;

            }

        }
    }


    public static class Lesson3AnyAndCountStatic
    {
        /// <summary>
        /// any是遍历过程中只要有一个就返回true，遍历完成后没有就返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<T>(this IEnumerable<T> sequence, Func<T, bool> predicate = default)
        {
            //如果有next则返回true
            //return sequence.GetEnumerator().MoveNext();
            return sequence.Where(predicate).GetEnumerator().MoveNext();
        }

        /// <summary>
        /// all是遍历每个，如果不符合条件就返回false。 符合这继续看下一个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool All<T>(this IEnumerable<T> sequence, Func<T, bool> predicate = default) {

            
            //return sequence.Where(predicate).Count();
            return false;
          


        }

        //这个可不是IEnumerable类型的了， 是返回的int
        public static int Count<T>(this IEnumerable<T> sequence, Func<T, bool> predicate = default)
        {
            return sequence.Where(predicate).Count();
        }

        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {

                count++;

            }
            return count;
        }

        public static int Sum(this IEnumerable<int> sequence) {
            int sum = 0;
            foreach (var item in sequence)
            {
                sum += item;

            }
            return sum;
        }

        //从seed基础上往上sum
        public static int Sum(this IEnumerable<int> sequence,int seed)
        {
            int sum = seed;
            foreach (var item in sequence)
            {
                sum += item;

            }
            return sum;
        }
        //public static int Aggregate(this IEnumerable<int> sequence, Func<int, bool> predicate) {
        //    return sequence.Where(predicate).Sum();
        //}

        public static int Aggregate(this IEnumerable<int> sequence, Func<int, int,int> func)
        {
            var sum = 0;
            foreach (var item in sequence)
            {
                sum = func(sum,item);
            }
            return sum;
        }

        public static TResult Aggregate<TSource, TResult>(this IEnumerable<TSource> sequence,  Func<TResult, TSource, TResult> func)
        {

            var sum = default(TResult);
            var enumerator = sequence.GetEnumerator();
            while (enumerator.MoveNext()) { 
            sum= func(sum, enumerator.Current);
                return sum;
            }
            return default(TResult);
            
        }

        public static TResult Aggregate<TSource,TResult>(this IEnumerable<TSource> sequence, TResult seed, Func<TResult, TSource, TResult> func)
        {
            var sum = seed;
            foreach (var item in sequence)
            {
                sum = func(sum, item);
            }
            return sum;
        }

        public static T Aggregate<T>(this IEnumerable<T> sequence, Func<T, T, T> func)
        {
            var sum = default(T);
            foreach (var item in sequence)
            {
                sum = func(sum, item);
            }
            return sum;
        }

        public static int Aggregate(this IEnumerable<int> sequence,int seed, Func<int, int, int> func)
        {
            var sum = seed;
            foreach (var item in sequence)
            {
                sum = func(sum, item);
            }
            return sum;
        }
    }

}
