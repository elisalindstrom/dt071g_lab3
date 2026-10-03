// Hanterar hur inlägg sparas och laddas

using System.Text.Json;

namespace guestbook
{
    public class JsonGuestbookStorage : IGuestbookStorage
    {
        private readonly string jsonFile;

        // Konstruktor som anger vilken fil som ska användas vid lagring
        public JsonGuestbookStorage(string jsonFile)
        {
            this.jsonFile = jsonFile;
        }

        // Laddar sparade inlägg från JSON-filen
        public List<GuestbookEntry> Load()
        {
            // Kontrollerar om filen finns, annars returneras tom lista
            if (!File.Exists(jsonFile))
                return new List<GuestbookEntry>();

            // Läser filen
            string json = File.ReadAllText(jsonFile);

            // Konverterar JSON till en lista med inlägg, om null returneras tom lista
            return JsonSerializer.Deserialize<List<GuestbookEntry>>(json) ?? new List<GuestbookEntry>();
        }

        // Sparar inlägg i JSON-filen
        public void Save(List<GuestbookEntry> guestbookEntries)
        {
            // Konverterar listans inlägg till JSON
            string json = JsonSerializer.Serialize(guestbookEntries);

            // Skriver innehållet till filen
            File.WriteAllText(jsonFile, json);
        }

    }
}