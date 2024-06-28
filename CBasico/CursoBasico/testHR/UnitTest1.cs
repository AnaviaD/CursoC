using CursoBasico.HackerRank;

namespace testHR
{
    public class Tests
    {

        private appleOrange             appleOra;
        private NumberLineJumps         kangooro;
        private breakingRecords         record;
        private chocoBar                barC;
        private betweenTwSets           btwSets;
        private divisibleSumPairs       divSPair;
        private gradingStudnts          grdStdns;
        private migratoryBrds           migratoryBBBB;
        private billDiv                 billDivvv;
        private salesByMach             salesbMachT;
        private drowBook                drawBook;
        private ValleysCount            vallCount;
        private electronicsShop         electroSp;
        private catsAndMouseCCC         catsAndM;

        [SetUp]
        public void Setup()
        {
            appleOra            = new appleOrange();
            kangooro            = new NumberLineJumps();
            record              = new breakingRecords();
            barC                = new chocoBar();
            btwSets             = new betweenTwSets();
            divSPair            = new divisibleSumPairs();
            grdStdns            = new gradingStudnts();
            migratoryBBBB       = new migratoryBrds();
            billDivvv           = new billDiv();
            salesbMachT         = new salesByMach();
            drawBook            = new drowBook();
            vallCount           = new ValleysCount();
            electroSp           = new electronicsShop();
            catsAndM            = new catsAndMouseCCC();


        }


        [Test]
        public void mousesAndCats()
        {
            string winn = "";

            winn = catsAndM.catAndMouse(1, 2, 3);

            if (winn == "Cat B")
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void electronicShops()
        {
            int[] keyboards = { 3, 1 };
            int[] drives = { 5, 2, 8 };
            int b = 10;

            int ans = 0;

            ans = electroSp.getMoneySpent(keyboards, drives, b);

            if (ans == 9)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [Test]
        public void valleyCount()
        {
            string path = "DDUUDDUDUUUD";
            int ans = vallCount.countingValleys(12, path);

            if (ans == 2)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [Test]
        public void drowBookTest()
        {

            int ans = drawBook.pageCount(6, 2);

            if (ans == 1)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [Test]
        public void salesByMachTest()
        {
            List<int> a_list = new List<int> { 10, 20, 20, 10, 10, 30, 50, 10, 20 };


            int ans = salesbMachT.sockMerchant(9, a_list);

            if (ans == 3)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }


        [Test]
        public void billDivisition()
        {
            List<int> a_list = new List<int> { 3, 10, 2, 9 };


            int ans = billDivvv.bonAppetit(a_list, 1, 12);

            if (ans == 5)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void migratoryBirds()
        {
            List<int> a_list = new List<int> { 1, 2, 3, 4, 5, 4, 3, 2, 1, 3, 4 };


            int ans = migratoryBBBB.migratoryBirds(a_list);

            if (ans == 3)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void gradStud()
        {
            List<int> a_list = new List<int> { 73, 67, 38, 33 };
            List<int> b_list = new List<int> { 75, 67, 40, 33 };

            List<int> ans = new List<int>();

            ans = grdStdns.gradingStudents(a_list);

            if (ans.SequenceEqual(b_list))
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void divSumPairs()
        {
            List<int> a_list = new List<int> { 1, 3, 2, 6, 1, 2 };

            int ans, n = 6, k = 3;

            ans = divSPair.divSum(n, k, a_list);

            if (ans == 5)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void betweenTwoSets()
        {
            List<int> a_list = new List<int> { 2, 4 };
            List<int> b_list = new List<int> { 16, 32, 96 };

            int ans = 0;

            ans = btwSets.getTotalX(a_list, b_list);

            if (ans == 3)
            {
                Assert.Pass();
            }
            Assert.Fail();
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