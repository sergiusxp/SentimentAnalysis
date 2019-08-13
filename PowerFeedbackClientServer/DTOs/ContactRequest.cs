using PowerFeedbackClientServer.Models;

namespace PowerFeedbackClientServer.DTOs
{
    public class ContactRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public ContactType ContactType { get; set; }
        public string Comment { get; set; }
    }
}
