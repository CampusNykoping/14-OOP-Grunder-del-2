using System;

namespace _01_Virtuella_metoder
{
    class BaseClass
    {
        public virtual void Draw()
        {
            Console.WriteLine("BaseClass.Draw");
        }
    }
    class DerivedClass : BaseClass
    {
        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine("DerivedClass.Draw");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass mittObjekt = new DerivedClass();
            BaseClass mittAndraObjekt = new DerivedClass();

            mittObjekt.Draw();                  // DerivedClass.Draw
            mittAndraObjekt.Draw();             // DerivedClass.Draw


            Console.ReadKey();
        }
    }
}
