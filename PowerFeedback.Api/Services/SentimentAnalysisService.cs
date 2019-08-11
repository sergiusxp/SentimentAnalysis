using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerFeedback.Api.Services
{
    public interface ISentimentAnalysisService
    {
        Task<SentimentResult> Analyze(string comment, string lang);
    }

    public class SentimentAnalysisService : ISentimentAnalysisService
    {
        private string _endpoint = $"https://powerfeedback.cognitiveservices.azure.com/";
        private IConfiguration _configuration { get; }

        public SentimentAnalysisService(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

        public async Task<SentimentResult> Analyze(string comment, string lang)
        {
            var _client = GetClient();
            return await _client.SentimentAsync(comment, lang, true);
        }

        private TextAnalyticsClient GetClient()
        {
            var cognitiveServicesApiKey = _configuration["CognitiveServicesApiKey"];
            var credentials = new ApiKeyServiceClientCredentials(cognitiveServicesApiKey);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = _endpoint
            };

            return client;
        }
    }
}
