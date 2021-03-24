using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace DZ_OS
{
  
    [DataContract]
    public class ThisNew
    {
      [DataMember]
      public string Id;
      [DataMember]
      public string Text;
    }

    class WorkWithJSON
    {
      public static void SetNewInJSON(string id, string text)
      {
      ThisNew thisNew = new ThisNew();
      thisNew.Id = id;
      thisNew.Text = text;
      DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(ThisNew));
        using (FileStream file = new FileStream("f1(text).json", FileMode.OpenOrCreate))
        {
          dataContractJsonSerializer.WriteObject(file, thisNew);
        }
      }
     /*
      public static Student GetDataFromJSON()
      {
        if (!File.Exists("студентик.json"))
          return new Student();
        DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Student));
        using (FileStream file = new FileStream("студентик.json", FileMode.Open))
        {
          return (Student)dataContractJsonSerializer.ReadObject(file);
        }
      }
     */
    }
}
