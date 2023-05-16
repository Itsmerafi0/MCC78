using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnection.View;

public class MenuView
{
    public void Insert()
    {
        Console.WriteLine("----------------");
        Console.WriteLine("| 1. University |");
        Console.WriteLine("| 2. Education  |");
        Console.WriteLine("| 3. Insert All |");
        Console.WriteLine("----------------");
        Console.Write("Pilih tabel yang akan di insert data : ");
    }

    public void Select()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("| 1. Select University |");
        Console.WriteLine("| 2. Select Education  |");
        Console.WriteLine("| 3. Select Employee   |");
        Console.WriteLine("| 4. Select Profiling  |");
        Console.WriteLine("| 5. Select All        |");
        Console.WriteLine("-----------------------");
        Console.Write("Pilih tabel yang akan di tampilkan : ");
    }

    public void Update()
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("| 1. University  |");
        Console.WriteLine("| 2. Education   |");
        Console.WriteLine("-----------------");
        Console.Write("Pilih tabel yang akan di Update : ");
    }

    public void Delete()
    {
        Console.WriteLine("-----------------");
        Console.WriteLine("1. University   |");
        Console.WriteLine("2. Education    |");
        Console.WriteLine("-----------------");
        Console.Write("Pilih tabel yang akan di hapus : ");
    }

    public void Menu()
    {
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("|                  MENU                 |");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("| 1.   Insert                           |");
        Console.WriteLine("| 2.   Select                           |");
        Console.WriteLine("| 3.   Update                           |");
        Console.WriteLine("| 4.   Delete                           |");
        Console.WriteLine("| 5.   Get GPA = 4                      |");
        Console.WriteLine("| 6.   Exit                             |");
        Console.WriteLine("-----------------------------------------");
        Console.Write("Pilih Menu : ");
    }
}