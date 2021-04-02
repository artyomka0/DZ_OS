using System;
using System.Text;
using System.Net;

namespace DZ_OS
{
  class WorkWithVk
  {
    //https://oauth.vk.com/authorize?client_id=7802823&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=groups&response_type=token&v=5.52
    private static readonly string token = "1cc23b7823cc49963beea8df4389e62831b1a16dca6f6b3117c446c04ece208a37a9a14899832e5b30c18";
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
