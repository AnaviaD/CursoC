using CursoBasico.HackerRank;

namespace testHR
{
    public class Tests
    {

        private appleOrange appleOra;

        [SetUp]
        public void Setup()
        {
            appleOra = new appleOrange();
        }
            
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test] 
        public void TestAppleOrange()
        {
            List<int> apples = new List<int> { -2, 2, 1};
            List<int> oranges = new List<int> { 5, -6};
            List<int> r_list = new List<int>();

            r_list.AddRange(appleOra.countApplesAndOranges(7, 11, 5, 15, apples, oranges ));

            if (r_list.Count >= 2 && r_list[0] == 1 && r_list[1] == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Las condiciones no se cumplieron. Valores: " + string.Join(", ", r_list));
            }

        }
    }
}