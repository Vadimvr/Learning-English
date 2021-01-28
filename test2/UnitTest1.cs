using NUnit.Framework;

namespace test2
{
    public class Tests
    {
        [TestFixture]
        public class PathToMultimedia_Test
        {
            private LElWPF.Core.Models.PathToMultimedia _PathToMultimedia;
            private readonly string id = "001";
            private readonly string path = @"D:\a\a";
            [SetUp]
            public void SetUp()
            {
                _PathToMultimedia = new LElWPF.Core.Models.PathToMultimedia(id, path);
            }

            [Test]
            public void PathImg()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");
            }
            [Test]
            public void PathImg2()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");
            }
            [Test]
            public void PathImg3()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");
            }
            [Test]
            public void PathImg4()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");
            }
            [Test]
            public void PathImg5()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");
            }
            [Test]
            public void PathImg6()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");
            }
            [Test]
            public void PathImg7()
            {
                var result = _PathToMultimedia.PathImg;
                var result2 = path + @"\img\" + id + ".jpg";
                Assert.IsTrue(true, $"tyrtr");

            }
        }
}
}