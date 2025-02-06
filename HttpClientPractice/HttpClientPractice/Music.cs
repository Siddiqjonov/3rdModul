using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HttpClientPractice;

public class Music
{
    //[JsonPropertyName("id")]
    public Guid? Id { get; set; }
    //[JsonPropertyName("name")]
    public string Name { get; set; }
    //[JsonPropertyName("mb")]
    public double MB { get; set; }
    //[JsonPropertyName("authorName")]
    public string AuthorName { get; set; }
    //[JsonPropertyName("description")]
    public string Description { get; set; }
    //[JsonPropertyName("quantityOfLikes")]
    public int QuentityLikes { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, MB: {MB}, AuthorName: {AuthorName}, Description: {Description}, QuentityLikes: {QuentityLikes},";
    }

}
