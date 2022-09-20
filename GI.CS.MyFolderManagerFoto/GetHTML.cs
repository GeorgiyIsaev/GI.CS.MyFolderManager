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

        public static string Table(string nameCatalog, string width)
        {
            List<string> nameFiles = new List<string>(System.IO.Directory.GetFiles(nameCatalog)); //список картинок

            string text = @"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";

            text += "<style>" +
                ".container .card_item{width: "+ width + "; border:1px solid gray; }" +
                ".container{display:flex;flex-direction:row;flex-wrap:wrap;}" +
                ".card_item{   padding: 15px 15px 15px 15px;}" +
                "</style>";




            text += "<h2>" + "</h2>";
            text += "<div class=\"container\">";
            //background:#d3d3d3;
            foreach (var nameFile in nameFiles)
            {
                text += "<img class=\"card_item\" src=\"";
                text += "file://" + nameFile;
                text += "\"width =\"100%\" title=\"" + nameFile + "\" border=\"0\" alt=\"" + nameFile + "\">";
            }

            text += "</div>";
            return text;
        }
    }
}
