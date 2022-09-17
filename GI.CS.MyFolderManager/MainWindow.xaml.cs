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

        ObservableCollection<TablesTest> tablesTest = new ObservableCollection<TablesTest>();
        public class TablesTest
        {
            public String NameCatalog { get; set; }
            public int CountFile { get; set; }
   
        }



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
        
            DataGrid_Catalog.ItemsSource = null; //сборс
            tablesTest = new ObservableCollection<TablesTest>();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Lebel_EnterCatalog.Content.ToString());
            foreach (var item in dir.GetDirectories())
            {
                tablesTest.Add(new TablesTest { NameCatalog = item.Name, /*Id = testP.Id, GroupName = testP.Group, TestName = testP.Name, Count = testP.Quests.Count()*/});
            }    
            DataGrid_Catalog.ItemsSource = tablesTest;
            DataGrid_Catalog.Items.Refresh();
        }

    }
}
