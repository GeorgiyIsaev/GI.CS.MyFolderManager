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
        ObservableCollection<InfoCatalog> infoCatalogSearch = new ObservableCollection<InfoCatalog>();
        // public ObservableCollection<Search.SearchForMatch> infoCatalogMatch = new ObservableCollection<Search.SearchForMatch>();

        private void Button_EnterCatalog_Click(object sender, RoutedEventArgs e)
        {
            /*Выбор каталога*/
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                Lebel_EnterCatalog.Content = dialog.SelectedPath;
                ListCatalog();
                ListCatalogMatch();
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


      
        private void ListCatalogMatch()
        {         
            DataGrid_CatalogMatch.ItemsSource = null;          
            ParserDictionary.CreateNewFindMatcheCatalog(infoCatalog); //создадим словарь на основе содержимого каталога

            infoCatalogMatch = new ObservableCollection<SearchForMatch>();
            foreach (KeyValuePair<string, List<string>> item in ParserDictionary.catalogsKey)
            {
                SearchForMatch temp = new SearchForMatch(item);
                if (temp.CountFind <= 1) continue;
                infoCatalogMatch.Add(new SearchForMatch(item));
            }

            DataGrid_CatalogMatch.ItemsSource = infoCatalogMatch;
            DataGrid_CatalogMatch.Items.Refresh();
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

        private void DataGrid_CatalogMatch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*Показать папки имеющие повторы*/

            DataGrid_Catalog.ItemsSource = null;
            infoCatalogSearch = new ObservableCollection<InfoCatalog>();
                        
            SearchForMatch temp = (SearchForMatch)DataGrid_CatalogMatch.SelectedItem;

            foreach (var item in temp.ListFolderName)
            {
                infoCatalogSearch.Add(new InfoCatalog { NameCatalog = item, CountFile = ListCatalogCountFile(item) });
            }

            DataGrid_Catalog.ItemsSource = infoCatalogSearch;
            DataGrid_Catalog.Items.Refresh();
        }

        private void Button_DeleteMinCount_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_CatalogMatch.ItemsSource = null;
            ParserDictionary.CreateNewFindMatcheCatalog(infoCatalog); //создадим словарь на основе содержимого каталога

            infoCatalogMatch = new ObservableCollection<SearchForMatch>();
            int inputCountWords;
            bool isNumeric = int.TryParse(TextBox_DeleteMinCount.Text, out inputCountWords);
            if (!isNumeric) inputCountWords = 0;

            foreach (KeyValuePair<string, List<string>> item in ParserDictionary.catalogsKey)
            {
                SearchForMatch temp = new SearchForMatch(item);

                if (temp.CountItem <= inputCountWords) continue;
                if (temp.CountFind <= 1) continue;

                infoCatalogMatch.Add(new SearchForMatch(item));
            }

            DataGrid_CatalogMatch.ItemsSource = infoCatalogMatch;
            DataGrid_CatalogMatch.Items.Refresh();
        }


        /*Тест картинок*/

        private void setCellImage(Grid g, Image img, int column, int row)
        {

            Grid.SetColumn(img, column);
            Grid.SetRow(img, row);

            if (!g.Children.Contains(img))
                g.Children.Add(img);

            g.UpdateLayout();
        }


    }
}
