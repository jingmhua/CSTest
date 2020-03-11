using System;
using System.Collections.Generic;
using System.Text;

namespace CSTest
{
    class SampleDelegateTest2
    {
        static void Main(string[] args)
        {
            var productFactory = new ProductFactory();

            // Func 前面是传入参数，最后一个是返回值，所以此处以 Product 为返回值
            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            var wrapFactory = new WrapFactory();
            var logger = new Logger();
            // Action 只有传入参数，所以此处以 Product 为参数
            Action<Product> log = new Action<Product>(logger.Log);

            Box box1 = wrapFactory.WrapProduct(func1, log);
            Box box2 = wrapFactory.WrapProduct(func2, log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }

    class Logger
    {
        public void Log(Product product)
        {
            // Now 是带时区的时间，存储到数据库应该用不带时区的时间 UtcNow。
            Console.WriteLine("Product '{0}' created at {1}.Price is {2}", product.Name, DateTime.UtcNow, product.Price);
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WrapFactory
    {
        // 模板方法，提高复用性
        public Box WrapProduct(Func<Product> getProduct, Action<Product> logCallBack)
        {
            var box = new Box();
            Product product = getProduct.Invoke();

            // 只 log 价格高于 50 的
            if (product.Price >= 50)
            {
                logCallBack(product);
            }

            box.Product = product;
            return box;
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            var product = new Product
            {
                Name = "Pizza",
                Price = 12
            };
            return product;
        }

        public Product MakeToyCar()
        {
            var product = new Product
            {
                Name = "Toy Car",
                Price = 100
            };
            return product;
        }
    }
}
