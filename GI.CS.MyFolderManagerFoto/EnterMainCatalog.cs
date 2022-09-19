using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GI.CS.MyFolderManagerFoto
{
    public partial class MainWindow
    {
        /*Открывает папку и отобржает содержимое*/
        private void Button_EnterCatalog_Click(object sender, RoutedEventArgs e)
        {
            /*Выбор каталога*/
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                Lebel_EnterCatalog.Content = dialog.SelectedPath;
                ListCatalog();
               // ListCatalogMatch();
            }
        }

        ObservableCollection<InfoCatalog> infoCatalog = new ObservableCollection<InfoCatalog>();

        private void ListCatalog()
        {

            DataGrid_Catalog.ItemsSource = null;
            infoCatalog = new ObservableCollection<InfoCatalog>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Lebel_EnterCatalog.Content.ToString());
            foreach (var item in dir.GetDirectories())
            {
                infoCatalog.Add(new InfoCatalog { NameCatalog = item.Name, CountFile = ListCatalogCountFile(item.Name) });
            }
            DataGrid_Catalog.ItemsSource = infoCatalog;
            DataGrid_Catalog.Items.Refresh();


        }
        private int ListCatalogCountFile(string NameCatalog)
        {
            int countFile = new System.IO.DirectoryInfo(Lebel_EnterCatalog.Content + "\\" + NameCatalog)
                .GetFiles("*.*", System.IO.SearchOption.AllDirectories).Length;
            return countFile;
        }

        private void DataGrid_Catalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
