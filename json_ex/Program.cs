using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static System.Console;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;


namespace PV_ssh_221
{
    public class Person
    {
        public string Name { get; set; }


        public int Age { get; set; }
        [NonSerialized]
        public int ID;
        [NonSerialized]
        const string Group = "PV221";
        public Person() { } //
        public Person(int n)
        {
            ID = n;
        }
        public override string ToString()
        {
            return $"{Name}  {Age}  {ID}  {Group} ";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {


            /* List<Person> persons = new List<Person>()
             {
                 new Person(10) { Name = "Ella1", Age = 18 },
                 new Person(20) { Name = "Ella2", Age = 180},
                 new Person(30) { Name = "Ella3", Age = 1800 }
             };
             XmlSerializer xs = new XmlSerializer(typeof(List<Person>)); //1
             foreach (Person item in persons)
             {
                 WriteLine(item);
             }


             try
             {
                 using (Stream fs = File.Create("test.xml"))
                 {
                     xs.Serialize(fs, persons);
                 }
                 WriteLine("Serialize OK ");


             }
             catch (Exception ex)
             {


                 WriteLine(ex);
             }


             WriteLine("**********************************");
             List<Person> p_new = null;
             try
             {
                 using (Stream fs = File.OpenRead("test.xml"))
                 {
                     p_new = (List<Person>)xs.Deserialize(fs);
                 }
                 foreach (Person item in p_new)
                 {
                     WriteLine(item);
                 }


                 WriteLine("Serialize OK ");


             }
             catch (Exception ex)
             {
                 WriteLine(ex);
             }*/



            // JSON
            // можно не писать атрибут сериализации 
            // должен быть конструктор без параметров или конструктор со всеми параметрами (есть все значения)

            // 1.1 - сериализация (в конcоли)
            /* Person p1 = new Person { ID = 10, Name = "Ella1", Age = 18 };

             string p1_json = JsonSerializer.Serialize(p1);

             WriteLine(p1_json);

             // 1.2 - десериализация

             Person pnew = JsonSerializer.Deserialize<Person>(p1_json);
             WriteLine(pnew.Name);*/

            // 2.1 (в файле)
            Person p1 = new Person { ID = 10, Name = "Ella1", Age = 18 };

            string p1_json = JsonSerializer.Serialize(p1);

            string fileName = "Person.json";
            File.WriteAllText(fileName, p1_json);

            // 2.2
            string p1_new_str = File.ReadAllText(fileName);
            Person p1_new = JsonSerializer.Deserialize<Person>(p1_new_str);            
            WriteLine(p1_new);

        }
    }
}