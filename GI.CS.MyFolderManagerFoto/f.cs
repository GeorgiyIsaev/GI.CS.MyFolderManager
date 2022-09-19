using System.Windows;
using System.Windows.Input;

namespace GI.CS.MyFolderManagerFoto
{
    public partial class MainWindow
    {
        /*Открывает папку и отобржает содержимое*/



        private void DataGrid_Catalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_EnterCatalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_V_Click(object sender, RoutedEventArgs e)
        {  /*Достает колонку с повторами*/

            if (Column_0.Width.Value > 0)
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
