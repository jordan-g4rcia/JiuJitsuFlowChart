using MongoDB.Bson.Serialization.Attributes;

namespace JJFC.Web.Models.Database;

public class Position
{
    [BsonId] 
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int Version { get; set; } = 1;

    public string Description { get; set; }
    public string YoutubeVideoId { get; set; }
    public List<string> ProsList { get; set; } = new();
    public List<string> ConsList { get; set; } = new();
    public List<string> PossibleAttacks { get; set; } = new();
    public List<string> PossibleEscapes { get; set; } = new();
    public List<string> Transitions { get; set; } = new();
    public bool? IsVisible { get; set; }
}