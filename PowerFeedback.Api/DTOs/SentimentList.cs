using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using PowerFeedback.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedback.Api.DTOs
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