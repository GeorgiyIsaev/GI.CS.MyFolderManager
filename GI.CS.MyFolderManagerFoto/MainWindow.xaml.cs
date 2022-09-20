using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace GI.CS.MyFolderManagerFoto
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Column_0.Width = new GridLength(0);
        }


        bool isWebSize = true;
        private void Button_SizeWeb_Click(object sender, RoutedEventArgs e)
        {
           
            isWebSize = isWebSize ?  false : true;
            IsSizeWeb();        
        }

        private void IsSizeWeb()
        {
            if (currentFullNameCatalog.Length < 1) return;

            if (!isWebSize)
            {         
                Button_SizeWeb.Content = "Таблица";
                myWebBrowser.NavigateToString(GetHTML.Table(currentFullNameCatalog, "95%"));

            }
            else{
            
                Button_SizeWeb.Content = "На всю страницу";
                myWebBrowser.NavigateToString(GetHTML.Table(currentFullNameCatalog, "200px"));              
            }
        }

        private void Button_OpenBrowser_Click(object sender, RoutedEventArgs e)
        {
            if (currentFullNameCatalog.Length < 1) return;
            /*Сохранить в файл*/
            using (var file = new StreamWriter("html.html", false, Encoding.UTF8))
            {
                file.WriteLine(myWebBrowser.Document.ToString());            
                System.Diagnostics.Process.Start("explorer", "html.html");
            }
        }

        private void Button_OpenCatalog_Click(object sender, RoutedEventArgs e)
        {
            if (currentFullNameCatalog.Length < 1) return;
            System.Diagnostics.Process.Start("explorer", currentFullNameCatalog);
        }
    }
}
