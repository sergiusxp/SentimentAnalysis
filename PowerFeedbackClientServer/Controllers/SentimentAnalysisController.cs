using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using PowerFeedbackClientServer.DTOs;
using PowerFeedbackClientServer.Models;
using PowerFeedbackClientServer.Services;

namespace PowerFeedbackClientServer.Controllers
{
    [Route("api/SentimentAnalysis")]
    [ApiController]
    public class SentimentAnalysisController : ControllerBase
    {
        private ISentimentAnalysisService _sentimentAnalysisService;
        private readonly PfDbContext _context;

        public SentimentAnalysisController(
            PfDbContext context,
            ISentimentAnalysisService sentimentAnalysisService)
        {
            _context = context;
            _sentimentAnalysisService = sentimentAnalysisService;
        }

        [HttpPost]
        [Route("Store")]
        public async Task<ActionResult> StoreComment(ContactRequest request)
        {
            Contact contact = new Contact()
            {
                Id = Guid.NewGuid().ToString(),
                RequestDate = DateTime.Now,
                Sentiment = null,
                EmailAddress = request.EmailAddress,
                Name = request.Name,
                Surname = request.Surname,
                Comment = request.Comment
            };

            if (request.ContactType == ContactType.Comment)
            {
                if (request.Comment == null || request.Comment.Length < 5)
                    throw new Exception("Comment length must be greater than 4 characters.");
                var sentiment = await _sentimentAnalysisService.Analyze(request.Comment, "en");
                contact.Sentiment = new Sentiment()
                {
                    Id = Guid.NewGuid().ToString(),
                    ContactId = contact.Id,
                    Score = decimal.Parse(sentiment.Score.ToString())
                };
                var entities = await _sentimentAnalysisService.Entities(request.Comment, "en");
                foreach (var entity in entities.Entities)
                {
                    TextEntity tE = new TextEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        SentimentId = contact.Sentiment.Id,
                        Name = entity.Name,
                        Type = entity.Type,
                        SubType = entity.SubType ?? "N/A"
                    };
                    await _context.TextEntities.AddAsync(tE);
                    foreach (var match in entity.Matches)
                    {
                        TextEntityMatch teM = new TextEntityMatch()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Score = Decimal.Parse(match.EntityTypeScore.ToString()),
                            TextEntityId = tE.Id
                        };
                        await _context.TextEntitiesMatch.AddAsync(teM);
                    }
                }
                var keyPhrases = await _sentimentAnalysisService.KeyPhrases(request.Comment, "en");
                foreach (string keyphrase in keyPhrases.KeyPhrases)
                {
                    var k = new KeyPhrase()
                    {
                        Id = Guid.NewGuid().ToString(),
                        SentimentId = contact.Sentiment.Id,
                        Key = keyphrase
                    };
                    await _context.KeyPhrases.AddAsync(k);
                }
            }
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("List")]
        public ActionResult<List<SentimentListItem>> List()
        {
            var query = from contact in _context.Contacts
                        join sentiment in _context.Sentiments on contact equals sentiment.Contact into gj
                        from subsent in gj.DefaultIfEmpty()
                        orderby contact.RequestDate descending
                        select new SentimentListItem
                        {
                            Id = contact.Id,
                            RequestDate = contact.RequestDate,
                            Surname = contact.Surname,
                            Name = contact.Name,
                            ContactType = contact.ContactType,
                            Comment = contact.Comment,
                            Score = subsent.Score
                        };
            return Ok(query.ToList());
        }

        [HttpPost]
        [Route("Analyze")]
        public async Task<ActionResult<SentimentResult>> Analyze([FromBody] SentimentRequest request)
        {
            var res = await _sentimentAnalysisService.Analyze(request.Comment, "en");
            return Ok(res);
        }
        
        [HttpPost]
        [Route("Analyze2")]
        public ActionResult<string> Analyze2([FromBody] SentimentRequest request)
        {
            return Ok(request.Comment + "-" + _sentimentAnalysisService.Test());
        }
    }
}
