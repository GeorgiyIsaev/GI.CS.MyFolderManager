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
        }

        private void DataGrid_Catalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_EnterCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_V_Click(object sender, RoutedEventArgs e)
        {  /*Достает колонку с повторами*/

            if(Column_0.Width.Value > 0)
            {
                Column_0.Width = new GridLength(0);
            }
            else
            {
                Column_0.Width = new GridLength(300);
            }
        }
    }
}
