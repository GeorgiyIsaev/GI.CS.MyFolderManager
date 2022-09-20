using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace GI.CS.MyFolderManagerFoto
{
    public partial class MainWindow
    {
       

        public static SortedDictionary<string, List<string>> TagAndCatalogs;

        private void FormTagsLis()
        {
            TagAndCatalogs = new SortedDictionary<string, List<string>>();

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
                    AddDictionary(tagName, val.NameCatalog);
                }
            }
            EnterToTags();
        }
        private static void AddDictionary(string key, string item)
        {
            if (!TagAndCatalogs.ContainsKey(key))
            {
                TagAndCatalogs[key] = new List<string>();
            }
            TagAndCatalogs[key].Add(item);
        }

        private void EnterToTags()
        {       
            foreach(var val in TagAndCatalogs)
            {
                Button btn = new Button();
                btn.Content = " " + val.Key + " (" + val.Value.Count + ")"; 
                btn.Tag = val;

                var d = btn.Tag;
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
