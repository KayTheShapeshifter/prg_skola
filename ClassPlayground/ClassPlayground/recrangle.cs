using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class recrangle
    {
        public int width;
        public int height;
        public recrangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public recrangle()
        {

        }
        public void calculateArea()
        {
            int area = width * height;
            Console.WriteLine("obsah je " + area);
        }
        public void calculateAspectRatio()
        {
            double aspectRatio = width / height;
            if (aspectRatio<1)
            {
                Console.WriteLine("je vysoký");
            }
            else if (aspectRatio > 1)
            {
                Console.WriteLine("je široký");
            }
            else
            {
                Console.WriteLine("čtverec");
            }
            Console.WriteLine("poměr stran je " + aspectRatio);
        }
        public void containsPoint(int x, int y)
        {
            if (x <= width && y <= height) 
            {
                Console.WriteLine("bod je vevnitř");
            }
            else 
            { 
                Console.WriteLine("bod není vevnitř"); 
            }
        }
    }
}
