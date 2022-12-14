using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GI.CS.MyFolderManagerFoto
{
    public partial class MainWindow
    {
       

        public static SortedDictionary<string, List<string>> TagAndCatalogs;

        private void FormTagsLis()
        {
            TagAndCatalogs = new SortedDictionary<string, List<string>>();
            TextBox_Tags.Children.Clear();
            foreach (InfoCatalog val in infoCatalogs)
            {
                AddDictionary("All", val.NameCatalog);

                if (val.tags.Count == 0)
                {
                    AddDictionary("!Нет тега!", val.NameCatalog);
                    continue;
                }                
                
                foreach (var tagName in val.tags)
                {
                  //.ToUpper()
                    AddDictionary(tagName, val.NameCatalog);
                }
            }
            EnterToTags();        
        }

        bool isSort = false;
        private void Button_SortTags_Click(object sender, RoutedEventArgs e)
        {
            if (!isSort)
            {
                isSort = true;
                SortTagsForCount();
            }
            else
            {
                isSort = false;
                TextBox_Tags.Children.Clear();
                EnterToTags();
            }
        }


        private static void AddDictionary(string key, string item)
        {
            if (!TagAndCatalogs.ContainsKey(key))
            {
                TagAndCatalogs[key] = new List<string>();
            }
            TagAndCatalogs[key].Add(item);
        }

        private void SortTagsForCount()
        {     
            List<Button> lisyBtns = new List<Button>();
            foreach (var btn in TextBox_Tags.Children)
            {
                lisyBtns.Add((Button)btn);
            }
            lisyBtns.Sort(delegate (Button x, Button y)
            {
                KeyValuePair<string, List<string>> paraX = ((KeyValuePair<string, List<string>>)x.Tag);
                KeyValuePair<string, List<string>> paraY = ((KeyValuePair<string, List<string>>)y.Tag);


                if (paraX.Value.Count < paraY.Value.Count) return 1;
                else if (paraX.Value.Count == paraY.Value.Count) return 0;
                else return -1;
    
            });

            TextBox_Tags.Children.Clear();
            foreach (var val in lisyBtns)
            {
                TextBox_Tags.Children.Add(val);
            }
        }



        private void EnterToTags()
        {       
            foreach(var val in TagAndCatalogs)
            {
                Button btn = new Button();
                btn.Content = " " + val.Key + " (" + val.Value.Count + ")"; 
                btn.Tag = val;
                btn.FontSize = 14;
           
                var d = btn.Tag;

                if(val.Value.Count >= 100)
                {
                    btn.Background = new SolidColorBrush(Colors.Red);
                    btn.FontWeight = FontWeights.Bold;
                    btn.Foreground = new SolidColorBrush(Colors.Gold);
                }
                else if (val.Value.Count >= 50)
                {
                    btn.Background = new SolidColorBrush(Colors.DarkOrange);
                    btn.Foreground = new SolidColorBrush(Colors.Red);
                }
                else if (val.Value.Count >= 25)
                {
                    btn.Background = new SolidColorBrush(Colors.Orange);
                }
                else if (val.Value.Count >= 10)
                {
                    btn.Background = new SolidColorBrush(Colors.Yellow);
                }
                else if (val.Value.Count >= 5)
                {
                    btn.Background = new SolidColorBrush(Colors.LightGreen);
                }
                else if (val.Value.Count >= 2)
                {
                    btn.Background = new SolidColorBrush(Colors.GreenYellow);
                }
                else if (val.Value.Count >= 1)
                {
                    btn.Background = new SolidColorBrush(Colors.White);
                }

                if (val.Key == "!Нет тега!" || val.Key == "All")
                {
                    btn.Background = new SolidColorBrush(Colors.Blue);
                    btn.Foreground = new SolidColorBrush(Colors.White);
                    btn.FontWeight = FontWeights.Bold;
                }

                btn.Click += Button_EnterTag;
                TextBox_Tags.Children.Add(btn);    

                //добавить действие с заполнением таблицы
            }
        } 
        private void Button_EnterTag(Object sender, EventArgs e)
        {
            var val = ((Button)sender);
            KeyValuePair<string, List<string>> para = ((KeyValuePair<string, List<string>>)val.Tag);
            EnterTag(para.Value);     
        }


        private void EnterTag(List<string> catalogs)
        {
            /*Показать папки имеющие повторы*/
            DataGrid_Catalog.ItemsSource = null;
            infoCatalogSearch = new ObservableCollection<InfoCatalog>();
            foreach (var item in catalogs)
            {
                infoCatalogSearch.Add(new InfoCatalog(item, Lebel_EnterCatalog.Content.ToString()));     
            }

            DataGrid_Catalog.ItemsSource = infoCatalogSearch;
            DataGrid_Catalog.Items.Refresh();
        }

    }
}
