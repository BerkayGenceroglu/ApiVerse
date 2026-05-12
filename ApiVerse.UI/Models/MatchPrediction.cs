namespace ApiVerse.UI.Models
{
    public class MatchPrediction
    {
        public string Match { get; set; }
        public string Prediction { get; set; }
        public string Confidence { get; set; }
    }

    public class OpenAiResponse
    {
        public List<Choice> Choices { get; set; }
    }

    public class Choice
    {
        public Message Message { get; set; }
    }

    public class Message
    {
        public string Content { get; set; }
    }
}
