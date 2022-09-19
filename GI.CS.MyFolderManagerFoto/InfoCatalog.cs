using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.CS.MyFolderManagerFoto
{
    public class InfoCatalog
    {
        public String NameCatalog { get; set; }
        public int CountFile { get; set; }



        public List<String> SplitName()
        {
            List<String> nameItem = new List<String>(NameCatalog.Split(' ', '-'));
            nameItem.RemoveAll(EndsWithSaurus); //Удалить пустые строчки
            return nameItem;
        }

        private static bool EndsWithSaurus(String s)
        {
            return s.Length < 1;
        }
    }
}
