using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace DZ_OS
{
  
    [DataContract]
    public class News
    {
      [DataMember]
      public string Id;
      [DataMember]
      public string Text;
    }

    class WorkWithJSON
    {
      public static void SetNewsInJSON(News[] news)
      {
        DataContractSerializer dataContractJsonSerializer = new DataContractSerializer(typeof(News[]));
        using (FileStream file = new FileStream("студент1.json", FileMode.OpenOrCreate))
        {
          dataContractJsonSerializer.WriteObject(file, news);
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
}
