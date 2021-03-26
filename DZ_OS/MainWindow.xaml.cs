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
      if (System.IO.File.Exists("f1(text).json"))
        System.IO.File.Delete("f1(text).json");
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
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      for (int i = 0; i < 5; i++)
      {
        WorkWithVk.GetWall();
      }
    }
  }
}
