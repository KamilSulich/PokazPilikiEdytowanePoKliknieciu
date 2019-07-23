using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokazPilikiEdytowanePoKliknieciu
{
    class Program
    {

        static void foldery(string path, DateTime teraz)
        {
            try
            {
                string[] pliki = Directory.GetFiles(path);
                foreach (string plik in pliki)
                {
                    if (File.GetLastWriteTime(plik) > teraz)
                        Console.WriteLine(plik + " zostal zmodyfikowany w trakcie pracy programu, o godzinie " + File.GetCreationTime(plik).ToString());
                }
                string[] foldery = Directory.GetDirectories(path);
                foreach (string folder in foldery)
                {
                    Program.foldery(folder, teraz);
                }

            }
            catch
            {

            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Wpisz cokolwiek i zatwierdz enterem napisany tekst. Od tego momentu beda rejestrowane pliki ktore sa modyfikowane. ");
            Console.ReadLine();
            DateTime teraz = System.DateTime.Now;
            Console.WriteLine("Pokazane zostana pliki utworzone po " + teraz.ToString());
            Console.WriteLine("Wpisz cokolwiek i wcisnij enter by pokazac liste plikow ktore zostaly zmodyfikowane od czasu poprzedniego komunikatu. ");
            Console.ReadLine();
            string path = @"c:/";
            Program.foldery(path, teraz);
            path = @"d:/";
            Program.foldery(path, teraz);

            Console.WriteLine("Koniec działania programu. ");
            Console.ReadLine();
        }
    }
}
