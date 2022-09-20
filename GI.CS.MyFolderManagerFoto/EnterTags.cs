using System;
using System.Collections.Generic;
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
                if(val.tags.Count == 0)
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
                btn.Click += MyBtn_Click;





                TextBox_Tags.Children.Add(btn);    

                //добавить действие с заполнением таблицы
            }
        } 
        private void MyBtn_Click(Object sender, EventArgs e)
        {

            MessageBox.Show("");
            //MyMethod((sender as Button).Tag);
        }


    }
}
