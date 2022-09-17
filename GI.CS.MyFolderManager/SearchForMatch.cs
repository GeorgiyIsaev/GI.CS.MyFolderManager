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
    public class SearchForMatch
    {
        ObservableCollection<SearchForMatch> infoCatalogMatch = new ObservableCollection<SearchForMatch>();

        Dictionary<string, List<string>> catalogsKey = new Dictionary<string, List<string>>();





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
                        catalogsKey.Add((currentCatalog[j] + currentCatalog[j + i]), catalog.NameCatalog);
                    }
                }

            }

    


            infoCatalogMatch

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
