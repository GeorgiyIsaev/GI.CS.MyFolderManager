using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GI.CS.MyFolderManager.MainWindow;

namespace GI.CS.MyFolderManager
{
    /*Класс для поиска совпадений*/
    public class Search
    { 
        Dictionary<string, List<string>> catalogsKey = new Dictionary<string, List<string>>();




        public class SearchForMatch
        {
            public String NameCatalog { get; set; }
            public int CountFind{ get; set; }
            public int CountItem { get; set; }

            public SearchForMatch(Dictionary<string, List<string>> catalogsKey)
            {
                AddItem(catalogsKey);
            }

            public void AddItem(Dictionary<string, List<string>> catalogsKey)
            {
                var keys = catalogsKey.Keys;
                foreach(var temp in keys)
                {
                    NameCatalog = temp;
                    CountItem = (NameCatalog.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList()).Count;
                    CountFind = catalogsKey[temp].Count;
                }
            }
        }


        public void CreateNewFindMatcheCatalog(ObservableCollection<InfoCatalog> infoCatalog)
        {
            /*Начинаем поиск схожих каталогов*/

            foreach(var catalog in infoCatalog)
            {
                var currentCatalog = catalog.SplitName();
                int count = currentCatalog.Count;

                for(int i = 0; i < count; i++)
                {
                    for (int j = i; i < count-1; j++)
                    {
                        string key = "";
                        int tempCur = j;
                        while (true)
                        {
                            key += currentCatalog[tempCur];
                            if (tempCur == i) break;
                        }
                        AddDictionary(key, catalog.NameCatalog);
                    }
                }
            }
        }


        public void AddDictionary(string key, string item)
        {

            if (!catalogsKey.ContainsKey(key))
            {
                catalogsKey[key] = new List<string>();
            }
            catalogsKey[key].Add(item);
        }






        public String NameCatalog { get; set; }
        public int CountFile { get; set; }

    }
}
