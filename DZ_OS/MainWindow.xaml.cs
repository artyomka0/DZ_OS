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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DZ_OS
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      if (System.IO.File.Exists("f1(text).json"))
        System.IO.File.Delete("f1(text).json");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      ChromeOptions chromeOptions = new ChromeOptions();
      // for PC C:\Users\Titanicus\AppData\Local\Google\Chrome\User Data
      // for laptop C:\Users\Admin\AppData\Local\Google\Chrome\User Data
      chromeOptions.AddArgument(@"user-data-dir=C:\Users\Admin\AppData\Local\Google\Chrome\User Data");
      ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
      chromeDriver.Navigate().GoToUrl("https://vk.com/feed");
      
       //поиск с первой пары
      List<IWebElement> webElements = chromeDriver.FindElementsById("feed_rows").ToList();
      IWebElement webElementParent = null;
      WorkWithJSON.SetNewInJSON("id","text");
      foreach (var item in webElements)
      {
        if (!item.Displayed)
          continue;
        webElementParent = item;
        break;
      }
      if (webElementParent == null)
        return;
      webElements = webElementParent.FindElements(By.TagName("div")).ToList();
      foreach (var item in webElements)
      {
        if (!item.Displayed)
          continue;
        if (item.GetAttribute("class") == null)
          continue;
        if (!item.GetAttribute("class").Trim().Equals("feed_row"))
          continue;
        if (!item.Text.ToString().Equals(""))
        {
          WorkWithJSON.SetNewInJSON("789", item.Text.ToString());
        }
        

        /*
        string NewsText = item.Text;
        List<IWebElement> webElementsChild = item.FindElements(By.ClassName("author")).ToList();
        foreach (var itemChild in webElementsChild)
        {
          if (!itemChild.Displayed)
            continue;
          string author = itemChild.Text;
          // string id = itemChild.GetAttribute("data-post-id").Trim();
        }
        webElementsChild = item.FindElements(By.TagName("span")).ToList();
        foreach (var itemChild in webElementsChild)
        {
          if (!itemChild.Displayed)
            continue;
          if (itemChild.GetAttribute("time") == null)
            continue;
          DateTime dateTime = new DateTime(1970, 1, 1).AddSeconds(double.Parse(itemChild.GetAttribute("time"))).ToLocalTime();
        }
        */
      }
      
      /*
      webElements = (from item in chromeDriver.FindElementsByTagName("div")
                                         //where  item
                                       select item).ToList();
      

      List<IWebElement> webElements = (from item in chromeDriver.FindElementsByTagName("div")
                     where item.Displayed &&
                     item.GetAttribute("class") != null &&
                     item.GetAttribute("class").Trim().ToLower().Equals("feed_row")
                     select item).ToList();
      */
      /*
      for (int i = 0; i < webElements.Count(); i++)
      {
        if (!webElements[i].Text.ToString().Equals(""))
        {
          WorkWithJSON.SetNewInJSON(i.ToString(), webElements[i].Text.ToString());
        }
      }
      */
      MessageBox.Show("done");
    }
  }
}
