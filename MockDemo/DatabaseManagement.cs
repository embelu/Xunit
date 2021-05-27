using System;
using System.Collections.Generic;
using System.Text;

namespace MockDemo
{
    public class DatabaseManagement : IDatabaseManagement
    {
        bool dbConnect = false;

        public void Connect()
        {
            dbConnect = true;
        }

        public int[] GetItemsFromDatabase()
        {
            var items = new int[5] {1,2,3,4,5 };
            return items;
        }

        public bool IsConnected()
        {
            return true;
        }
    }
}
