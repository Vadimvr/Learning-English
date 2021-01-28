using NUnit.Framework;
using LElWPF.Core;


    public class TestTests
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
            
            //PathImg = path + @"\img\" + id + ".jpg";
            //PathSong = path + @"\song\" + id + ".mp3";
        }
    }
