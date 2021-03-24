using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DZ_OS
{
  public class News
  {
    [JsonInclude]
    public string Id;
    [JsonInclude]
    public string Text;
  }
  class WorkWithJSON
    {
      public static void SetNewInJSON(News[] news)
      {
      JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
      {
        WriteIndented = true,
        AllowTrailingCommas = true
      };
        using (FileStream file = new FileStream("f1(text).json", FileMode.Append))
        {
        string JsonString = JsonSerializer.Serialize(news);
        JsonSerializer.SerializeAsync<News[]>(file, news,jsonSerializerOptions);
        }
      }
    }
}
