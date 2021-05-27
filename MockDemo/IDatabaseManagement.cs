using System;
using System.Collections.Generic;
using System.Text;

namespace MockDemo
{
    public interface IDatabaseManagement
    {
        bool IsConnected();
        void Connect();
        int[] GetItemsFromDatabase();
    }
}
