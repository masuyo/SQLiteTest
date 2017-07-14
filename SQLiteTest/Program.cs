using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace SQLiteTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseLayer dl = new DatabaseLayer();
            int menupontSzama;

            Console.WriteLine("1. Adatbazisfajl letrehozasa admin userrel\n");
            Console.WriteLine("2. Tabla letrehozasa\n");
            Console.WriteLine("3. Adatbevitel\n");
            Console.WriteLine("4. Lekerdezes\n");
            Console.WriteLine("9. Exit");
            Console.WriteLine("***************************************");

            do
            {
                menupontSzama = int.Parse(Console.ReadLine());
                switch (menupontSzama)
                {
                    case 1:
                        // kódból megadott pw
                        dl.CreateDatabaseWPassword();
                        break;
                    case 2:
                        // kódból megadott tábla
                        dl.CreateTable();
                        break;
                    case 3:
                        Console.WriteLine("Adat:");
                        string adat = Console.ReadLine();
                        dl.InsertData(adat);
                        break;
                    case 4:
                        // select * table
                        dl.QueryDatabase();
                        break;
                    default:
                        break;
                }
            } while (menupontSzama != 9);
        }
    }
}
