using PowerFeedbackClientServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedbackClientServer.DTOs
{
    public class Sentiment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Score { get; set; }
        public string ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
