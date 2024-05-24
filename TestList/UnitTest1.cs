using GeometrucShapeCarLibrary;
using ���_12._1_List;

namespace TestList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToBegin_AddsItemToBeginning() // ���������� � ������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            int expectedCount = 3;

            // Act
            list.AddToBegin(new Shape("�������", 1));
            list.AddToBegin(new Shape("�������", 2));
            list.AddToBegin(new Shape("�������", 3));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("�������", expectedCount - i));
                current = current.Next;
            }
        }
        [TestMethod]
        public void AddToEnd_AddsItemToEnd() // ���������� � �����
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            int expectedCount = 3;

            // Act
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("�������", i + 1));
                current = current.Next;
            }
        }
        //[TestMethod]
        //public void Remove_RemovesItem() // �������� ��������
        //{
        //    // Arrange
        //    MyList<Shape> list = new MyList<Shape>();
        //    list.AddToEnd(new Shape());
        //    int expectedCount = 0;

        //    // Act
        //    list.Remove(list.FindItem(new Shape()));

        //    // Assert
        //    Assert.AreEqual(expectedCount, list.Count);
        //}
        [TestMethod]
        public void RemoveItem_Middle() // �������� �������� � ��������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 123456789));
            list.AddToEnd(new Shape("�������", 3));
            int expectedCount = 3;

            // Act
            list.RemoveItem(new Shape("�������", 123456789));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("�������", i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void RemoveItem_Beg() // �������� �������� � ������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 123456789));
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));
            int expectedCount = 3;

            // Act
            list.RemoveItem(new Shape("�������", 123456789));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Assert.AreEqual(list.beg.Data, new Shape("�������", 1));
        }
        [TestMethod]
        public void RemoveItem_End() // �������� �������� � �����
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));
            list.AddToEnd(new Shape("�������", 123456789));
            int expectedCount = 3;

            // Act
            list.RemoveItem(new Shape("�������", 123456789));

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Assert.AreEqual(list.end.Data, new Shape("�������", 3));
        }
        [TestMethod]
        public void RemoveItem_EmptyList() // �������� ��������������� ��������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();

            // Act
            bool ok = list.RemoveItem(new Shape("�������", 123456789));

            // Assert
            Assert.IsTrue(ok == false);
        }
        [TestMethod]
        public void RemoveName_EmptyList() // �������� ��������������� �������� (�� ��������)
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();

            // Act
            Shape seted = new Shape();
            seted.Name = "�������";
            bool ok = list.RemoveName(seted);

            // Assert
            Assert.IsTrue(ok == false);
        }
        [TestMethod]
        public void AddItem_AddsItemAfterSpecifiedName_Middle() // ���������� ����� �������� � �������� ��������� � ��������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 4));
            int expectedCount = 4;

            // Act
            Shape seted = new Shape("�������", 2);
            list.AddItem(new Shape("�������", 3), seted);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("�������", i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void AddItem_AddsItemAfterSpecifiedName_End() // ���������� ����� �������� � �������� ��������� � �����
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));
            int expectedCount = 4;

            // Act
            Shape seted = new Shape("�������", 3);
            list.AddItem(new Shape("�������", 4), seted);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("�������", i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void RemoveAllItems_RemovesAllItemsWithSpecifiedName() // �������� ���� ��������� � �������� ���������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("cherry", 66));
            list.AddToEnd(new Shape("apple", 87));
            list.AddToEnd(new Shape("apple", 56));
            list.AddToEnd(new Shape("apple", 0));
            list.AddToEnd(new Shape("banana", 23));
            int expectedCount = 2;

            // Act
            Shape deleted = new Shape();
            deleted.Name = "apple";
            list.RemoveAllItems(deleted);

            // Assert
            // ������ ����������� ������ �� ���� ���������: cherry � ������, banana � �����
            Assert.AreEqual(list.Count, expectedCount);
            Assert.AreEqual(list.beg.Data, new Shape("cherry", 66));
            Assert.AreEqual(list.end.Data, new Shape("banana", 23));
        }
        [TestMethod]
        public void Clone_CreatesDeepCopyOfList() // ������������ ������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));

            // Act
            MyList<Shape> cloneList = list.Clone();
            cloneList.end.Data.Name = "������-�������";

            // Assert
            // ���������, ��������� �� ����������� �������� � �� ��������� �� ������� � ������������ ������ ������ � ������������� 
            Assert.AreEqual(list.Count, cloneList.Count);
            Point<Shape>? current = cloneList.beg;
            for (int i = 0; current != null; i++)
            {
                if (i + 1 == 3) Assert.AreEqual(current.Data, new Shape("������-�������", i + 1));
                else Assert.AreEqual(current.Data, new Shape("�������", i + 1));
                current = current.Next;
            }
            current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, new Shape("�������", i + 1));
                current = current.Next;
            }
        }
        [TestMethod]
        public void Clone_CreatesDeepCopyOfEmptyList() // ������������ ������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();

            // Act
            MyList<Shape> cloneList = list.Clone();

            // Assert
            Assert.AreEqual(list.Count, cloneList.Count);
            Assert.AreEqual(cloneList.beg, null);
            Assert.AreEqual(cloneList.end, null);
        }
        [TestMethod]
        public void Clear_RemovesAllItemsFromList() // �������� ���� ��������� � ������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("apple", 56));
            list.AddToEnd(new Shape("banana", 23));
            int expectedCount = 0;

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
        }
        [TestMethod]
        public void FindName_ReturnsCorrectItem() // ����� �������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 56));

            // Act
            Shape searched = new Shape();
            searched.Name = "�������";
            Point<Shape>? result = list.FindName(searched);

            // Assert
            Assert.AreEqual(new Shape("�������", 56), result?.Data);
        }
        [TestMethod]
        public void FindItem_ReturnsCorrectItem() // ����� �� ���������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));

            // Act
            Shape searched = new Shape("�������", 2);
            Point<Shape>? result = list.FindItem(searched);

            // Assert
            Assert.AreEqual(new Shape("�������", 2), result?.Data);
        }
        [TestMethod]
        public void FindItem_ReturnsNull() // ����� �� ���������
        {
            // Arrange
            MyList<Shape> list = new MyList<Shape>();
            list.AddToEnd(new Shape("�������", 1));
            list.AddToEnd(new Shape("�������", 2));
            list.AddToEnd(new Shape("�������", 3));

            // Act
            Shape searched = new Shape("�������", 4);
            Point<Shape>? result = list.FindItem(searched);

            // Assert
            Assert.AreEqual(null, result?.Data);
        }
        [TestMethod]
        public void ExceptionListConstructor_NegativeSize() // ����������� �� �������������� �������
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new MyList<Shape>(-1)));
        }
        [TestMethod]
        public void ExceptionListConstructor_NullCollection() // ����������� �� null-�������
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new MyList<Shape>(null)));
        }
        [TestMethod]
        public void ExceptionListConstructor_EmptyCollection() // ����������� �� ������� �������
        {
            // Assert
            Assert.ThrowsException<Exception>(() => (new MyList<Shape>(new Shape[0])));
        }
        [TestMethod]
        public void ListConstructorCollection() // ����������� �� ������ �������
        {
            // Arrange
            Shape[] array = new Shape[5];
            for (int i = 0; i < 5; i++)
            {
                Shape s = new Shape();
                s.RandomInit();
                array[i] = s;
            }
            int expectedCount = array.Length;

            // Act
            MyList<Shape> list = new MyList<Shape>(array);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
            Point<Shape>? current = list.beg;
            for (int i = 0; current != null; i++)
            {
                Assert.AreEqual(current.Data, array[i]);
                current = current.Next;
            }
        }
        [TestMethod]
        public void ListConstructorSize() // �����������, ��������� ���� ��������� �������
        {
            // Arrange
            int expectedCount = 5;

            // Act
            MyList<Shape> list = new MyList<Shape>(5);

            // Assert
            Assert.AreEqual(expectedCount, list.Count);
        }
        [TestMethod]
        public void PointConstructor() // ����������� Point
        {
            // Arrange
            Point<Shape> point1 = new Point<Shape>();

            // Act
            Point<Shape> point2 = new Point<Shape>(null);

            // Assert
            Assert.AreEqual(point1.Previous, point2.Previous);
            Assert.AreEqual(point1.Data, point2.Data);
            Assert.AreEqual(point1.Next, point2.Next);
        }
        [TestMethod]
        public void NullPointToString() // null Point-������
        {
            // Arrange
            Point<Shape> point1 = new Point<Shape>();

            // Act
            string s = "";

            // Assert
            Assert.AreEqual(s, point1.ToString());
        }
        [TestMethod]
        public void PointToString() // Point-������
        {
            // Arrange
            Shape seted = new Shape("�������", 2);
            Point<Shape> point1 = new Point<Shape>(seted);

            // Act
            string s = "id 2: " + "�������";

            // Assert
            Assert.AreEqual(s, point1.ToString());
        }
    }
}