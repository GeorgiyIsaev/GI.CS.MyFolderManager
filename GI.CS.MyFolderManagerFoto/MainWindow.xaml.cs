using System;
using System.Collections.Generic;
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
            if (currentPapka.Length < 1) return;

            if (!isWebSize)
            {         
                Button_SizeWeb.Content = "Уменьшить";
                myWebBrowser.NavigateToString(GetHTML.Table(currentPapka, "95%"));

            }
            else{
            
                Button_SizeWeb.Content = "Увеличить";
                myWebBrowser.NavigateToString(GetHTML.Table(currentPapka, "200px"));              
            }
        }


    }
}
