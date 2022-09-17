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
            public SearchForMatch(Dictionary<string, List<string>> catalogsKey)
            {
                CatalogsKey = catalogsKey;
                var keys = catalogsKey.Keys;
                foreach (var temp in keys)
                {
                    NameCatalog = temp; //ключ-название группы катлогов
                    CountItem = (NameCatalog.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList()).Count;
                    CountFind = catalogsKey[temp].Count;
                }
            }

            public String NameCatalog { get; set; }
            public int CountFind { get; set; }
            public int CountItem { get; set; }

            public List<string> ListFolderName { get { return CatalogsKey[NameCatalog]; } }

            Dictionary<string, List<string>> CatalogsKey;
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
                        for (int j = i; i < count - 1; j++)
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

