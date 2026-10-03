// Klass för ett gästboksinlägg

namespace guestbook
{
    public class GuestbookEntry
    {
        // Innehåller författare och meddelande
        public string? Author
        {
            get; set;
        }
        public string? Message
        {
            get; set;
        }
    }
}