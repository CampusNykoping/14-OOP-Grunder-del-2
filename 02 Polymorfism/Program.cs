using System;

namespace _02_Polymorfism
{
    class Animal
    {
        public virtual void AnimalSound()
        {
            Console.WriteLine("Djuret ger ett ljud");
        }
    }

    class Cat : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Katten säger Mjau");
        }
    }
    class Dog : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Hunden säger Vov!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Lägg tre djur (olika!) i en array. Bara för att vi kan
            Animal[] animals = new Animal[3];

            animals[0] = new Animal();
            animals[1] = new Cat();
            animals[2] = new Dog();

            foreach (var animal in animals)
            {
                animal.AnimalSound();
            }



            Console.ReadKey();
        }
    }
}
