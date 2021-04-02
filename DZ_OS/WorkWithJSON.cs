using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DZ_OS
{
  public class News
  {
    public int Id;
    public string Text;
  }
  
  public class Response
  {
    [JsonPropertyNameAttribute("Id")]
    public int Id { get; set; }
    [JsonPropertyNameAttribute("Text")]
    public string Text { get; set; }
  }

  public class VkNewText
  {
   [JsonPropertyNameAttribute("response")]
   public Response Response { get; set; }
  }
  public class Response1
  {
    [JsonPropertyNameAttribute("Count")]
    public int Count { get; set; }
  }
  public class VkCount
  {
    [JsonPropertyNameAttribute("response")]
    public Response1 Response { get; set; }
  }
  class WorkWithJSON
    {
    /*
      public static JsonSerializerOptions SetSerializerOptions()
      {
       JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
         {
         WriteIndented = true,
          AllowTrailingCommas = true,
          };
       return jsonSerializerOptions;
      }
    */
    /*
      public static void SetNewsInJSON(News[] news)
      {
        using (FileStream file = new FileStream("f1(text).json", FileMode.Append))
        {
        string JsonString = JsonSerializer.Serialize(news);
        JsonSerializer.SerializeAsync<News[]>(file, news,SetSerializerOptions());
        }
      }
   */
    public static void SetJsonString(string fileName, string getedData)
    {
        StreamWriter sw = new StreamWriter(fileName , true, Encoding.UTF8);
        sw.WriteLine(getedData);
        sw.Close();
    }

    public static void GetJsonString(string fileName)
    {
        StreamReader sw = new StreamReader(fileName, Encoding.UTF8);
        string getedData = sw.ReadLine();
        sw.Close();
    }
    public static News DeserializeNewByString(string json)
    {
      VkNewText root = JsonSerializer.Deserialize<VkNewText>(json);
      News news = new News
      {
        Id = root.Response.Id,
        Text = root.Response.Text
      };
      return news;
    }

    public static int DeserializeCount(string jsonString)
    {
      VkCount vkCount = JsonSerializer.Deserialize<VkCount>(jsonString);
      return vkCount.Response.Count;
    }
  }
}