using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI.CS.MyFolderManagerFoto
{
    public static class GetHTML
    {
        public static string Line(string nameCatalog)
        {
            List<string> nameFiles = new List<string>(System.IO.Directory.GetFiles(nameCatalog)); //список картинок

            string text = @"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";
            text += "<div>";
        


            foreach (var nameFile in nameFiles)
            {
                text += "<img src=\"";
                text += "file://" + nameFile;
                text += "\"width =\"100%\" title=\"" + nameFile + "\" border=\"0\" alt=\"" + nameFile + "\">";
            }
            text += "</div>";
            return text;
        }

        public static string Table(string nameCatalog)
        {
            List<string> nameFiles = new List<string>(System.IO.Directory.GetFiles(nameCatalog)); //список картинок

            string text = @"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";
            text += "<div \"width =\"100%\">";

            text += "<table \"width =\"100%\">";

            int count = 0;
            foreach (var nameFile in nameFiles)
            {
                if (count == 0)
                {
                    text += "<tr>";
                }

                text += "<td>";
                text += "<img src=\"";
                text += "file://" + nameFile;
                text += "\"width =\"100%\" title=\"" + nameFile + "\" border=\"0\" alt=\"" + nameFile + "\">";
                text += "</td>";

                if (count == 5)
                {
                    count = 0;
                    text += "</tr>";
                }
                count++;
            }
            if (count !=0) text += "</tr>";

            text += " </table>";
            text += "</div>";
            return text;
        }
    }
}
