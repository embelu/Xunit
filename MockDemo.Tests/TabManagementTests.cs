using Moq;
using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using System.Text;
using Xunit;

namespace MockDemo.Tests
{
    public class TabManagementTests
    {
        /// <summary>
        /// Cas classique : Test sur une valeur attendue.
        /// </summary>
        [Fact]
        public void GiveArrayInt_WhenCallSommeDatas_ThenReturnSumItems()
        {
            //Arrange
            TabManagement tabManagement = new TabManagement();
            int[] items = new int[5] { 1, 2, 3, 4, 5 };
            int expectedValue = 15;

            //Act
            var actualValue = tabManagement.SommeDatas(items);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }



        /// <summary>
        /// Test sur le message en retour d'une exception.
        /// </summary>
        [Fact]
        public void GiveArrayInt_WhenCallNullParams_ThenThrowArgumentNullExceptionMessage()
        {
            //Arrange
            TabManagement tabManagement = new TabManagement();
            string expectedMessage = "Value cannot be null.";

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => tabManagement.SommeDatas(null));
            //var s = exception.GetType();

            //Assert
            Assert.Contains(expectedMessage, exception.Message);
            // Assert.Equal("ArgumentNullException", s.Name);
        }



        /// <summary>
        /// Test sur le type d'une exception.
        /// </summary>
        [Fact]
        public void GiveArrayInt_WhenCallNullParams_ThenThrowArgumentNullExceptionType()
        {
            //Arrange
            TabManagement tabManagement = new TabManagement();

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => tabManagement.SommeDatas(null));
            var type = exception.GetType();

            //Assert
            Assert.Equal("ArgumentNullException", type.Name);
        }


         /// <summary>
         /// Testing via Mock DB Return Tableau entier
         /// </summary>
        [Fact]
        public void GiveArrayInt_WhenCallSommeDatasMockDB_ThenReturnSumItems()
        {
            //Arrange
            var databaseManagement = new Mock<IDatabaseManagement>();

            databaseManagement.Setup(x => x.GetItemsFromDatabase()).Returns(new int[5] { 1, 2, 3, 4, 5 });

            var tabManagement = new TabManagement(databaseManagement.Object);
            var expected = 15;

            //Act
            var actualValue = tabManagement.SommeDatasByDataBaseFake();

            //Assert
            Assert.Equal(expected, actualValue);
        }



        /// <summary>
        /// Testing via Mock DB Return ArgumentNullException
        /// </summary>
        [Fact]
        public void GiveArrayIntByDatabase_WhenCallNullParams_ThenThrowArgumentNullException()
        {
            //Arrange
            var databaseManagement = new Mock<IDatabaseManagement>();
            databaseManagement.Setup(x => x.GetItemsFromDatabase()).Throws(new ArgumentNullException());

            var tabManagement = new TabManagement(databaseManagement.Object);
            var expectedMessage = "Value cannot be null.";

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => tabManagement.SommeDatasByDataBaseFake());

            //Assert
            Assert.Contains(expectedMessage, exception.Message);
        }



        /// <summary>
        /// Test sur la connection Db Fake
        /// </summary>
        [Fact]
        public void GiveApplicationDatabaseNotConnected_WhenCallSommeDatas_ThenMustConnectDB()
        {
            //Arrange
            var databaseManagement = new Mock<IDatabaseManagement>();
            databaseManagement.Setup(x => x.IsConnected()).Returns(false);
            var tabManagement = new TabManagement(databaseManagement.Object);

            //Act
            var actualValue = tabManagement.SommeDatasByDataBaseFake();

            //Assert
            databaseManagement.Verify(x => x.Connect(), Times.Once); // Connect doit être exécutée une fois.
        }


        /// <summary>
        /// Test sur la connection Db Fake
        /// </summary>
        [Fact]
        public void GiveApplicationDatabaseConnected_WhenCallSommeDatas_ThenMustConnectDB()
        {
            //Arrange
            var databaseManagement = new Mock<IDatabaseManagement>();
            databaseManagement.Setup(x => x.IsConnected()).Returns(true);
            var tabManagement = new TabManagement(databaseManagement.Object);

            //Act
            var actualValue = tabManagement.SommeDatasByDataBaseFake();

            //Assert
            databaseManagement.Verify(x => x.Connect(), Times.Never); // Connect ne doit pas être exécutée. 
        }


        
      
        /// <summary>
        /// Test sur une fichier Fake
        /// </summary>
        [Fact]
        public void GiveArrayOfIntFromFile_WhenCallSommeData_ThenReturnSumItems()
        {
            //Arrange
            var mockFileSystem = new MockFileSystem();
            MockFileData mockFileData = new MockFileData("1,2,3,4,5");

            string path = @"D:\number.csv";
            mockFileSystem.AddFile(path, mockFileData);
            TabManagement tabManagement = new TabManagement(mockFileSystem);
            var expectedValue = 15;

            //Act
            var actualValue = tabManagement.SommeDatasByFile(path);

            //Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
