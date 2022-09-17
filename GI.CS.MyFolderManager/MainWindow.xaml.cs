using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GI.CS.MyFolderManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_ManagementProfile_Loaded;
        }

        private void Window_ManagementProfile_Loaded(object sender, RoutedEventArgs e)
        {            
        }

        ObservableCollection<InfoCatalog> infoCatalog = new ObservableCollection<InfoCatalog>();



        private void Button_EnterCatalog_Click(object sender, RoutedEventArgs e)
        {
            /*Выбор каталога*/
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                Lebel_EnterCatalog.Content = dialog.SelectedPath;
                ListCatalog();
            }
        }

        private void ListCatalog(){
        
            DataGrid_Catalog.ItemsSource = null; 
            infoCatalog = new ObservableCollection<InfoCatalog>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Lebel_EnterCatalog.Content.ToString());
            foreach (var item in dir.GetDirectories())
            {            
                infoCatalog.Add(new InfoCatalog { NameCatalog = item.Name, CountFile= ListCatalogCountFile(item.Name)});
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
       
            try{       
                string forever_papka = Lebel_EnterCatalog.Content + "\\" + ((InfoCatalog)DataGrid_Catalog.SelectedItem).NameCatalog;
                System.Diagnostics.Process.Start("explorer", forever_papka);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Process.Start("explorer", Lebel_EnterCatalog.Content.ToString());
            }
        }

       

    }
}
