using System;
using Xunit;

namespace Demo05
{
    public class RefTypeTests
    {
        void Swap<T>(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }

        [Fact]
        public void TestRefType()
        {
            double a =20.9;
            double b = 12.4;

            Swap(ref a, ref b);

            Assert.Equal(12.4, a, 2);
        }

        void AreaPerimeter(double r, out double area, out double perimeter)
        {
            perimeter = 2 * Math.PI * r;
           
             area = Math.PI * r * r;
        }


        [Fact]
        public void TestOutType()
        {
            double r = 7;
            double a = 0;
            double p;

            AreaPerimeter(r, out a, out p);

            Assert.Equal(44, p,1);
            Assert.Equal(153.9, a,1);

        }
    }
}



