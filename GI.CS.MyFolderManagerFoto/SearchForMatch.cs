using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.CS.MyFolderManagerFoto
{
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


        public bool IsListEqually(SearchForMatch search) {
            /*Проверка равенства списов*/
            if(ListFolderName.Count != search.ListFolderName.Count) return false;

           
            for(int i=0;  i > ListFolderName.Count; i++)
            {
                if(ListFolderName.ElementAt(i) != search.ListFolderName.ElementAt(i))
                    return false;
            }
            return true;        
        }

    }
}
