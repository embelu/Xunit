using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;

namespace MockDemo
{
    public class TabManagement
    {
        IDatabaseManagement _databaseManagement;
        IFileSystem _fileSystem;

        public TabManagement()
        {

        }

        public TabManagement(IDatabaseManagement databaseManagement)
        {
           _databaseManagement = databaseManagement;
        }

        public TabManagement(IFileSystem fileSystem)
        {  
           _fileSystem = fileSystem;
        }




        /// <summary>
        /// Additionne les nombres contenus dans un tableau d'entier.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public int SommeDatas(int[] items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            int value = 0;

            foreach (var item in items)
            {
                value += item;
            }
            return value;
        }


        /// <summary>
        /// Additionne les nombres contenus dans un fichier CSV.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int SommeDatasByFile(string path)
        {
            int[] items = GetArrayFromFile(path);

            if (items == null)
            {
                throw new ArgumentNullException();
            }

            int value = 0;

            foreach (var item in items)
            {
                value += item;
            }
            return value;
        }

        private int[] GetArrayFromFile(string path)
        {
            var content = _fileSystem.File.ReadAllText(path);
            var contentArray = content.Split(",");

            var items = new int[contentArray.Length];
            var i = 0;

            foreach (var item in contentArray)
            {
                items[i] = Int32.Parse(item);
                i++;
            }

            return items;
        }


        /// <summary>
        /// Additionne les nombres contenus dans une DB Fake. 
        /// </summary>
        /// <returns></returns>
        public int SommeDatasByDataBaseFake()
        {
            if (!_databaseManagement.IsConnected())
            {
                _databaseManagement.Connect();
            }

            int[] items = _databaseManagement.GetItemsFromDatabase();

            if (items == null)
            {
                throw new ArgumentNullException();
            }

            int value = 0;

            foreach (var item in items)
            {
                value += item;
            }
            return value;
        }
    }
}
