using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_OS
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// https://docs.microsoft.com/ru-ru/troubleshoot/iis/make-get-request
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      if (System.IO.File.Exists("(Text).json"))
        System.IO.File.Delete("(Text).json");
      if (System.IO.File.Exists("(Photo).json"))
        System.IO.File.Delete("(Photo).json");
      if (System.IO.File.Exists("(Link).json"))
        System.IO.File.Delete("(Link).json");
    }
    /*
    public string GetSaveIdVk()
    {
      DateTime dateTime = new DateTime();
      dateTime = DateTime.Now;
      int key = unchecked((int)dateTime.Ticks);
      Random rnd = new Random(key);
      string[] numbers = new string[7];
      numbers[0] = "1";
      numbers[1] = "-184925550";
      numbers[2] = "-167194618";
      numbers[3] = "-77253035";
      numbers[4] = "-101965347";
      numbers[5] = "-63000676"; 
      numbers[6] = "-115511710";
      Console.WriteLine(numbers[rnd.Next(0, 6)]);
      return numbers[rnd.Next(0, 6)];
    }
    */
    EventWaitHandle wh1 = new AutoResetEvent(false);
    EventWaitHandle wh2 = new AutoResetEvent(false);
    EventWaitHandle wh3 = new AutoResetEvent(false);
    EventWaitHandle wh12 = new AutoResetEvent(false);
    EventWaitHandle wh22 = new AutoResetEvent(false);
    EventWaitHandle wh32 = new AutoResetEvent(false);
    public void GetNew(object type)
    {
      string type1 = type.ToString();
      int postCount = WorkWithVk.GetPostsCount(-115511710);
      for (int i = 0; i < postCount; i++)
      {
        Thread.Sleep(1000);
        string getedData = WorkWithVk.GetFromVk(-115511710, i, type1);
        Console.WriteLine(Thread.CurrentThread.Name);
        WorkWithJSON.SetJsonString("(" + type + ").json", getedData);
        int a = Convert.ToInt32(Thread.CurrentThread.Name);
        switch (a)
        {
        case 1:
            wh1.Set();
            //WaitHandle.SignalAndWait(wh1, wh12);
            break;
        case 2:
            wh2.Set();
           //WaitHandle.SignalAndWait(wh2, wh22);
            break;
        case 3:
            wh3.Set();
            //WaitHandle.SignalAndWait(wh3, wh32);
            break;
        };
      };
      
    }

    public void ReadNews()
    {
      Thread.Sleep(2000);
      //int a = Convert.ToInt32(i);
      string type = " ";
      for (int i = 0; i < 4; i++)
      {
        switch (i)
        {
          case 0:
            type = "sleep";
            break;
          case 1:
            type = "Text";
            wh1.WaitOne();
            break;
          case 2:
            type = "Photo";
          wh2.WaitOne();
            break;
          case 3:
            type = "Link";
          wh3.WaitOne();
            break;
        };
      Console.WriteLine(Thread.CurrentThread.Name + "   в "+ i);
        if (i != 0)
        {
          WorkWithJSON.GetJsonString("(" + type + ").json");
          Thread.Sleep(1000);
        }
        /*
        switch (i)
        {
          case 0:
            break;
          case 1:
            WaitHandle.SignalAndWait(wh12, wh1);
            break;
          case 2:
            WaitHandle.SignalAndWait(wh22, wh2);
            break;
          case 3:
            WaitHandle.SignalAndWait(wh32, wh3);
            break;
        };
        */
        if (i == 3)
        {
          i = 0;
        }
      }
      
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Thread thread1 = new Thread(GetNew);
      thread1.Name = "1";
      Thread thread2 = new Thread(GetNew);
      thread2.Name = "2";
      Thread thread3 = new Thread(GetNew);
      thread3.Name = "3";
      Thread thread4 = new Thread(ReadNews);
      thread4.Name = "th4";
      thread1.Start("Text");
      thread2.Start("Photo");
      thread3.Start("Link");
      thread4.Start();
      // Thread Meneger
     // for (int i = 0; i < 4; i++)
      //{

      //}
    }
  }
}