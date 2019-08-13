using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using PowerFeedback.Api.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedback.Api.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public ContactType ContactType { get; set; }
        public string Comment { get; set; }

        public Sentiment Sentiment { get; set; }
    }

    public enum ContactType
    {
        General = 0,
        Work = 1,
        Comment = 2
    }
}
