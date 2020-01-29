using System;
using System.Collections;
using System.Collections.Generic;

namespace Pets
{   public class Animals
    {
        public string Name;
        public enum Sex
        {
            male,
            Female
        };
        public Sex MySex;
        public DateTime Birthday;
        public static Animals operator ++(Animals animals)
        {
            animals.Birthday = animals.Birthday.AddYears(1);
            return animals;
        }
        public int Age
        {
            get
            {
                if (DateTime.Today.Month >= Birthday.Month)
                {
                    return DateTime.Today.Year - Birthday.Year;
                }
                else
                {
                    return DateTime.Today.Year - Birthday.Year - 1;
                }
            }
        }
        public string vid = " ";
        public Animals(string n, DateTime b, Sex My) { Name = n; Birthday = b; MySex = My;}
        public virtual void SayHello()
        {
            
            string say = String.Format("Привет, я животное{0}по имени {1}, мой возраст {2} лет, мой пол {3}",vid, Name, Age, MySex);
            //Console.WriteLine($"Привет, я животное {Name}, мой возраст {Age} лет, мой пол {MySex}");
            Console.WriteLine(say);
        }
    }

    public class Zebra : Animals
    {
        public Zebra(string n, DateTime b, Sex My) : base(n, b, My)
        {
        }

        public override void SayHello()
        {
            vid = " Зебра ";
            base.SayHello();
        }
        //public Zebra(string n, DateTime b, Sex My) { Name = n; Birthday = b; MySex = My; }

    }
    public class Elephant : Animals
    {
        public Elephant(string n, DateTime b, Sex My) : base(n, b, My)
        {
        }

        public override void SayHello()
        {
            vid = " Слон ";
            base.SayHello();
        }
        

    }

    public class Giraffe : Animals
    {
        public Giraffe(string n, DateTime b, Sex My) : base(n, b, My)
        {
        }

         public override void SayHello()
         {
             
        vid = " Жираф ";
            base.SayHello();
        }
       

    
    }
    public static class SayHelloAnimals
    {
        public static void SayHelloList(this List<Animals> l)
        {
            foreach(Animals i in l)
            {
                i.SayHello();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Animals Dog = new Animals("Doofy", new DateTime(2018, 7, 20), Animals.Sex.male);
            Dog.SayHello();
            Dog++;
            Dog.SayHello();
            Zebra zebra = new Zebra("Anny", new DateTime(2014, 7, 20), Animals.Sex.Female);
            zebra.SayHello();
            Elephant slon = new Elephant("Krasty", new DateTime(2012, 7, 20), Animals.Sex.male);
            slon.SayHello();
            Giraffe giraffe = new Giraffe("Melman", new DateTime(2017, 7, 20), Animals.Sex.male);
            giraffe.SayHello();
            Console.WriteLine("-------------------------------------------");
            var listOfAnimals = new List<Animals>()
            {
                new Animals("Doorry", new DateTime(2018, 7, 21), Animals.Sex.Female),
                new Animals("Cappa", new DateTime(2018, 8, 30), Animals.Sex.male),
                new Zebra("Anny", new DateTime(2014, 5, 12), Animals.Sex.Female),
                new Elephant("Krasty", new DateTime(2012, 2, 14), Animals.Sex.male),
                new Giraffe("Melman4", new DateTime(2017, 4, 01), Animals.Sex.male),
                new Zebra("Lilla", new DateTime(2014, 3, 10), Animals.Sex.Female),
                new Giraffe("Kate", new DateTime(2010, 1, 24), Animals.Sex.Female),
                new Giraffe("Harry", new DateTime(2008, 3, 09), Animals.Sex.male),
                new Elephant("Bender", new DateTime(2013, 12, 18), Animals.Sex.male),
            };

            listOfAnimals.SayHelloList();
             
        }
    }
}