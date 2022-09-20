using System.Collections.Generic;
using System.Windows.Controls;

namespace GI.CS.MyFolderManagerFoto
{
    public partial class MainWindow
    {
        public static Dictionary<string, List<string>> TagAndCatalogs;

        private void FormTagsLis()
        {
            TagAndCatalogs = new Dictionary<string, List<string>>();

            foreach (InfoCatalog val in infoCatalogs)
            {
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
            string text = "";
            foreach(var val in TagAndCatalogs)
            {
                Button btn = new Button();
                btn.Content = " " + val.Key + " (" + val.Value.Count + ")";
                TextBox_Tags.Children.Add(btn);
       
               // text += val.Key + "(" + val.Value.Count + ")";
            }

           // TextBox_Tags.Text = text; 
        }
    }
}
