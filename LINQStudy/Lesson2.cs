using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQStudy
{
    /// <summary>
    /// where and select
    /// </summary>
    class Lesson2
    {

        public  void Test() {

            int i = 50;

            //var  sequence=GenerateSequence(i, (j) => { return (++j); }).Select(x=>x).Where(s => s < 20);
            var sequence = GenerateSequence(i, (j) => { return (++j); }).Select((x, index) =>//注意：x和index顺序不能乱， 第二个是index
            new
            {
                index,
                formattedResult = x + "a"
            })//select的lamda 可以接受2个参数， 一个数据源的iterator，一个是索引
                .Where(s => s.index < 20);//这个where是调用本文件写的where



            foreach (var item in sequence)
            {
                Console.WriteLine(item);
            }
        }


        public static IEnumerable<T> GenerateSequence<T>(int maxValue,Func<int,T> itemGenerator)
        {

            for (int i = 0; i < maxValue; i++)
            {
                yield return itemGenerator(i);

            }

        }
    }

    public static class MyLinqImplementation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">参数中有this关键字， 是告诉C#这个是扩展方法。 当执行sequence.where的时候，无论该序列何种类型，where都是其成员
        /// Main方法里面的where方法，实际上就是调用下面的方法， 因为他是和where方法同名， 且在同一空间下。 这个实现的where方法， 比系统(bcl)带的方法更加接近Main方法。 
        /// 所以优先使用。 </param>
        /// <returns></returns>
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        /// <summary>
        /// IEnumerable<TResult> Select<TSource,TResult>， 其中的TResult是返回的泛型， TSource是传入的泛型。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Select<TSource,TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> map) {
            Console.WriteLine("Select Func<TSource,TResult>");
            foreach (var item in source)
            {
              
                yield return map(item);

            }
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int,TResult> map)
        {
            int index = 0;
            Console.WriteLine("Select Func<TSource, int,TResult> ");
            foreach (var item in source)
            {
                yield return map(item,index++);

            }
        }
    }
}
