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

    public class Root
    {
        [JsonPropertyNameAttribute("response")]
        public Response Response { get; set; }
    }
  class WorkWithJSON
    {
      public static JsonSerializerOptions SetSerializerOptions()
      {
       JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
         {
         WriteIndented = true,
          AllowTrailingCommas = true,
          };
       return jsonSerializerOptions;
      }

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
        //sw.WriteLine(",]");
        sw.Close();
    }
    public static void SetJsonFormat(string fileName)
    {
      StreamWriter sw = new StreamWriter(fileName, true);
      sw.WriteLine("[]");
      sw.Close();
    }

    public static News DeserializeNewByString(string json)
    {
      Root root = JsonSerializer.Deserialize<Root>(json);
      News news = new News();
      news.Id = root.Response.Id;
      news.Text = root.Response.Text;
      return news;
    }
  }
}
