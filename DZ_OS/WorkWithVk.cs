using System;
using System.Net;

namespace DZ_OS
{
  class WorkWithVk
  {
    //https://oauth.vk.com/authorize?client_id=7802823&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=wall&response_type=token&v=5.52
    private static readonly string token = "820484d54a229930589afb5a30a0b8526a923ba22266c78ad6cf9a9f31a3aadd95d881f548704cf07d9c3";
    public static void GetFromVk(int ID, int offset, string type)
    {
      string sURL = "https://api.vk.com/method/execute.getNew" + type + "?v=5.52&offset=" + offset + "&id=" + ID + "&access_token=" + token;
      WebClient webClient = new WebClient();
      string getedData = webClient.DownloadString(sURL);
      Console.WriteLine(sURL);
      WorkWithJSON.SetJsonString("("+ type + ").json", getedData);
      Console.WriteLine(getedData);
      //return getedData;
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
