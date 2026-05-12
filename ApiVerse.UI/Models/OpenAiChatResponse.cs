using System.Text.Json.Serialization;

namespace ApiVerse.UI.Models
{
    public class OpenAiChatResponse
    {
    
        [JsonPropertyName("choices")]
        public List<OpenAiChoice> Choices { get; set; } = new();

        public class OpenAiChoice
        {
            [JsonPropertyName("message")]
            public OpenAiMessage Message { get; set; } = new();
        }

        public class OpenAiMessage
        {
            [JsonPropertyName("content")]
            public string Content { get; set; } = "";
        }
    }
}
