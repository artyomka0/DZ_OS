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
    //https://oauth.vk.com/blank.html#access_token=acc9c71ef06cb9f2cb5e1addfff19fc56b7ec4dc6dd8d04e0764b6118995abe8d221d63fa39cf005d8407&expires_in=86400&user_id=390678051
    public static string GetWall(string groupId) 
    {
      string token = "acc9c71ef06cb9f2cb5e1addfff19fc56b7ec4dc6dd8d04e0764b6118995abe8d221d63fa39cf005d8407";
      string sURL;
      //for (int i = 0; i < 5; i++)
      //{
      var i = 0;
        sURL = "https://api.vk.com/method/execute.getNew?v=5.52&owner_id=-184925550&offset=" + i + "&count=1&access_token=" + token;
        WebClient webClient = new WebClient();
        string getedData = webClient.DownloadString(sURL);
        WorkWithJSON.SetJsonString("f1(text).json", getedData);
      return getedData;
      //}
    }
  }
}
