using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleToDo
{
    public class Program   
    {
        static void Main(string[] args)
        {
            #region Dodawanie
            ArrayList arrayList = new ArrayList();
            string zadanie = Console.ReadLine();
            string proba = string.Empty;

            if (zadanie != proba)
            {
                arrayList.Add(zadanie);
            }
            #endregion

            #region Tworzenie i dodawanie do pliku

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = Path.Combine(path, "ToDo.txt");


            if (File.Exists(file))
            {
                Console.Clear();

                int lineCount = File.ReadLines(@"C:\Users\ACER\Desktop\ToDo.txt").Count();
                foreach (object o in arrayList)
                {
                    File.AppendAllText(file, lineCount - 1 + ". " + o + Environment.NewLine);
                }

                Console.WriteLine(File.ReadAllText(file));



                Console.WriteLine("Ilość rzeczy do zrobienia {0}", lineCount - 1);
            }
            else
            {
                File.WriteAllText(file, "Lista To Do \n" + Environment.NewLine);
            } 
            #endregion

            #region wybieranie zadania
            Console.WriteLine("Podaj nummer porządkowy zadania do wykonania aby edytować: ");
            string wybor = Console.ReadLine();
            wybor += ".";
            //Wyszukuje danej frazy
            foreach (string line in File.ReadLines(@"C:\Users\ACER\Desktop\ToDo.txt"))
            {
                if (line.Contains(wybor))
                {
                    Console.WriteLine(line);
                }
            }
            #endregion

            #region Nie/Wykonane
            Console.WriteLine("Czy chcesz zmienić status któregoś zadania na wykonany/niewykonany?  (tak/nie)");
            string decyzja = Console.ReadLine();
            if (decyzja == "tak")
            {
                Console.WriteLine("Chcesz zmienić status na wykonalny?");
                decyzja = Console.ReadLine();
                if (decyzja == "tak")
                {
                    Console.WriteLine("Podaj nummer porządkowy zadania do wykonania aby edytować: ");
                    wybor = Console.ReadLine();
                    wybor += ".";

                    foreach (string line in File.ReadLines(@"C:\Users\ACER\Desktop\ToDo.txt"))
                    {
                        if (line.Contains(wybor))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(line);
                        }
                    }
                }

                if (decyzja == "nie")
                {
                    Console.WriteLine("Podaj nummer porządkowy zadania do wykonania aby edytować: ");
                    wybor = Console.ReadLine();
                    wybor += ".";

                    foreach (string line in File.ReadLines(@"C:\Users\ACER\Desktop\ToDo.txt"))
                    {
                        if (line.Contains(wybor))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(line);

                        }
                    }

                }
            }
            else
            {

            } 
            #endregion

            



            Console.WriteLine(file);


            Console.ReadKey();
        }        
    }
}
