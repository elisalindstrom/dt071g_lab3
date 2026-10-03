// Hantering av gästbokens inlägg, lägga till/ta bort/visa inlägg.

namespace guestbook
{
    public class Guestbook
    {
        private readonly IGuestbookStorage storage;
        private List<GuestbookEntry> guestbookEntries;

        // Konstruktor, skapar gästboken och tidigare sparade inlägg laddas
        public Guestbook(IGuestbookStorage storage)
        {
            this.storage = storage;
            guestbookEntries = storage.Load();
        }

        // Skapar och sparar nytt inlägg
        public GuestbookEntry AddEntry(string Author, string Message)
        {
            GuestbookEntry guestbookEntry = new GuestbookEntry();
            guestbookEntry.Author = Author;
            guestbookEntry.Message = Message;

            // Lägger till inlägget och sparar listan
            guestbookEntries.Add(guestbookEntry);
            storage.Save(guestbookEntries);

            // Returnerar det nya inlägget
            return guestbookEntry;
        }

        // Ta bort ett inlägg utifrån index
        public int DelEntry(int index)
        {
            guestbookEntries.RemoveAt(index);
            storage.Save(guestbookEntries);

            return index;
        }

        // Hämtar alla inlägg
        public List<GuestbookEntry> GetEntries()
        {
            return guestbookEntries;
        }
    }
}