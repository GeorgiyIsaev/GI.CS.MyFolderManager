using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.CS.MyFolderManagerFoto
{
    /*Класс для поиска совпадений*/
    public static class ParserDictionary
    {
        public static Dictionary<string, List<string>> catalogsKey;
        public static void CreateNewFindMatcheCatalog(ObservableCollection<InfoCatalog> infoCatalogs)
        {
            /*Начинаем поиск схожих каталогов*/
            catalogsKey = new Dictionary<string, List<string>>();
            foreach (var catalog in infoCatalogs)
            {
                var currentCatalog = catalog.SplitName();              

                for (int i = 0; i < currentCatalog.Count; i++)
                {
                    string key = "";
                    int tempCur = i;
                    while (true)
                    {
                        key += currentCatalog[tempCur];
                        AddDictionary(key, catalog.NameCatalog);
                        tempCur++;
                        if (tempCur >= currentCatalog.Count) break;
                        key += " ";

                        /*Если шаблон повторяется в одной строке манга дублируется
                         Как решить эту проблему?
                        -*/
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
