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
        public Animals() { }
        public virtual void SayHello()
        {
            
            string say = String.Format("Привет, я животное{0}по имени {1}, мой возраст {2} лет, мой пол {3}",vid, Name, Age, MySex);
            //Console.WriteLine($"Привет, я животное {Name}, мой возраст {Age} лет, мой пол {MySex}");
            Console.WriteLine(say);
        }
    }

    public class Zebra : Animals
    {
        public Zebra(string n, DateTime b, Sex My) : base(n, b, My) { }
        public Zebra() { }
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
        { }
        public Elephant() { }
        public override void SayHello()
        {
            vid = " Слон ";
            base.SayHello();
        }
        

    }

    public class Giraffe : Animals
    {
        public Giraffe(string n, DateTime b, Sex My) : base(n, b, My) { }
        public Giraffe() { }
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
        static void ListOfZebra(List<Animals> ts)
        {
            foreach (var i in ts)
            {
                if (i.GetType() == new Zebra().GetType()) { i.SayHello(); }
            }
        }
        static void ListOfOlder2(List<Animals> ts)
        {
            
            foreach (var i in ts)
            {
                if (i.Age>2) { i.SayHello(); }
            }
        }
        static void UniqueNames(List<Animals> ts)
        {
            var listNames = new List<string>();
            int s=0;
            foreach (var i in ts)
            {
                s++;
                listNames.Add(i.Name);
            }
            listNames.Sort();
            for (int d = 1; d < s ; d++)
            {
                for (int i = 1; i < s; i++)
                {
                    if (listNames[i] == listNames[i - 1]) { listNames.RemoveAt(i); s--; }
                }
            }

            foreach (var i in listNames)
            {
                Console.WriteLine(i);
            }
        }
        static void BirthdayElephant(List<Animals> ts)
        {
            foreach (var i in ts)
            {
                if (i.GetType() == new Elephant().GetType()) { Console.WriteLine(i.Birthday); }
            }
        }

        static void AgeClass(List<Animals> ts)
        {
            var listClass = new List<string>();
            int s = 0;
            foreach (var i in ts)
            {
                s++;
                listClass.Add(i.GetType().Name);
            }
            listClass.Sort();
            int s1 = s;
            for (int d = 1; d < s; d++)
            {
                for (int i = 1; i < s; i++)
                {
                    if (listClass[i] == listClass[i - 1]) { listClass.RemoveAt(i); s--; }

                }
            }
            
            int allage = 0; int sred = 0;
            for (int d = 0; d < s; d++)
            {
                for(int i = 1; i < s1; i++)
                { 
                    if (listClass[d] == ts[i].GetType().Name) { allage = allage + ts[i].Age; sred++; }
                }
                Console.WriteLine($"Средний возраст {listClass[d]} равен {allage / sred}"); allage = 0; sred = 0;
            }
        }
        static void OldMeat(List<Animals> ts)
        {
            
            int s = 0;
            foreach (var i in ts)
            {
                s++;
            }
            Console.WriteLine(s);
            ts.Add(new Animals());
            for (int d = 0; d < s; d++)
            {
                for (int i = 1; i <= s; i++)
                {
                    if (ts[i - 1].Age < ts[i].Age) { ts[s] = ts[i - 1]; ts[i - 1] = ts[i]; ts[i] = ts[s]; }
                }

            }
            for (int d = 0; d < 3; d++) { ts[d].SayHello(); }
        }

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
                new Elephant("Bender", new DateTime(2013, 12, 18), Animals.Sex.male),
                new Animals("Doorry", new DateTime(2018, 7, 21), Animals.Sex.Female),
            };

            listOfAnimals.SayHelloList();

            // This version for expansion 
            Console.WriteLine("Зебры:");
            ListOfZebra(listOfAnimals);

            Console.WriteLine("Возраст больше 2:");
            ListOfOlder2(listOfAnimals);

            Console.WriteLine("Уникальные именна животных:");
            UniqueNames(listOfAnimals);
            
            Console.WriteLine("Дни рождения слонов:");
            BirthdayElephant(listOfAnimals);
           
            AgeClass(listOfAnimals);
            
            Console.WriteLine("Три самых старых животных");
            OldMeat(listOfAnimals);
        }

      

    }
}