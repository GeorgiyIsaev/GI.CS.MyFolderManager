using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GI.CS.MyFolderManager
{
    public partial class MainWindow
    {
        /*Коллекция*/
        public ObservableCollection<SearchForMatch> infoCatalogMatch = new ObservableCollection<SearchForMatch>();

        /*Класс коллекции*/
        public class SearchForMatch
        {
            public SearchForMatch(KeyValuePair<string, List<string>> item)
            {
                Item = item;
   
                NameCatalog = item.Key; //ключ-название группы катлогов
                CountItem = (NameCatalog.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList()).Count;
                CountFind = item.Value.Count;
            }

            public String NameCatalog { get; set; }
            public int CountFind { get; set; }
            public int CountItem { get; set; }
            
            public List<string> ListFolderName { get { return Item.Value; } }
            KeyValuePair<string, List<string>> Item;
        }

        /*Класс для поиска совпадений*/
        public static class ParserDictionary
        {
            public static Dictionary<string, List<string>>  catalogsKey;
            public static void CreateNewFindMatcheCatalog(ObservableCollection<InfoCatalog> infoCatalog)
            {
                /*Начинаем поиск схожих каталогов*/
                catalogsKey = new Dictionary<string, List<string>>();
                foreach (var catalog in infoCatalog)
                {
                    var currentCatalog = catalog.SplitName();
                    int count = currentCatalog.Count;

                    for (int i = 0; i < count; i++)
                    {
                        string key = "";
                        int tempCur = i;
                        while (true)
                        {
                            key += currentCatalog[tempCur];
                            AddDictionary(key, catalog.NameCatalog);
                            tempCur++;
                            if (tempCur >= count - 1) break;
                        }
                    }
                }
            }

            public static void AddDictionary(string key, string item)
            {

                if (!catalogsKey.ContainsKey(key))
                {
                    catalogsKey[key] = new List<string>();
                }
                catalogsKey[key].Add(item);
            }
        }
    }
}

