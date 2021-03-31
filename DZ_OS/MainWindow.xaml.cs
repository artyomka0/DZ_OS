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

    public void GetNewText()
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(1000);
        WorkWithVk.GetFromVk(-115511710, i,"Text");
        Thread.Sleep(2000);
      }
    }
    public void GetNewPhoto()
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(2000);
        WorkWithVk.GetFromVk(-115511710, i,"Photo");
        Thread.Sleep(1000);
      }
    }

    public void GetNewLink()
    {
      for (int i = 0; i < 5; i++)
      {
        Thread.Sleep(3000);
        WorkWithVk.GetFromVk(-115511710, i, "Link");
      }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Thread thread1 = new Thread(new ThreadStart(GetNewText));
      thread1.Start();
      Thread thread2 = new Thread(new ThreadStart(GetNewPhoto));
      thread2.Start();
      Thread thread3 = new Thread(new ThreadStart(GetNewLink));
      thread3.Start();
    }
  }
}