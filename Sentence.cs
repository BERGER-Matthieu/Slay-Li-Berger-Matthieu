using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace Embala
{
    internal class Sentence
    {
        private string? _content;

        public string Content
        {
            get => _content;
        }

        public Sentence(string content)
        {
            _content = content;
        }

        public async Task<string> Correct()
        {
            var api = new OpenAI_API.OpenAIAPI(OpenAi.Key);
            var result = await api.Completions.GetCompletion("Correct the gramar faults in \"" + this.Content + "\", you should only write the answer an nothing else.");
            return result;
        }

        public async Task<string> Translate()
        {
            var api = new OpenAI_API.OpenAIAPI(OpenAi.Key);
            var result = await api.Completions.GetCompletion("translate \"" + this.Content + "\", to english if it's french, else to french, you should only write the answer an nothing else.");
            return result;
        }
    }
}
