
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using BasicConnection.Context;
using BasicConnection.Controller;
using BasicConnection.Model;
using BasicConnection.View;

namespace BasicConnection;

public class Program
{
    private static UniversityController universityController = new();
    private static EducationController educationController = new();
    private static EmployeeController employeeController = new();
    private static ProfilingController profilingController = new();
    private static MenuView menuView = new MenuView();
    public static void Main()
    {
        int choice;
        do
        {
            menuView.Menu();
            choice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("-----------------------------------------");

            switch (choice)
            {
                case 1:
                    menuView.Insert();
                    int tabel = Convert.ToInt32(Console.ReadLine());
                    InsertTable(tabel);
                    break;

                case 2:
                    menuView.Select();
                    int tabel1 = Convert.ToInt32(Console.ReadLine());
                    SelectTable(tabel1);
                    break;

                case 3:
                    menuView.Update();
                    int tabel2 = Convert.ToInt32(Console.ReadLine());
                    UpdateTable(tabel2);
                    break;

                case 4:
                    menuView.Delete();
                    int tabel3 = Convert.ToInt32(Console.ReadLine());
                    DeleteTable(tabel3);
                    break;

                case 5:
                    LinqGpa();
                    break;


                default:
                    Console.WriteLine("Salah Input Number");
                    break;
            }
        } while (choice != 6);
    }

    public static void InsertTable(int tabel)
    {
        switch (tabel)
        {
            case 1:
                Console.WriteLine("-----------------------------------------");
                var university = new University();
                Console.Write("Masukkan Nama Universitas : ");
                string nama = Console.ReadLine();
                university.Name = nama;

                universityController.Insert(university);
                break;
            case 2:
                Console.WriteLine("-----------------------------------------");
                var education = new Education();
                Console.Write("Masukkan Major : ");
                education.Major = Console.ReadLine();

                Console.Write("Masukkan Degree : ");
                education.Degree = Console.ReadLine();

                Console.Write("Masukkan GPA : ");
                education.GPA = Console.ReadLine();

                Console.Write("University ID : ");
                education.UniversityId = Convert.ToInt32(Console.ReadLine());

                educationController.Insert(education);
                break;

            case 3:
                InsertAll();
                break;

            default:
                Console.WriteLine("Salah Input Number");
                break;
        }
    }

    public static void SelectTable(int tabel1)
    {
        switch (tabel1)
        {
            case 1:
                universityController.GetAll();
                break;

            case 2:
                educationController.GetAll();
                break;
            case 3:
                employeeController.GetAll();
                break;
            case 4:
                profilingController.GetAll();
                break;

                case 5:
                LinqAllData();
                break;

            default:
                Console.WriteLine("Salah Input Number");
                break;
        }
    }

