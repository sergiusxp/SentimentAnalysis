﻿using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using PowerFeedback.Api.DTOs;
using PowerFeedback.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedback.Api.DTOs
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
