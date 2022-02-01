using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using Labb_3_DatabasUtveckling.Models;

namespace DatabasUtveckling_Labb_3
{


    public class Program
    {
        static void Main(string[] args)
        {
            using Labb2SkolanContext Context = new Labb2SkolanContext();
            int menu = 0;
            int menu2 = 0;
            int menu3 = 0;
            int menu4 = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Välj ett alternativ i listan!");
                    Console.WriteLine("1. Lista Personal");
                    Console.WriteLine("2. Lista Elever");
                    Console.WriteLine("3. Klass Listor");
                    Console.WriteLine("4. Betyg");
                    Console.WriteLine("5. Avsluta Program");
                    menu = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ogiltligt Val!");
                }

                switch (menu)
                {

                    case 1:
                        do
                        {

                            try
                            {
                                Console.Clear();

                                Console.WriteLine("Vad vill du lista för personal?");
                                Console.WriteLine("1. Rektorer");
                                Console.WriteLine("2. Administratörer");
                                Console.WriteLine("3. Lärare");
                                Console.WriteLine("4. Vaktmästare");
                                Console.WriteLine("5. Lägg till personal");
                                Console.WriteLine("6. Back");
                                menu2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ogiltligt Val!");
                            }

                            switch (menu2)
                            {
                                case 1:
                                    Console.Clear();
                                    var Pers = from Personnel in Context.Personnels
                                               where Personnel.FkroleId == 1
                                               orderby Personnel.PFirstName
                                               select Personnel;
                                    Console.WriteLine("---Rektorer---");
                                    Console.WriteLine();
                                    foreach (var item in Pers)
                                    {
                                        Console.WriteLine($"Id: {item.Id}");
                                        Console.WriteLine($"Name: {item.PFirstName}" + " " + $"{item.PLastName}");
                                        Console.WriteLine("---------------------");
                                    }
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    var admin = from Personnel in Context.Personnels
                                                where Personnel.FkroleId == 2
                                                orderby Personnel.PFirstName
                                                select Personnel;
                                    Console.WriteLine("---Administration---");
                                    Console.WriteLine();
                                    foreach (var item in admin)
                                    {
                                        Console.WriteLine($"Id: {item.Id}");
                                        Console.WriteLine($"Name: {item.PFirstName}" + " " + $"{item.PLastName}");
                                        Console.WriteLine("---------------------");
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    var teacher = from Personnel in Context.Personnels
                                                  where Personnel.FkroleId == 3
                                                  orderby Personnel.Id
                                                  select Personnel;
                                    Console.WriteLine("---Lärare---");
                                    Console.WriteLine();
                                    foreach (var item in teacher)
                                    {
                                        Console.WriteLine($"Id: {item.Id}");
                                        Console.WriteLine($"Name: {item.PFirstName}" + " " + $"{item.PLastName}");
                                        Console.WriteLine("---------------------");
                                    }
                                    Console.ReadKey();

                                    break;
                                case 4:
                                    Console.Clear();
                                    var Vaktm = from Personnel in Context.Personnels
                                                where Personnel.FkroleId == 4
                                                orderby Personnel.Id
                                                select Personnel;
                                    Console.WriteLine("---Vaktmästare---");
                                    Console.WriteLine();
                                    foreach (var item in Vaktm)
                                    {
                                        Console.WriteLine($"Id: {item.Id}");
                                        Console.WriteLine($"Name: {item.PFirstName}" + " " + $"{item.PLastName}");
                                        Console.WriteLine("---------------------");
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    AddPersonnel();
                                    break;
                                case 6:
                                    Main(null);
                                    break;
                                default:

                                    break;
                            }
                        } while (menu2 != 0);
                        break;

                    case 2:
                        do
                        {
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("---Lista Elever---");
                                Console.WriteLine("1. Sortera på förnamn");
                                Console.WriteLine("2. Sortera på efternamn");
                                Console.WriteLine("3. Back");
                                menu3 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ogiltligt Val!");
                            }
                            switch (menu3)
                            {
                                case 1:
                                    Console.Clear();
                                    var stud = from Student in Context.Students
                                               orderby Student.StudentFname
                                               select Student;
                                    foreach (var item in stud)
                                    {

                                        Console.WriteLine("Id: {0}, Name: {1} {2}", item.Id, item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    continue;
                                case 2:
                                    Console.Clear();
                                    var stud1 = from Student in Context.Students
                                                orderby Student.StudentLname
                                                select Student;
                                    foreach (var item in stud1)
                                    {
                                        Console.WriteLine("Id: {0}, Name: {1} {2}", item.Id, item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    continue;
                                case 3:
                                    Main(null);
                                    break;
                                default:
                                    break;
                            }
                        } while (menu3 != 0);
                        break;
                    case 3:
                        do
                        {
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("---Klasser---");
                                Console.WriteLine("1. English");
                                Console.WriteLine("2. Programming");
                                Console.WriteLine("3. Physics");
                                Console.WriteLine("4. Math");
                                Console.WriteLine("5. Biology");
                                Console.WriteLine("6. Back");
                                menu4 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ogiltligt Val!");
                            }
                            switch (menu4)
                            {
                                case 1:
                                    Console.Clear();
                                    var stu1 = from Student in Context.Students
                                               where Student.FkclassId == 1
                                               select Student;
                                    Console.WriteLine("---English Class---");
                                    Console.WriteLine();
                                    foreach (var item in stu1)
                                    {
                                        Console.WriteLine("ID: {0}", item.Id);
                                        Console.WriteLine("Name: {0} {1}", item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    continue;
                                case 2:
                                    Console.Clear();
                                    var stu2 = from Student in Context.Students
                                               where Student.FkclassId == 2
                                               select Student;
                                    Console.WriteLine("---Programming Class---");
                                    Console.WriteLine();
                                    foreach (var item in stu2)
                                    {
                                        Console.WriteLine("ID: {0}", item.Id);
                                        Console.WriteLine("Name: {0} {1}", item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    var stu3 = from Student in Context.Students
                                               where Student.FkclassId == 3
                                               select Student;
                                    Console.WriteLine("---Physics Class---");
                                    Console.WriteLine();
                                    foreach (var item in stu3)
                                    {
                                        Console.WriteLine("ID: {0}", item.Id);
                                        Console.WriteLine("Name: {0} {1}", item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    var stu4 = from Student in Context.Students
                                               where Student.FkclassId == 4
                                               select Student;
                                    Console.WriteLine("---Math Class---");
                                    Console.WriteLine();
                                    foreach (var item in stu4)
                                    {
                                        Console.WriteLine("ID: {0}", item.Id);
                                        Console.WriteLine("Name: {0} {1}", item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 5:
                                    Console.Clear();
                                    var stu5 = from Student in Context.Students
                                               where Student.FkclassId == 5
                                               select Student;
                                    Console.WriteLine("---Biology Class---");
                                    Console.WriteLine();
                                    foreach (var item in stu5)
                                    {
                                        Console.WriteLine("ID: {0}", item.Id);
                                        Console.WriteLine("Name: {0} {1}", item.StudentFname, item.StudentLname);
                                        Console.WriteLine();
                                    }
                                    Console.ReadKey();
                                    break;
                                case 6:
                                    Main(null);
                                    break;
                                default:
                                    break;
                            }
                        } while (menu4 != 0);
                        break;
                    case 4:

                        continue;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
                break;

            } while (menu != 0);

        }
        public static void AddPersonnel()
        {
            using Labb2SkolanContext Context = new Labb2SkolanContext();
            int menu = 0;
            Personnel newPersonnel = new Personnel();

            Console.Clear();
            Console.Write("Ange förnamn: ");
            newPersonnel.PFirstName = Console.ReadLine();

            Console.Clear();
            Console.Write("Ange efternamn: ");
            newPersonnel.PLastName = Console.ReadLine();
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Vilken roll ska denna ha?");
                    Console.WriteLine("1. Rektor");
                    Console.WriteLine("2. Administratör");
                    Console.WriteLine("3. Lärare");
                    Console.WriteLine("4. Vaktmästare");
                    menu = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                }
                switch (menu)
                {
                    case 1:
                        newPersonnel.FkroleId = 1;
                        Context.Personnels.Add(newPersonnel);
                        Context.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("En Rektor har lagts till");
                        Console.ReadKey();
                        Main(null);
                        continue;
                    case 2:
                        newPersonnel.FkroleId = 2;
                        Context.Personnels.Add(newPersonnel);
                        Context.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("En Administratör har lagts till");
                        Console.ReadKey();
                        Main(null);
                        continue;
                    case 3:
                        newPersonnel.FkroleId = 3;
                        Context.Personnels.Add(newPersonnel);
                        Context.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("En Lärare har lagts till");
                        Console.ReadKey();
                        Main(null);
                        continue;
                    case 4:
                        newPersonnel.FkroleId = 4;
                        Context.Personnels.Add(newPersonnel);
                        Context.SaveChanges();
                        Console.Clear();
                        Console.WriteLine("En Vaktmästare har lagts till");
                        Console.ReadKey();
                        Main(null);
                        continue;
                    default:
                        break;
                }

            } while (menu != 0);


        }

    }

}