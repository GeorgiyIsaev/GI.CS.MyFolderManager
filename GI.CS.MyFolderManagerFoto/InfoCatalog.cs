﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.CS.MyFolderManagerFoto
{
    public class InfoCatalog
    {
        public String NameCatalog { get; set; }
        public String FullNameCatalog { get; set; }
        public int CountFile { get; set; }
        public List<string> tags = new List<string>();



        public InfoCatalog(string nameCatalog, string parentCatalog)
        {
            NameCatalog = nameCatalog;
            FullNameCatalog = parentCatalog + "\\" + nameCatalog;
        }
        private int ListCatalogCountFile(string NameCatalog)
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

            List<string> nameItem = new List<string>(NameCatalog.Split('.'));
            
            if(nameItem.Count >1)
                nameItem.RemoveAt(nameItem.Count-1);

            tags = new List<string>(nameItem);


        }

    }
}
