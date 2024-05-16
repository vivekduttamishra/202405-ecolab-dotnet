namespace ConceptArchitect.Collections.Tests
{
    public class IntListTests
    {
        IntList list;
        int[] items = { 2, 3, 9, 5 };


        [SetUp]
        public void Setup()
        {

            list = new IntList();
            foreach (var item in items)
                list.Add(item);

        }

        [Test]
        public void NewLinkedListHasZeroCount()
        {
            var list = new IntList();
            Assert.That(list.Count, Is.EqualTo(0));
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
                Assert.That(list.Get(i), Is.EqualTo(items[i]));
            }
        }

        [Test]
        public void GetShouldFailForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Get(list.Count + 1));

        }

        [Test]
        public void SetSetsItemsFromValidIndex()
        {
            list.Set(1, 100);

            Assert.That(list.Get(1), Is.EqualTo(100));
        }

        [Test]
        public void SetShouldFailForInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Set(list.Count + 1, 1));

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
            Assert.That(list.Get(0), Is.EqualTo(value));
        }


        [Test]
        public void InsertCanInsertAtEnd()
        {
            var value = 100;
            list.Insert(items.Length - 1, value);

            Assert.That(list.Count, Is.EqualTo(items.Length + 1));
            Assert.That(list.Get(items.Length - 1), Is.EqualTo(value));
        }

        [Test]
        public void InsertCanInsertAtNonTerminal()
        {
            var value = 100;
            int index = 2;
            list.Insert(index, value);

            Assert.That(list.Count, Is.EqualTo(items.Length + 1));
            Assert.That(list.Get(index), Is.EqualTo(value));
        }

        [Test]
        public void ToStringReturnsEmptyListWithEmptyKeyword()
        {
            var list = new IntList();

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
            var list = new IntList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int sum = 0;
            for(var i=0; i < list.Count; i++)
            {
                sum += list.Get(i); //returns int
            }

            Assert.That(sum, Is.EqualTo(6));
        }

    }
}