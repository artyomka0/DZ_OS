using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    public int GetRandom()
    {
      Random rnd = new Random();
      return rnd.Next(0, 10);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      News news = WorkWithJSON.DeserializeNew(WorkWithVk.GetWall(Convert.ToString(GetRandom())));
    }
  }
}
