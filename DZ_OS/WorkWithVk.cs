using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DZ_OS
{
  class WorkWithVk
  {
    //https://oauth.vk.com/authorize?client_id=7802823&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=wall&response_type=token&v=5.52
    private static string token = "922b9513c49ee31fcd76f62b9011d122a6395da0af19da02a24f94a333793395bd9bb664dbaf24be90819";
    public static void GetFromVk(int ID, int offset, string type)
    {
      string sURL;
      WebClient webClient = new WebClient();
      string getedData = " ";
      sURL = "https://api.vk.com/method/execute.getNew"+ type +"?v=5.52&offset=" + offset + "&id=" + ID + "&access_token=" + token;
      Console.WriteLine(sURL);
      getedData = webClient.DownloadString(sURL);
      WorkWithJSON.SetJsonString("("+ type + ").json", getedData);
      Console.WriteLine(getedData);
      //return getedData;
    }
  }
}
