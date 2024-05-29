using CursoBasico.HackerRank;

namespace testHR
{
    public class Tests
    {

        private appleOrange appleOra;
        private NumberLineJumps kangooro;
        private breakingRecords record;
        private chocoBar        barC;

        [SetUp]
        public void Setup()
        {
            appleOra    = new appleOrange();
            kangooro    = new NumberLineJumps();
            record      = new breakingRecords();
            barC        = new chocoBar();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestCBar()
        {
            List<int> r_list = new List<int> { 1, 2, 1, 3, 2 };
            
            int ans = 0;

            ans = barC.birthday(r_list, 3, 2);

            if (ans == 2)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void TestBreakingR()
        {
            List<int> r_list        = new List<int> { 10, 5, 20, 20, 4, 5, 2, 25, 1 };
            List<int> result_list   = new List<int> { 2, 4};
            List<int> copy_list     = new List<int>();

            copy_list.AddRange(record.breakingRecordsF(r_list));

            if (copy_list[0] == result_list[0] && copy_list[1] == result_list[1])
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void TestAppleOrange()
        {
            List<int> apples = new List<int> { -2, 2, 1 };
            List<int> oranges = new List<int> { 5, -6 };
            List<int> r_list = new List<int>();

            r_list.AddRange(appleOra.countApplesAndOranges(7, 11, 5, 15, apples, oranges));

            if (r_list.Count >= 2 && r_list[0] == 1 && r_list[1] == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Las condiciones no se cumplieron. Valores: " + string.Join(", ", r_list));
            }

        }

        [Test]
        public void TestKangaro()
        {
            if (kangooro.kangaroo(0, 2, 5, 3) == "NO")
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

    }
}