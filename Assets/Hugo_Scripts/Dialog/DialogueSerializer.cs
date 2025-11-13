using Newtonsoft.Json;
using System.Collections.Generic;

public class ConversationData
{
    [JsonProperty("conversation")]
    public List<Conversation> Conversations { get; set; }
}

public class Conversation
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("maxDialog")]
    public string MaxDialog { get; set; }

    [JsonProperty("steps")]
    public List<Step> Steps { get; set; }
}

public class Step
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("event")]
    public string Event { get; set; }

    [JsonProperty("next")]
    public string Next { get; set; }
}