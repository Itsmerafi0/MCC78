using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace BasicConnection
{
    public class Program
    {

        public static void Menu1()
        {

        }
        public static void Menu()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("|     MENU               |");
            Console.WriteLine("| 1. Insert              |");
            Console.WriteLine("| 2. Select              |");
            Console.WriteLine("| 3. Update              |");
            Console.WriteLine("| 4. Delete              |");
            Console.WriteLine("| 5. Insert All Employee |");
            Console.WriteLine("| 6. Exit                |");
            Console.WriteLine("========================= ");
            Console.WriteLine("\nPilih menu : ");
        }

            public static void Main()
        {

            int choice;
            do
            {
                Menu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nPilih tabel yang akan di insert data");
                        Console.WriteLine("1. University");
                        Console.WriteLine("2. Education");
                        int tabel = Convert.ToInt32(Console.ReadLine());
                        if (tabel == 1)
                        {
                            var university = new universities();
                            Console.Write("Masukkan nama : ");
                            string nama = Console.ReadLine();
                            university.Name = nama;

                            var result = universities.InsertUniversity(university);
                            if (result > 0)
                            {
                                Console.WriteLine("Insert success.");
                            }
                            else
                            {
                                Console.WriteLine("Insert failed.");
                            }
                        }
                        else if (tabel == 2)
                        {
                            var education = new educations();
                            Console.Write("Masukkan Major : ");
                            var major = Console.ReadLine();
                            education.major = major;

                            Console.Write("Masukkan Degree : ");
                            var degree = Console.ReadLine();
                            education.degree = degree;

                            Console.Write("Masukkan GPA : ");
                            var gpa = Console.ReadLine();
                            education.gpa = gpa;


                            Console.Write("University ID : ");
                            var university_id = Convert.ToInt32(Console.ReadLine());
                            education.university_id = university_id;

                            var result = educations.InsertEducation(education);
                            if (result > 0)
                            {
                                Console.WriteLine("Insert success.");
                            }
                            else
                            {
                                Console.WriteLine("Insert failed.");
                            }
                        }
                        else
                        {

                        }
                        break;

                    case 2:
                        Console.WriteLine(" \n Pilih tabel yang akan di insert data");
                        Console.WriteLine("1. University");
                        Console.WriteLine("2. Education");
                        int tabel2 = Convert.ToInt32(Console.ReadLine());
                        if (tabel2 == 1)
                        {
                            Console.WriteLine("SELECT ALL");
                            var results = universities.GetUniversities();
                            foreach (var result in results)
                            {
                                Console.WriteLine("Id: " + result.Id);
                                Console.WriteLine("Name: " + result.Name);
                            }
                        }
                        if (tabel2 == 2)
                        {
                            Console.WriteLine("SELECT ALL");
                            var results = educations.GetEducation();
                            foreach (var result in results)
                            {
                                Console.WriteLine("Id: " + result.id);
                                Console.WriteLine("Major: " + result.major);
                                Console.WriteLine("Degree: " + result.degree);
                                Console.WriteLine("GPA: " + result.gpa);
                                Console.WriteLine("Universty Id : " + result.university_id);
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("Pilih tabel yang akan di Update ");
                        Console.WriteLine("1. University");
                        Console.WriteLine("2. Education");
                        int tabel3 = Convert.ToInt32(Console.ReadLine());
                        if (tabel3 == 1)
                        {
                            var university = new universities();

                            Console.WriteLine("Masukkan ID : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            university.Id = id;


                            Console.Write("Masukkan Nama : ");
                            var name3 = Console.ReadLine();
                            university.Name = name3;

                            var result = universities.UpdateUniversity(university);
                            if (result > 0)
                            {
                                Console.WriteLine("Update success");
                            }
                            else
                            {
                                Console.WriteLine("Update Failed");
                            }
                        }

                        if (tabel3 == 2)
                        {

                            var education = new educations();
                            Console.WriteLine("Masukkan ID : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Major: ");
                            string major = Console.ReadLine();
                            Console.WriteLine("Degree: ");
                            string degree = Console.ReadLine();
                            Console.WriteLine("GPA: ");
                            string gpa = Console.ReadLine();
                            Console.WriteLine("Universty Id : ");
                            int univ_id = Convert.ToInt32(Console.ReadLine());

                            education.id = id;
                            education.major = major;
                            education.degree = degree;
                            education.gpa = gpa;
                            education.university_id = univ_id;


                            var resultss = educations.UpdateEducation(education);
                            if (resultss > 0)
                            {
                                Console.WriteLine("Update success");
                            }
                            else
                            {
                                Console.WriteLine("Update Failed");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Pilih tabel yang akan di Delete");
                        Console.WriteLine("1. University");
                        Console.WriteLine("2. Education");
                        int tabel4 = Convert.ToInt32(Console.ReadLine());
                        if (tabel4 == 1)
                        {
                            var university = new universities();

                            Console.WriteLine("Masukkan ID : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            university.Id = id;

                            var result = universities.DeleteUniversity(university);
                            if (result > 0)
                            {
                                Console.WriteLine("Delete success");
                            }
                            else
                            {
                                Console.WriteLine("Delete Failed");
                            }
                        }

                        else if (tabel4 == 2)
                        {
                            var education = new educations();

                            Console.WriteLine("Masukkan ID : ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            education.university_id = id;

                            var result = educations.DeleteEducation(education);
                            if (result > 0)
                            {
                                Console.WriteLine("Delete success");
                            }
                            else
                            {
                                Console.WriteLine("Delete Failed");
                            }

                        }
                        break;

                    case 5:

                        Employees.PrintOutEmployee();
                        
                        break;

                }
            } while (choice != 6);
        }
        

        }
    }