    public static void UpdateTable(int tabel2)
    {
        switch (tabel2)
        {
            case 1:
                Console.WriteLine("-----------------------------------------");
                var university = new University();
                Console.Write("\nMasukkan ID Universitas : ");
                int id = Convert.ToInt32(Console.ReadLine());
                university.Id = id;

                Console.Write("Masukkan Nama Universitas : ");
                var name = Console.ReadLine();
                university.Name = name;

                universityController.Update(university);
                break;

            case 2:
                Console.WriteLine("-----------------------------------------");
                var education = new Education();
                Console.Write("\nMasukkan ID  : ");
                education.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Major : ");
                education.Major = Console.ReadLine();
                Console.Write("Degree : ");
                education.Degree = Console.ReadLine();
                Console.Write("GPA =  ");
                education.GPA = Console.ReadLine();
                Console.Write("Universty Id : ");
                education.UniversityId = Convert.ToInt32(Console.ReadLine());

                educationController.Update(education);
                break;

            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }

    public static void DeleteTable(int tabel3)
    {
        switch (tabel3)
        {
            case 1:
                Console.WriteLine("-----------------------------------------");
                var university = new University();
                Console.Write("Masukkan ID : ");
                int id = Convert.ToInt32(Console.ReadLine());
                university.Id = id;

                universityController.Delete(university);
                break;

            case 2:
                Console.WriteLine("-----------------------------------------");
                var education = new Education();
                Console.Write("Masukkan ID : ");
                education.Id = Convert.ToInt32(Console.ReadLine());

                educationController.Delete(education);
                break;

            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    }

    public static void InsertAll()
    {
        var employee = new Employee();
        var profiling = new Profiling();
        var education = new Education();
        var university = new University();

        Console.Write("NIK : ");
        var niks = Console.ReadLine();
        employee.Nik = niks;

        Console.Write("First Name : ");
        employee.FirstName = Console.ReadLine();

        Console.Write("Lame Name : ");
        employee.LastName = Console.ReadLine();

        Console.Write("Birthdate : ");
        employee.Birthdate = DateTime.Parse(Console.ReadLine());

        Console.Write("Gender : ");
        employee.Gender = Console.ReadLine();

        Console.Write("Hiring Date : ");
        employee.HiringDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Email : ");
        employee.Email = Console.ReadLine();

        Console.Write("Phone Number : ");
        employee.PhoneNumber = Console.ReadLine();

        Console.Write("Department ID : ");
        employee.DepartmentId = Console.ReadLine();

        //EDUCATION
        Console.Write("Major : ");
        education.Major = Console.ReadLine();

        Console.Write("Degree : ");
        education.Degree = Console.ReadLine();

        Console.Write("GPA : ");
        education.GPA = Console.ReadLine();

        Console.Write("University Name : ");
        university.Name = Console.ReadLine();

        employeeController.Insert(employee);
        universityController.Insert(university);

        education.UniversityId = university.GetUnivId();
        education.InsertEducation(education);
        educationController.Insert(education);

        profiling.EmployeeId = employee.GetEmpId(niks);
        profiling.EmployeeId = employee.GetEmpId(niks);

        profiling.EducationId = education.GetEduId();
        profilingController.Insert(profiling);
    }

    public static void LinqGpa()
    {
        educationController.LinqGPA();
    }

    public static void LinqAllData()
    {
        var education = new Education();
        var employee = new Employee();
        var profiling = new Profiling();
        var university = new University();


        var educationGet = education.GetEducation();
        var employeeGet = employee.GetEmployee();
        var profilingGet = profiling.GetProfiling();
        var universityGet = university.GetUniversities();

        var getAll = from emp in employeeGet
                     join pro in profilingGet on emp.Id equals pro.EmployeeId
                     join edu in educationGet on pro.EducationId equals edu.Id
                     join uni in universityGet on edu.UniversityId equals uni.Id
                     select new
                     {
                         NIK = emp.Nik,
                         Fullname = emp.FirstName + " " + emp.LastName,
                         emp.Birthdate,
                         emp.Gender,
                         emp.HiringDate,
                         emp.Email,
                         emp.PhoneNumber,
                         edu.Major,
                         edu.Degree,
                         edu.GPA,
                         Univesity = uni.Name
                     };

        foreach (var get in getAll)
        {
            Console.WriteLine($"NIK         : {get.NIK}");
            Console.WriteLine($"Fullname    : {get.Fullname}");
            Console.WriteLine($"Birthdate   : {get.Birthdate}");
            Console.WriteLine($"Gender      : {get.Gender}");
            Console.WriteLine($"HiringDate  : {get.HiringDate}");
            Console.WriteLine($"Email       : {get.Email}");
            Console.WriteLine($"PhoneNumber : {get.PhoneNumber}");
            Console.WriteLine($"Major       : {get.Major}");
            Console.WriteLine($"Degree      : {get.Degree}");
            Console.WriteLine($"GPA         : {get.GPA}");
            Console.WriteLine($"Univesity   : {get.Univesity}");
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}


