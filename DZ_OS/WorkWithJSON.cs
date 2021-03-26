using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DZ_OS
{
  public class News
  {
    public string Id;
    public string Text;
  }
  public class response
  {
    public int Id;
    public string Text;
  }

  public class Root
  {
    public response Response { get; set; }
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
        StreamWriter sw = new StreamWriter(fileName,true);
        sw.WriteLine(getedData);
        sw.Close();
    }
    public static News DeserializeNew(string json)
    {
      Root root = JsonSerializer.Deserialize<Root>(json);
      News news = new News();
      return news;
    }
  }
}
