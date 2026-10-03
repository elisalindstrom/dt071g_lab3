// Interface som definierar lagringen av inlägg

namespace guestbook
{
    public interface IGuestbookStorage
    {
        // Metod som läser in sparade inlägg
        List<GuestbookEntry> Load();

        // Metod som sparar inlägg
        void Save(List<GuestbookEntry> guestbookEntries);
    }
}