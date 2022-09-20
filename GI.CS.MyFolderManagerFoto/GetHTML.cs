using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


            nameFiles.Sort(delegate (string x, string y)
            {
                string temp1 = x.Replace(nameCatalog, "");
                string temp2 = y.Replace(nameCatalog, ""); 
                temp1 = temp1.Replace("\\", "");
                temp2 = temp2.Replace("\\", "");
                temp1 = temp1.Replace(".jpg", "");
                temp2 = temp2.Replace(".jpg", "");
                temp1 = temp1.Replace(".png", "");
                temp2 = temp2.Replace(".png", "");
                //string text = Console.ReadLine();

                int number1; int number2;
                if (int.TryParse(temp1, out number1) && int.TryParse(temp2, out number2))
                {
                   // MessageBox.Show(temp1 + " - " + temp2 + " == " + (number1 - number2));
                    return number1 - number2;
                   
                }
                else if (int.TryParse(temp1, out number1) || int.TryParse(temp2, out number2))
                {
                    //MessageBox.Show(temp1 + " - " + temp2 + " == " + x.CompareTo(y));
                    return x.CompareTo(y);
                }
                else {
                   // MessageBox.Show(temp1 + " - " + temp2 + " == " + x.CompareTo(y));
                    return x.CompareTo(y); 
                }

            });



            string text = @"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>";

            text += "<style>" +
                ".container .card_item{width: "+ width + "; border:1px solid gray; }" +
                ".container{display:flex;flex-direction:row;flex-wrap:wrap;}" +
                ".card_item{ align: center valign: bottom padding: 15px 15px 15px 15px;}" + // 
                "h2{ color: blue;  font-family: verdana; text-align:center; padding: 5px 5px 5px 5px;}" +
//              //"  a:focus + .full {  display: block;}" +
// //               ".pictures {  -webkit-column-count: 4;  -moz-column-count: 4;  column-count: 4;  -webkit-column-gap: 1em;  -moz-column-gap: 1em;  column-gap: 1em;  margin-bottom: -1em;}" +
//"a {  display: inline-block;}" +
//"img {  display: block;  width: 100%;  margin-bottom: 1em;} " +
//".full {  display: none;  position: fixed;  left: 0;  top: 0;  right: 0;  bottom: 0;  padding: 8%;  background: #CCC center no-repeat;  background: rgba(0, 0, 0, 0.5) center no-repeat;" +
//" background-size: contain;  background-origin: content-box;}" +
//".full:target {  display: block;}"+
                "</style>";
          
            string[] words = nameCatalog.Split(new char[] { '\\' });


            text += "<h2>" + words[words.Length-1] + "</h2>";
            text += "<div class=\"container\">";
            //background:#d3d3d3;
            foreach (var nameFile in nameFiles)
            {
                //text += "<a id=\"" + nameFile + "\" " +
                //    "href=\"#\" class=\"full\" style=\"background-image:url(" + nameFile + ")\"></a>";
                //text += " <a href=\"" +nameFile +"\">";

               // text += "<a href = \"" + nameFile + "\" class=\"highslide\" onclick=\"a: focus\">";
                text += "<img  class=\"card_item\"  src=\"";
                text += "file://" + nameFile;
                text += "\"width =\"100%\" title=\"" + nameFile + "\" border=\"0\" alt=\"" + nameFile + "\">";
             //   text += "</a>";



            }

            text += "</div>";
            return text;
        }
    }
}
