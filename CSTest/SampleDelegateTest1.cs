//using System;

//namespace CSTest
//{
//    /*
//     * 利用模板方法，提高代码复用性。 
//     * 相当于利用委托， 做填空题。
//     * 下例中 Product、Box、WrapFactory 都不用修改，只需要在 ProductFactory 里面新增不同的 MakeXXX 然后作为委托传入 WrapProduct 就可以对其进行包装。
//     */

//    class SampleDelegateTest1
//    {
//        public static void SampleDelegateTestMain(string[] args) {
//            var productFactory = new ProductFactory();

//            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
//            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

//            var wrapFactory = new WrapFactory();
//            Box box1 = wrapFactory.WrapProduct(func1);
//            Box box2 = wrapFactory.WrapProduct(func2);

//            Console.WriteLine(box1.Product.Name);
//            Console.WriteLine(box2.Product.Name);
//        }


//    }

//    class Product
//    {
//        public string Name { get; set; }
//    }

//    class Box
//    {
//        public Product Product { get; set; }
//    }

//    //包装工厂
//    class WrapFactory
//    {
//        // 模板方法，提高复用性
//        //Func的委托类为有返回值的那种，将Func作为参数传入
//        public Box WrapProduct(Func<Product> getProduct)
//        {
//            var box = new Box();
//            Product product = getProduct.Invoke();
//            box.Product = product;
//            return box;
//        }
//    }

//    class ProductFactory
//    {
//        public Product MakePizza()
//        {
//            var product = new Product();
//            product.Name = "Pizza";
//            return product;
//        }

//        public Product MakeToyCar()
//        {
//            var product = new Product();
//            product.Name = "Toy Car";
//            return product;
//        }
//    }
//}
