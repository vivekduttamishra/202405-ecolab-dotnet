namespace AnimalsDemo
{
    public class ReflectionTests
    {
        Type t = typeof(Tiger);
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AllTypeReferencesForAClassWillBeSame()
        {
            var tiger = new Tiger();

            var t1= typeof(Tiger);
            var t2= tiger.GetType();
            var t3 = Type.GetType("AnimalsDemo.Tiger");

            Assert.That(t1.GetHashCode(), Is.EqualTo(t2.GetHashCode()));

            Assert.That(t1.GetHashCode(), Is.EqualTo(t3.GetHashCode()));
        }

        [Test]
        public void GetTypeWillFailForInvalidType()
        {
            var t = Type.GetType("AnimalDemos.Dog");
            Assert.IsNull(t);
        }

        [Test]
        public void TypeCanTellAboutClassDetails()
        {   

            Assert.That(t.Name, Is.EqualTo("Tiger"));
        }

        [Test]
        public void TypeCanTellAboutBaseClass()
        {

            Assert.That(t.BaseType, Is.EqualTo(typeof(Cat)));
        }

        [Test]
        public void TypeCanTellIfClassIsAbstract()
        {

            Assert.True(typeof(Mammal).IsAbstract);
        }

        [Test]
        public void TypeCanReturnAListOfMethodsPresent()
        {
            var methods = t.GetMethods();

            string[] expectedMethods = { "Hunt","Eat", "Move","Breed" };

            foreach(var expectedMethod in expectedMethods)
            {
                bool found = false;
                foreach(var method in methods)
                {
                    if(method.Name==expectedMethod)
                    {
                        found = true;
                        break;
                    }
                }

                Assert.True(found, $"{expectedMethod} not found in {t.Name}");
            }

        }

        [Test]
        public void CanCheckIfAGivenMethodIsPresentInObject()
        {
            var method = t.GetMethod("Hunt");

            Assert.That(method.Name, Is.EqualTo("Hunt"));
        }

        [Test]
        public void CanCheckIfAInvalidMethodIsNotPresentInObject()
        {
            var method = t.GetMethod("Fly");

            Assert.That(method, Is.Null);
        }

        [Test]
        public void CanFindOutWhatParametersAGivenMethodTakes()
        {
            var huntMethod = t.GetMethod("Hunt");
            var equalsMethod = t.GetMethod("Equals");
            Assert.That(huntMethod.GetParameters().Length, Is.EqualTo(0));
            Assert.That(equalsMethod.GetParameters().Length, Is.EqualTo(1));
        }

        [Test]
        public void CanCreateAnObjectFromTypeAtRuntime()
        {
            var obj = Activator.CreateInstance(t);

            Assert.That(obj, Is.InstanceOf<Tiger>());
        }

        [Test]
        public void CanCallMethodOfTheObjectAtRuntime()
        {
            //direct call
            var tiger = new Tiger();
            var tigerHuntOutput = tiger.Hunt();

            //reflection call
            Object obj = Activator.CreateInstance(t);
            var method = t.GetMethod("Hunt");

            var reflectionHuntOutput = method.Invoke(obj, []);

            Assert.That(reflectionHuntOutput, Is.EqualTo(tigerHuntOutput));
        }

        [Test]
        public void EaglesHaveTwoSpecialBehavior()
        {
            var eagle = new Eagle();

            var specialBehaviors  = eagle.GetSpecialBehaviors();

            Assert.That(specialBehaviors.Count, Is.EqualTo(2));
        }


        [Test]
        public void CowsHaveNoSpecialBehavior()
        {
            

            var specialBehaviors = typeof(Cow).GetSpecialBehaviors();

            Assert.That(specialBehaviors.Count, Is.EqualTo(0));
        }
    }
}