using PowerFeedbackClientServer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedbackClientServer.Models
{
    public class TextEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string SentimentId { get; set; }

        public Sentiment Sentiment { get; set; }
    }
}
