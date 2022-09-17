using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace GI.CS.MyFolderManager
{
    public partial class MainWindow
    {
        public class InfoCatalog
        {
            public String NameCatalog { get; set; }
            public int CountFile { get; set; }

            public List<String> SplitName()
            {  
                List<String> nameItem = new List<String>(NameCatalog.Split(' ', '-'));
                nameItem.RemoveAll(EndsWithSaurus);
                return nameItem;
            }

            private static bool EndsWithSaurus(String s)
            {
                return s.Length < 1;
            }
        }   
    }
}
