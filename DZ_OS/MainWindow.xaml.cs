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


    public void GetNew(object type)
    {
      string type1 = type.ToString();
      for (int i = 0; i < WorkWithVk.GetPostsCount(-115511710); i++)
      {
        Thread.Sleep(1000);
        WorkWithVk.GetFromVk(-115511710, i, type1);
        Thread.Sleep(1000);
      }
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Thread thread1 = new Thread(GetNew);
      thread1.Start("Text");
      Thread thread2 = new Thread(GetNew);
      thread2.Start("Photo");
      Thread thread3 = new Thread(GetNew);
      thread3.Start("Link");
    }
  }
}