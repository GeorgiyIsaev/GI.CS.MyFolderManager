using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        private void ListCatalog() {

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
            /*Событие выбора папки двойным щелчком*/

            try {
                string forever_papka = Lebel_EnterCatalog.Content + "\\" + ((InfoCatalog)DataGrid_Catalog.SelectedItem).NameCatalog;
               // System.Diagnostics.Process.Start("explorer", forever_papka);
                GetListImage(forever_papka);
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
        private void GetListImage(string nameCatalog)
        {    /*Показывает список файлов*/
            // если папка существует
            if (System.IO.Directory.Exists(nameCatalog))
            {
                string text = "";     
                string[] files = System.IO.Directory.GetFiles(nameCatalog);
                   int column = 0;
                int row = 0;

                Image_Board.Children.Clear(); //очистить все содержимое грида

                foreach (string s in files)
                {
                    text += s + "\n";
                    if(column >=5)
                    {
                        column = 0; row++;

                        Image_Board.RowDefinitions.Add(new RowDefinition());

                        
                    }
                 
                    AddImage2(s, column++, row);
                }
                //MessageBox.Show("" + text);
            }
        }

        private void AddImage2(string nameImage, int column, int row)
        {          
            
            Image img = new Image();  
            img.Margin = new Thickness(5, 5, 5, 5);
            Grid.SetColumn(img, column);
            Grid.SetRow(img, row);

            Uri uri2 = new Uri(@"C:\nofoto.jpg"); //заменить на путь к католгу exe
            Uri uri = new Uri(nameImage);
           

            try
            {
                img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);
            }
            catch (Exception){                           
                img.Source = new System.Windows.Media.Imaging.BitmapImage(uri2); 
            }



        
            Image_Board.Children.Add(img);

            //Grid.SetColumn(img, 0);
            //Grid.SetRow(img, row+ column);
            Image_Board_NotColumn.Children.Add(img);
        }

    


        private void AddImage(string nameImage)
        {

            /*Создадим картинку*/
            Image img = new Image();
            Uri uri = new Uri(nameImage);
            img.Source = new System.Windows.Media.Imaging.BitmapImage(uri);


            DataGrid dg = new DataGrid();
            Image_Board.Children.Add(dg);

            //DataGrid

            DataTable dt = new DataTable();

            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");
            dt.Columns.Add("Column3");
            dt.Columns.Add("Column4", typeof(Image)); // type of image!

            DataRow dr = dt.NewRow();
            dr[0] = "aaa";
            dr[1] = "bbb";
            dr[2] = "ccc";
            dr[3] = img; // add a sample image

            dt.Rows.Add(dr);


            dg.ItemsSource = dt.DefaultView;

           // Image_Board.Children.Add(dt);

        }

     

        private void testTable_Click(object sender, RoutedEventArgs e)
        {
           





            if (Image_Board.Visibility != Visibility.Collapsed)
            {
                Image_Board.Visibility = Visibility.Collapsed;
                Image_Board_NotColumn.Visibility = Visibility.Visible;
            }
            else
            {
                Image_Board.Visibility = Visibility.Visible;
                Image_Board_NotColumn.Visibility = Visibility.Collapsed;
            }
            
            
            //Image_Board.Visibility = Visibility.Collapsed;
            //Image_Board.Children.Clear();
           // col1 = false;

            // Image_Board.Remove(col1);
        }

        //    Image finalImage = new Image();
        //    finalImage.Width = 80;

        //    BitmapImage logo = new BitmapImage();
        //    logo.BeginInit();
        //    logo.UriSource = new Uri(nameImage);
        //    logo.EndInit();

        //    finalImage.Source = logo;
        //}

        //    private void DataGrid_CatalogMatch_Selected(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string forever_papka = Lebel_EnterCatalog.Content + "\\" + ((InfoCatalog)DataGrid_Catalog.SelectedItem).NameCatalog;
        //       // System.Diagnostics.Process.Start("explorer", forever_papka);
        //        MessageBox.Show("" + forever_papka);

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Process.Start("explorer", Lebel_EnterCatalog.Content.ToString());
        //    }





        //   // AddImage(string nameImage);
        //}

        //   private void setCellImage(Grid g, Image img, int column, int row)
        //   {

        //       Grid.SetColumn(img, column);
        //       Grid.SetRow(img, row);

        //       if (!g.Children.Contains(img))
        //           g.Children.Add(img);

        //       g.UpdateLayout();
        //   }
        //private void GridIm(string nameCatalog)
        //   {


        //       for (int i = 0; i < 15; i++)
        //           for (int j = 0; j < 15; j++)
        //               setCellImage(Image_Board, "", i, j);
        //   }

    }
}

