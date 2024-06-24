using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Test
    {
        public void GetArea(double width,double height)
        {
            
            Console.WriteLine("Area of Rectangle:  {0}", +(width * height));

        }
        public void GetPerimeter(double width, double height)
        {
            
            Console.WriteLine("Perimeter of Rectangle:  {0}", +2*(width + height));

        }
    }
}
