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

    public static string GetWall()
    {
      string token = "8c41dc5e3555a83ff17c0adf8fa2a85e47404fe2e496cfaa1dee2bbd8c2d7aca248ab03554a6a010d1c58";
      string sURL;
      int i = 0;
      WebClient webClient = new WebClient();
      //for (; i < 5; i++)
      //{
      sURL = "https://api.vk.com/method/execute.getNew?v=5.52&offset=" + i + "&access_token=" + token;
        string getedData = webClient.DownloadString(sURL);
        WorkWithJSON.SetJsonString("f1(text).json", getedData);
      Console.WriteLine(getedData);
      return getedData;
      //}
    }
  }
}
