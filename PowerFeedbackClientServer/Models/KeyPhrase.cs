using PowerFeedbackClientServer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedbackClientServer.Models
{
    public class KeyPhrase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Key { get; set; }
        public string SentimentId { get; set; }

        public Sentiment Sentiment { get; set; }
    }
}
