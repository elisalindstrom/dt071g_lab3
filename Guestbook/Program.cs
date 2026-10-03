/*
Laboration 3 kurs DT071G

Program för gästbok där det går att lägga till, ta bort och se sparade gästboksinlägg.
Inläggen sparas i en JSON-fil som skapas första gången ett inlägg skapas i programmet.

Av Elisa Lindström 2026
*/

using System;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skapar objekt för hanteringen av lagring 
            IGuestbookStorage storage = new JsonGuestbookStorage("guestbook.json");

            // Skapar gästboken och skickar med lagrade objekt
            Guestbook guestbook = new Guestbook(storage);

            // Variabel för användarens menyval
            string? choice;

            // Meny
            do
            {
                Console.Clear();

                Console.WriteLine("ELISAS GÄSTBOK\n\n");
                Console.WriteLine("1. Skriv ett inlägg\n");
                Console.WriteLine("2. Ta bort ett inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                int i = 0;

                // Skriver ut alla sparade inlägg med index
                foreach (GuestbookEntry guestbookEntry in guestbook.GetEntries())
                {
                    Console.WriteLine("[" + i++ + "] " + guestbookEntry.Author + ": " + guestbookEntry.Message);
                }

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Namn: ");
                        string? name = Console.ReadLine();
                        Console.Write("Meddelande: ");
                        string? message = Console.ReadLine();

                        // Kontrollerar att namn och meddelande angetts
                        if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(message))
                        {
                            guestbook.AddEntry(name, message);
                        }
                        else
                        {
                            Console.WriteLine("Du måste fylla i namn och meddelande!");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        Console.Write("Ange index du vill ta bort: ");
                        string? index = Console.ReadLine();

                        // Kontrollerar att index inte är tomt
                        if (!String.IsNullOrEmpty(index))
                            try
                            {   // Konverterar string till en int och tar bort valt index
                                guestbook.DelEntry(Convert.ToInt32(index));
                            }
                            // Om angivet index är felaktigt/inte finns
                            catch (Exception)
                            {
                                Console.WriteLine("Felaktigt index");
                                Console.ReadKey();
                            }
                        break;

                    case "X":
                        break;
                }
            }
            // Loopen körs så länge inte användaren avslutar programmet
            while (choice != "X");
        }
    }
}