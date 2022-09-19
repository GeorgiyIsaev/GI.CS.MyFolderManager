using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GI.CS.MyFolderManagerFoto
{
    public partial class MainWindow
    {
        /*Формирует список повторов*/

        /*Каталог с повторами*/
        ObservableCollection<SearchForMatch> infoCatalogMatch = new ObservableCollection<SearchForMatch>();

        /*Повтор содержит папки*/
        ObservableCollection<InfoCatalog> infoCatalogSearch = new ObservableCollection<InfoCatalog>();


        private void ListCatalogMatch()
        {
            /*Создает каталог с повтороами*/

            DataGrid_CatalogMatch.ItemsSource = null;
            ParserDictionary.CreateNewFindMatcheCatalog(infoCatalog); //создадим словарь на основе содержимого каталога

            infoCatalogMatch = new ObservableCollection<SearchForMatch>();
            foreach (KeyValuePair<string, List<string>> item in ParserDictionary.catalogsKey)
            {
                SearchForMatch temp = new SearchForMatch(item);
                if (temp.CountFind <= 1) continue;
                infoCatalogMatch.Add(new SearchForMatch(item));
            }
            DeleteSameResults();
            DataGrid_CatalogMatch.ItemsSource = infoCatalogMatch;
            DataGrid_CatalogMatch.Items.Refresh();
        }



        private void Button_DeleteMinCount_Click(object sender, RoutedEventArgs e)
        {
            /*Выбрать минимальное кол-во слов в строке*/
            DataGrid_CatalogMatch.ItemsSource = null;
            ParserDictionary.CreateNewFindMatcheCatalog(infoCatalog); //создадим словарь на основе содержимого каталога

            infoCatalogMatch = new ObservableCollection<SearchForMatch>();
            int inputCountWords;
            bool isNumeric = int.TryParse(TextBox_DeleteMinCount.Text, out inputCountWords);
            if (!isNumeric) inputCountWords = 0;

            foreach (KeyValuePair<string, List<string>> item in ParserDictionary.catalogsKey)
            {
                SearchForMatch temp = new SearchForMatch(item);

                if (temp.CountItem <= inputCountWords) continue;
                if (temp.CountFind <= 1) continue;

                infoCatalogMatch.Add(new SearchForMatch(item));
            }
            DeleteSameResults();
            DataGrid_CatalogMatch.ItemsSource = infoCatalogMatch;
            DataGrid_CatalogMatch.Items.Refresh();
        }


        private void DataGrid_CatalogMatch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*Показать папки имеющие повторы*/
            DataGrid_Catalog.ItemsSource = null;
            infoCatalogSearch = new ObservableCollection<InfoCatalog>();

            SearchForMatch temp = (SearchForMatch)DataGrid_CatalogMatch.SelectedItem;

            foreach (var item in temp.ListFolderName)
            {
                infoCatalogSearch.Add(new InfoCatalog { NameCatalog = item, CountFile = ListCatalogCountFile(item) });
            }

            DataGrid_Catalog.ItemsSource = infoCatalogSearch;
            DataGrid_Catalog.Items.Refresh();
        }


        private void DeleteSameResults()
        {
            /*Удаление одинаковых резульататов в пользу большего значения*/
            DataGrid_CatalogMatch.ItemsSource = null;

          

            List<SearchForMatch> tempList = new List<SearchForMatch>(infoCatalogMatch);
            List<SearchForMatch> tempList_new = new List<SearchForMatch>();

            foreach (var item in tempList)
            {
                if(tempList_new.Count == 0)
                {
                    tempList_new.Add(item);
                    continue;
                }


                if(item.IsListEqually(tempList_new[tempList_new.Count - 1])){
                    if(item.NameCatalog.Length > tempList_new[tempList_new.Count - 1].NameCatalog.Length)
                    {
                        tempList_new.RemoveAt(tempList_new.Count - 1);
                        tempList_new.Add(item);
                    }
                    continue;
                }

                tempList_new.Add(item);                
            }


            infoCatalogMatch = new ObservableCollection<SearchForMatch>(tempList_new);
            DataGrid_CatalogMatch.ItemsSource = infoCatalogMatch;
            DataGrid_CatalogMatch.Items.Refresh();

        }
    }
}
