using System.Collections.Generic;
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
                ListCatalogMatch();
                FormTagsLis();
            }
        }

        ObservableCollection<InfoCatalog> infoCatalogs = new ObservableCollection<InfoCatalog>(); //Каталог папок внтри папки
     
        private void ListCatalog()
        {
            /*Формирует катлог папок при входе в гланую папку*/
            DataGrid_Catalog.ItemsSource = null;
            infoCatalogs = new ObservableCollection<InfoCatalog>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Lebel_EnterCatalog.Content.ToString());
            foreach (var item in dir.GetDirectories())
            {
                infoCatalogs.Add(new InfoCatalog(item.Name, Lebel_EnterCatalog.Content.ToString()));
            }
            DataGrid_Catalog.ItemsSource = infoCatalogs;
            DataGrid_Catalog.Items.Refresh();


        }


        string currentFullNameCatalog = "";

        private void DataGrid_Catalog_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*Событие при двойном нажатии на таблицу*/
            string forever_papka = Lebel_EnterCatalog.Content + "\\" + ((InfoCatalog)DataGrid_Catalog.SelectedItem).NameCatalog;

         
            currentFullNameCatalog = forever_papka; 
            IsSizeWeb(); //открывает страницу
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
