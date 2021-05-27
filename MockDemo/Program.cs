using System;
using System.IO.Abstractions;

namespace MockDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            TabManagement tabManagement = new TabManagement();
            Console.WriteLine(tabManagement.SommeDatas(new int[5] { 1, 2, 3, 4, 5 }));


            DatabaseManagement databaseManagement = new DatabaseManagement();
            TabManagement tabManagementDBM = new TabManagement(databaseManagement);
            Console.WriteLine(tabManagementDBM.SommeDatasByDataBaseFake());


            IFileSystem fileSystem = new FileSystem();
            TabManagement tabManagementFile = new TabManagement(fileSystem);
            Console.WriteLine(tabManagementFile.SommeDatasByFile("D:\\number.csv"));


            Console.Read();
        }
    }
}
