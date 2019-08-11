using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using PowerFeedback.Api.Services;

namespace PowerFeedback.Api.Controllers
{
    [Route("api/SentimentAnalysis")]
    [ApiController]
    public class SentimentAnalysisController : ControllerBase
    {
        private ISentimentAnalysisService _sentimentAnalysisService;

        public SentimentAnalysisController(
            ISentimentAnalysisService sentimentAnalysisService)
        {
            _sentimentAnalysisService = sentimentAnalysisService;
        }

        [HttpGet]
        [Route("Store")]
        public ActionResult<IEnumerable<string>> StoreComment()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("Analyze")]
        public async Task<ActionResult<SentimentResult>> Analyze(string comment)
        {
            if (comment == null || comment.Length < 5)
                throw new Exception("Comment length must be greater than 4 characters.");
            var result = await _sentimentAnalysisService.Analyze(comment, "en");
            return Ok(result);
        }
    }
}
