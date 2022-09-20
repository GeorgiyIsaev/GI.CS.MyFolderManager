using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.CS.MyFolderManagerFoto
{
    public class InfoCatalog
    {
        public String NameCatalog { get; set; }
        public String FullNameCatalog { get; set; }
        public String ParentCatalog { get; set; }
        public int CountFile { get; set; }
        public List<string> tags = new List<string>();



        public InfoCatalog(string nameCatalog, string parentCatalog)
        {
            NameCatalog = nameCatalog;
            ParentCatalog = parentCatalog;
            FullNameCatalog = parentCatalog + "\\" + nameCatalog;
            GetTags();
            CountFile =  ListCatalogCountFile();
        }
        private int ListCatalogCountFile()
        {
            /*Считает количество файлов внутри папки*/
            int countFile = new System.IO.DirectoryInfo(FullNameCatalog)
                .GetFiles("*.*", System.IO.SearchOption.AllDirectories).Length;
            return countFile;
        }
        public List<string> SplitName()
        {
            List<string> nameItem = new List<string>(NameCatalog.Split(' ', '-', '_'));
            nameItem.RemoveAll(EndsWithSaurus); //Удалить пустые строчки
            return nameItem;
        }
        private static bool EndsWithSaurus(string s)
        {
            return s.Length < 1;
        }


        private void GetTags()
        {

            string substring = " - ";
            int indexOfSubstring = NameCatalog.IndexOf(substring);
            if (indexOfSubstring < 0) return;

            string textTags = NameCatalog.Substring(0, indexOfSubstring);

     

            List<string> nameItem = new List<string>(textTags.Split('.'));
            tags = new List<string>(nameItem);


        }

        public void OpenCatalog()
        {
            Path.Combine(ParentCatalog, NameCatalog);
        }

    }
}
