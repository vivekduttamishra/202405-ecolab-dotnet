namespace ConceptArchitect.Collections.Tests
{
    public class LinkedListTests
    {
        LinkedList<int> list;
        int[] items = { 2, 3, 9, 5 };


        [SetUp]
        public void Setup()
        {

            list = new LinkedList<int>();
            foreach (var item in items)
                list.Add(item);

        }

        [Test]
        public void NewLinkedListHasZeroCount()
        {
            var list = new LinkedList<int>();
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void CanCreateListOfString()
        {
            var list= new LinkedList<string>();
            list.Add("Hi");

            Assert.That(list[0], Is.EqualTo("Hi"));
        }

        [Test]
        public void AddingAnItemIncreasesListCount()
        {
            list.Add(1);

            Assert.That(list.Count, Is.EqualTo(items.Length + 1));
        }

        [Test]
        public void GetCanReturnItemsFromValidIndex()
        {
            for (int i = 0; i < items.Length; i++)
            {
                Assert.That(list[i], Is.EqualTo(items[i]));
            }
        }

        [Test]
        public void GetShouldFailForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => 
            {
                var x = list[list.Count + 1];
            });

        }

        [Test]
        public void SetSetsItemsFromValidIndex()
        {
            list[1]= 100;

            Assert.That(list[1], Is.EqualTo(100));
        }

        [Test]
        public void SetShouldFailForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list[list.Count+1]=1);

        }

        [Test]
        public void RemoveShouldFailForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(list.Count + 1));
            Assert.That(list.Count, Is.EqualTo(items.Length));
        }

        [Test]
        public void RemoveCanRemoveAnItemFromBeginingOfList()
        {
            var removed = list.Remove(0);

            Assert.That(removed, Is.EqualTo(items[0]));
            Assert.That(list.Count, Is.EqualTo(items.Length - 1));

        }

        [Test]
        public void RemoveCanRemoveAnItemFromEndOfList()
        {
            var removed = list.Remove(list.Count - 1);

            Assert.That(removed, Is.EqualTo(items[items.Length - 1]));
            Assert.That(list.Count, Is.EqualTo(items.Length - 1));

        }

        [Test]
        public void RemoveCanRemoveANonTerminalItem()
        {
            var removed = list.Remove(2);

            Assert.That(removed, Is.EqualTo(items[2]));
            Assert.That(list.Count, Is.EqualTo(items.Length - 1));

        }

        [Test]
        public void InsertFailsForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(list.Count + 1, 1));
        }

        [Test]
        public void InsertCanInsertInTheBegining()
        {
            var value = 100;
            list.Insert(0, value);

            Assert.That(list.Count, Is.EqualTo(items.Length + 1));
            Assert.That(list[0], Is.EqualTo(value));
        }


        [Test]
        public void InsertCanInsertAtEnd()
        {
            var value = 100;
            list.Insert(items.Length - 1, value);

            Assert.That(list.Count, Is.EqualTo(items.Length + 1));
            Assert.That(list[items.Length - 1], Is.EqualTo(value));
        }

        [Test]
        public void InsertCanInsertAtNonTerminal()
        {
            var value = 100;
            int index = 2;
            list.Insert(index, value);

            Assert.That(list.Count, Is.EqualTo(items.Length + 1));
            Assert.That(list[index], Is.EqualTo(value));
        }

        [Test]
        public void ToStringReturnsEmptyListWithEmptyKeyword()
        {
            var list = new ObjectList();

            Assert.That(list.ToString(), Is.EqualTo("LinkedList(empty)"));
        }

        [Test]
        public void ToStringShouldIncludeAllListItems()
        {
            foreach (var item in items)
            {
                Assert.True(list.ToString().Contains(item.ToString()), $"{item} not found");
            }
        }

        [Test]
        public void CanSumAListOfValues()
        {
            var numbers = new LinkedList<int>();
                
            numbers.Add(1);
            numbers.Add(2);
            //numbers.Add("Hi"); //detects problem
            numbers.Add(3);

            int sum = 0;
            for (var i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i]; //returns int
            }

            Assert.That(sum, Is.EqualTo(6));
        }


        [Test]
        public void CanAddTwoListsTogether()
        {
            int[] data2 = { 9, 1, 8 };

            var list2 = new LinkedList<int>();
            foreach (var item in data2)
                list2.Add(item);

            var list3 = list + list2;

            Assert.That(list3.Count, Is.EqualTo(list.Count + list2.Count));


        }
    }
}