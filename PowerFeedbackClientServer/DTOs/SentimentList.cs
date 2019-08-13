using PowerFeedbackClientServer.Models;
using System;

namespace PowerFeedbackClientServer.DTOs
{
    public class SentimentListItem
    {
        public string Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public ContactType ContactType { get; set; }
        public string Comment { get; set; }
        public decimal Score { get; set; }
    }
}