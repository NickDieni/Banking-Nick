using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Banking_Nick
{
    internal class Program
    {

        static void Main()
        {
            string sti = @"C:\Datamappe", datafil = @"C:\Datamappe\BankValuta.txt";
            string[] lines = File.ReadAllLines(datafil);
            Kunder k1 = new Kunder();
            k1.Name = "Nick";
            k1.Email = "Nick464c@tec.elev.dk";
            k1.Password = "password";

            Konto ko1 = new Konto();
            Konto ko2 = new Konto();



            List<string> kon1 = new List<string>();





            Workers w1 = new Workers();
            w1.Name = "Boss";
            w1.Password = "bosspas";

            Console.WriteLine("Er du en kunde eller medarbejder?");
            Console.WriteLine("[D]Kunde - - - - - [S]Medarbejder");
            string tast = Convert.ToString(Console.ReadKey().KeyChar).ToLower();
            if (tast == "d")
            {
                Console.Clear();
                Console.WriteLine($"- - - - - - - - - - - Velkommen {k1.Name} - - - - - - - - - - - - ");
                Console.WriteLine("");
                Console.WriteLine("Hvad vil du gøre?");
                Console.WriteLine("[D]Konto og valuta - - - - [S]Kontooplysninger - - - - [A]Overfør");
                string tast1 = Convert.ToString(Console.ReadKey().KeyChar).ToLower();
                if (tast1 == "d")
                {
                    int val1 = ko1.Valuta;
                    int val2 = ko2.Valuta;
                    (int newVal1, int newVal2) = Word(val1, val2);
                    ko1.Valuta = newVal1;
                    ko2.Valuta = newVal2;
                    kon1.Add($"Konto 1 Valuta {ko1.Valuta}");
                    kon1.Add($"Konto 2 Valuta {ko2.Valuta}");
                    Console.Clear();
                    foreach (var konto in kon1)
                    {
                        Console.WriteLine(konto);
                    }
                }
                else if (tast1 == "s")
                {
                    Console.Clear();
                    Console.WriteLine(k1.Name);
                    Console.WriteLine(k1.Email);
                    Console.WriteLine(k1.Password);
                }
                else if (tast1 == "a")
                {
                    Console.Clear();
                    Console.WriteLine("Skriv antal du vil overfør");
                    int nyttal;
                    nyttal = int.Parse(Console.ReadLine());
                    ko1.Valuta = ko1.Valuta - nyttal;
                    ko2.Valuta = ko2.Valuta + nyttal;
                    (int val1, int val2) = Word(ko1.Valuta, ko2.Valuta);
                    ko1.Valuta = val1;
                    ko2.Valuta = val2;
                    Console.Clear();

                }

            }
            else if (tast == "s")
            {
                Console.Clear();
                Console.WriteLine($"Velkommen {w1.Name}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Fejl Prøv igen tryk en tast for at starte om");
                Console.ReadKey();
                Console.Clear();
                Main();
                Main();
            }

        }
        public static (int, int) Word(int val1, int val2)
        {
            string sti = @"C:\Datamappe", datafil = @"C:\Datamappe\BankValuta.txt";

            if (!File.Exists(datafil))
            {
                Directory.CreateDirectory(sti);
                File.WriteAllText(datafil, $"{val1}\n{val2}");
            }
            else if (File.Exists(datafil))
            {
                File.Delete(datafil);
                Directory.CreateDirectory(sti);
                File.AppendAllText(datafil, $"{val1}\n{val2}");
            }

            string[] lines = File.ReadAllLines(datafil);
            val1 = int.Parse(lines[0]);
            val2 = int.Parse(lines[1]);

            return (val1, val2);
        }

    }
}