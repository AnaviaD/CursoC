using System;
using testFunctions;

namespace watchTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public void testDalas()
        {
            var testd = new dalas();

            //Hay que regresar un string para poder evaluar la funcion
            //testd.speak

        }
    }
}