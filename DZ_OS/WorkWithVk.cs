using System;
using System.Text;
using System.Net;

namespace DZ_OS
{
  class WorkWithVk
  {
    //https://oauth.vk.com/authorize?client_id=7802823&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=groups&response_type=token&v=5.52
    private static readonly string token = "f27d070868928a2a126a173c7fcc603181ce8a6b5e27e0955e4fa6aa81c463a8458d39189467672ce2dac";
    public static string GetFromVk(int ID, int offset, string type)
    {
      string sURL = "https://api.vk.com/method/execute.getNew" + type + "?v=5.52&offset=" + offset + "&id=" + ID + "&access_token=" + token;
      WebClient webClient = new WebClient();
      string getedData = Encoding.UTF8.GetString(webClient.DownloadData(sURL));
      //Console.WriteLine(sURL);
      //Console.WriteLine(getedData);
      return getedData;
    }

    public static int GetPostsCount(int ID)
    {
      string sURL = "https://api.vk.com/method/execute.getNewCount?v=5.52&id=" + ID + "&access_token=" + token;
      WebClient webClient = new WebClient();
      string getedData = webClient.DownloadString(sURL);
      return (WorkWithJSON.DeserializeCount(getedData)-1);
    }
  }
}
